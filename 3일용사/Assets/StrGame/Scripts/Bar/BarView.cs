using UnityEngine;
using UnityEngine.UI;

public class BarView : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image MaxUI;
    [SerializeField] private Image LineUI;
    private int Speed = 0;
    private int MaxVal;
    private int LineVal;
    public float value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        slider.value += time * Speed;
        value = slider.value;
    }

    public void BarEmpty(int Max,int Line, int BarSpeed)
    {
        //Debug.Log("good");
        Speed = BarSpeed;
        slider.value = 0;
        LineVal = Line;
        MaxVal = Max;
        MaxUI.rectTransform.anchoredPosition = new Vector2(0, Max*9);
        LineUI.rectTransform.anchoredPosition = new Vector2(0, Line*9);
    }

    public int Score()
    {
        if (slider.value >= LineVal && slider.value <= MaxVal) return 45;
        else if (slider.value >= LineVal - 10) return 30 - (LineVal - (int)slider.value);
        return 0;
    }
}
