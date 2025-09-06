using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private MeteoType _type;
    [SerializeField] private Score score;
    public int count { get; private set; } = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMeteo()
    {
        float randX = Random.Range(-7, 8);
        int rand = Random.Range(0, 3);
        GameObject met = Instantiate(_type.Meteo[rand].Size, new Vector2(randX, 4), Quaternion.identity);
        var m = met.GetComponent<MeteoModel>();
        m.insert(_type.Meteo[rand].Score, score);
    }
}
