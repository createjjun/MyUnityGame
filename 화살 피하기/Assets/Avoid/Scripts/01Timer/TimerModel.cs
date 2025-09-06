using System;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    public event Action<float> OnTimerChanged;

    public float _curTime;
    private bool over = false;

    private void Update()
    {
        if (!over)
        {
            _curTime += Time.deltaTime;
            OnTimerChanged?.Invoke(_curTime);
        }
        
    }
    public float Gameover()
    {
        over = true;
        return _curTime;
    }
}
