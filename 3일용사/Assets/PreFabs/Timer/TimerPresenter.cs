using UnityEngine;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField] private TimerModel _model;
    [SerializeField] private TimerView _view;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _model.OnTimerChanged += _view.ChangedTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
