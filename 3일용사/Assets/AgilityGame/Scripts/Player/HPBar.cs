using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameOver _over;
    
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
        transform.position = new Vector2(pos.x-0.2f, pos.y+0.8f);
    }
    public void Damaged(int Attack)
    {
        slider.value += Attack;
        if (slider.value >= slider.maxValue)
        {
            Time.timeScale = 0f;
            _over.SpwanUI();
        } 
    }
    public void MaxHP(int HP)
    {
        slider.maxValue = HP;
    }
}
