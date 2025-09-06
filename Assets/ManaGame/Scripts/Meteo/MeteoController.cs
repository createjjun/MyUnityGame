using UnityEngine;

public class MeteoController : MonoBehaviour
{
    [SerializeField] private SpawnHandler _spawn;
    [SerializeField] private MeteoModel _model;
    
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawn.SpawnMeteo();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (time >= 1f)
        {
            for(int i=0;i<_spawn.count;i++)
            _spawn.SpawnMeteo();
            time = 0;
        }
    }
}
