using System.Collections;
using UnityEngine;

public class SpwanModel : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private EnemyModel _enemyModel;
    [SerializeField] private PlayerModel _plModel;
    [SerializeField] private Score score;
    private Vector2 pos;
    private float randX;
    private float randY;
    private bool Spwan = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Spwan)
        {
            Spwan = false;
            StartCoroutine(EnemySpwan());
        }
    }
    IEnumerator EnemySpwan()
    {
        yield return new WaitForSeconds(1.5f);
        randX = Random.Range(-8f, 6f);
        randY = Random.Range(-4f, 4f);
        pos = new Vector2(randX, randY);
        GameObject enemy = Instantiate(_enemy, pos, Quaternion.identity);
        var ene = enemy.GetComponent<EnemyModel>();
        ene.Insert(_plModel, score);
        Spwan = true;
    }
}
