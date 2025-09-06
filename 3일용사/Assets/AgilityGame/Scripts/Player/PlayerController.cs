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
    private bool isEnemyInRange = false;  // 플레이어가 범위 안에 있는지
    private Coroutine attackLoopCo = null; // 공격 루프 코루틴 핸들
    
    //아래 하도 안 풀려서 chatGpt씀 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        Debug.Log("Enemy 진입");
        isEnemyInRange = true;
        _enemyModel = other.GetComponent<EnemyModel>();
        // 이미 돌고 있지 않다면 공격 루프 시작
        if (attackLoopCo == null)
            attackLoopCo = StartCoroutine(AttackLoop());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        Debug.Log("Enemy 이탈");
        isEnemyInRange = false;

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
        Debug.Log("공격 루프 시작");
        while (isEnemyInRange)
        {
            yield return new WaitForSeconds(AttackSpeed);
            _bar.Damaged(_enemyModel.Attack);
            Debug.Log("공격! 데미지: " + _enemyModel.Attack);
        }
        Debug.Log("공격 루프 종료");
        attackLoopCo = null;
    }

}
