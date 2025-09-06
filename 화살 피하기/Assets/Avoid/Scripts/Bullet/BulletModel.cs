using UnityEngine;
using System.Collections;

public class BulletModel : MonoBehaviour
{
    public float BulletSpeed = 8f;
    [SerializeField] private PlayerModel _plModel;
    private Rigidbody2D rb;
    private bool armed = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        // 첫 물리 프레임 이후부터 경계 이탈 감지 시작
        StartCoroutine(ArmAfterFixedUpdate());
    }
    IEnumerator ArmAfterFixedUpdate()
    {
        yield return new WaitForFixedUpdate();
        armed = true;
    }

    public void SetTarget(PlayerModel pl)
    {
        _plModel = pl;
        Fire();
    }

    private void Fire()
    {
        float randX = Random.Range(-1.3f, 1.3f);
        float randY = Random.Range(-1.3f, 1.3f);
        Vector2 pos = new Vector2(_plModel.transform.position.x + randX, _plModel.transform.position.y + randY);
        Vector2 dir = (pos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        BulletSpeed = Random.Range(5,10);
        rb.linearVelocity = dir * BulletSpeed; 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!armed) return;
        if (other.CompareTag("Back"))
            Destroy(gameObject);
    }

    // ★ 플레이어에만 반응 (Back 제거!)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
