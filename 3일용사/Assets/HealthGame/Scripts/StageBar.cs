using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StageBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int val = 5;
    [SerializeField] private Score score;
    private int max;
    private int point = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        max = 50;
        slider.maxValue = max;
        slider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateVal()
    {
        slider.value += val;
        if (slider.value >= max)
        {
            score.UpdateScore(point);
            slider.value = 0;
            max += 20;
            point += 25;
            slider.maxValue = max;
        }
    }
}
