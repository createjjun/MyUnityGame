using System;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    [SerializeField] private float _curTime = 30f;
    public event Action<float> OnTimerChanged;
    [SerializeField] GameOver game;
    private bool timeout = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _curTime -= Time.deltaTime;
        if (_curTime > 0) OnTimerChanged?.Invoke(_curTime);
        else if(_curTime<=0 && !timeout)
        {
            OnTimerChanged?.Invoke(0);
            game.SpwanUI();
            timeout = true;
        }
    }
}
