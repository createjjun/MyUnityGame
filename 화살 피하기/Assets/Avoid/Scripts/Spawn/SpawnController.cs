using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private BulletModel _bModel;
    [SerializeField] private SpawnModel spawnModel;
    [SerializeField] private GameObject Bullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnModel.timer += Time.deltaTime;
        if (spawnModel.timer > spawnModel.SpawnInterval)
        {
            spawnModel.timer = 0f;
            for (int i = 0; i < spawnModel.SpawnCount; i++)
            {
                spawnModel.SpawnBullet();
            }
            spawnModel.SpawnCount += 0.25f;
        }
    }

}
