using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private EnemyModel _model;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector2 pos)
    {
        Vector2 Pos = pos;
        transform.position = new Vector2(Pos.x-0.2f, Pos.y+0.8f);
    }
    public void HPMax(int HP)
    {
        slider.maxValue = HP;
    }
    public void Damaged(int Attack)
    {
        slider.value += Attack;
        if (slider.value >= slider.maxValue)
        {
            _model.Die();
        }
    }
}
