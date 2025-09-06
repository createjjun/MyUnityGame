using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class BarModel : MonoBehaviour
{
    public int sliderMax;
    [SerializeField] private int sliderLine;
    public event Action<int,int,int> OnBarClear;
    private int BarSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BarSpeed = UnityEngine.Random.Range(40, 50);
        sliderMax = UnityEngine.Random.Range(40, 100);
        sliderLine = UnityEngine.Random.Range(20, sliderMax-10);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClearBar()
    {
        BarSpeed = UnityEngine.Random.Range(80, 100);
        sliderMax = UnityEngine.Random.Range(50, 95);
        sliderLine = UnityEngine.Random.Range(sliderMax-10, sliderMax - 5);
        OnBarClear?.Invoke(sliderMax, sliderLine, BarSpeed);
    }
}
