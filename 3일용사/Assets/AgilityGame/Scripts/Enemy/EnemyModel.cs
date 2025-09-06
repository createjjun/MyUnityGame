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
    private bool isPlayerInRange = false;  // 플레이어가 범위 안에 있는지
    private Coroutine attackLoopCo = null; // 공격 루프 코루틴 핸들
    //아래 하도 안 풀려서 chatGpt씀 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        //Debug.Log("Player 진입");
        isPlayerInRange = true;

        // 이미 돌고 있지 않다면 공격 루프 시작
        if (attackLoopCo == null)
            attackLoopCo = StartCoroutine(AttackLoop());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        //Debug.Log("Player 이탈");
        isPlayerInRange = false;

        // 범위를 벗어나면 루프 종료
        if (attackLoopCo != null)
        {
            StopCoroutine(attackLoopCo);
            attackLoopCo = null;
        }
    }

    // 플레이어가 범위 안에 있는 동안 주기적으로 공격하는 루프
    private IEnumerator AttackLoop()
    {
        //Debug.Log("공격 루프 시작");
        while (isPlayerInRange)
        {
            // 1) 데미지 주고
            _HP.Damaged(_plModel.attack);
            //Debug.Log("공격! 데미지: " + _plModel.attack);

            // 2) 쿨타임 대기
            yield return new WaitForSeconds(AttackSpeed);
        }
        //Debug.Log("공격 루프 종료");
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
