using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    Vector2 pos;
    [SerializeField] private EnemyHP _HP;
    [SerializeField] private EnemyInfo _Info;
    [SerializeField] private PlayerModel _plModel;
    [SerializeField] private Score score;
    public int HP;
    public int Attack;
    public string name;
    public int Gold { get; private set; }
    public int getScore { get; private set; }
    SpriteRenderer sp;
    private bool cooltime = false;
    [SerializeField] private float AttackSpeed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, _Info.Enemy.Count);
        sp.sprite = _Info.Enemy[rand].sprite;
        HP = _Info.Enemy[rand].HP;
        Attack = _Info.Enemy[rand].Attack;
        name = _Info.Enemy[rand].Name;
        pos = transform.position;
        Gold = _Info.Enemy[rand].GetCoin;
        getScore = _Info.Enemy[rand].GetScore;
        _HP.Move(pos);
        _HP.HPMax(HP);
        string id = name + " " + HP.ToString() + " " + Attack.ToString();
        //Debug.Log(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool isPlayerInRange = false;  // �÷��̾ ���� �ȿ� �ִ���
    private Coroutine attackLoopCo = null; // ���� ���� �ڷ�ƾ �ڵ�
    //�Ʒ� �ϵ� �� Ǯ���� chatGpt�� 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        //Debug.Log("Player ����");
        isPlayerInRange = true;

        // �̹� ���� ���� �ʴٸ� ���� ���� ����
        if (attackLoopCo == null)
            attackLoopCo = StartCoroutine(AttackLoop());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        //Debug.Log("Player ��Ż");
        isPlayerInRange = false;

        // ������ ����� ���� ����
        if (attackLoopCo != null)
        {
            StopCoroutine(attackLoopCo);
            attackLoopCo = null;
        }
    }

    // �÷��̾ ���� �ȿ� �ִ� ���� �ֱ������� �����ϴ� ����
    private IEnumerator AttackLoop()
    {
        //Debug.Log("���� ���� ����");
        while (isPlayerInRange)
        {
            // 1) ������ �ְ�
            _HP.Damaged(_plModel.attack);
            //Debug.Log("����! ������: " + _plModel.attack);

            // 2) ��Ÿ�� ���
            yield return new WaitForSeconds(AttackSpeed);
        }
        //Debug.Log("���� ���� ����");
        attackLoopCo = null;
    }
    public void Die()
    {
        Destroy(gameObject);
        score.UpdateScore(getScore);
    }
    public void Insert(PlayerModel pl, Score sc)
    {
        _plModel = pl;
        score = sc;
    }
}
