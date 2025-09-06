using UnityEngine;

public class SpawnModel : MonoBehaviour
{
    private CircleCollider2D circle;
    [SerializeField] private GameObject B_prefab;
    [SerializeField] private PlayerModel player;
    public float SpawnInterval = 1f;
    public float SpawnCount = 1;
    public float timer;

    public Vector2 center = Vector2.zero;
    public float radius = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }           

    
    public Vector2 GetBoundaryPoint(float angleDegree)
    {
        float rad = angleDegree * Mathf.Deg2Rad; 
        float x = center.x + Mathf.Cos(rad) * radius;
        float y = center.y + Mathf.Sin(rad) * radius;
        return new Vector2(x, y);
    }

    public Vector2 GetRandomBoundaryPoint()
    {
        float angle = Random.Range(0f, 360f);
        return GetBoundaryPoint(angle);
    }

    public void SpawnBullet()
    {
        Vector2 pos = GetRandomBoundaryPoint();
        GameObject bulletGO = Instantiate(B_prefab, pos, Quaternion.identity);

        var bm = bulletGO.GetComponent<BulletModel>();
        bm.SetTarget(player);
    }


}
