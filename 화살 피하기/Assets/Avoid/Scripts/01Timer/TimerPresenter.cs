using UnityEngine;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField] private TimerView _view;
    [SerializeField] private TimerModel _model;

    private void Awake()
    {
        _model.OnTimerChanged += _view.SetTimerText;
    }
}
