using Unity.VisualScripting;
using UnityEngine;
using System.Collections;


public class ClickModel : MonoBehaviour
{
    [SerializeField] private PlayerModel _model;
    [SerializeField] private HPBar _bar;
    [SerializeField] private EnemyModel _enemyModel;
    [SerializeField] private PlayerInfo _info;
    private float AttackSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _model.MovePosition += _bar.Move;
        _bar.MaxHP(_info.val[4].value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _model.Move();
        }
    }
    private bool isEnemyInRange = false;  // �÷��̾ ���� �ȿ� �ִ���
    private Coroutine attackLoopCo = null; // ���� ���� �ڷ�ƾ �ڵ�
    
    //�Ʒ� �ϵ� �� Ǯ���� chatGpt�� 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        Debug.Log("Enemy ����");
        isEnemyInRange = true;
        _enemyModel = other.GetComponent<EnemyModel>();
        // �̹� ���� ���� �ʴٸ� ���� ���� ����
        if (attackLoopCo == null)
            attackLoopCo = StartCoroutine(AttackLoop());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        Debug.Log("Enemy ��Ż");
        isEnemyInRange = false;

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
        Debug.Log("���� ���� ����");
        while (isEnemyInRange)
        {
            yield return new WaitForSeconds(AttackSpeed);
            _bar.Damaged(_enemyModel.Attack);
            Debug.Log("����! ������: " + _enemyModel.Attack);
        }
        Debug.Log("���� ���� ����");
        attackLoopCo = null;
    }

}
