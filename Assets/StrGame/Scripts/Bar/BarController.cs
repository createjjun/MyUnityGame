using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] private BarModel _model;
    [SerializeField] private BarView _view;
    [SerializeField] private Score score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _model.OnBarClear += _view.BarEmpty;
        _model.ClearBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int point = _view.Score();
            score.UpdateScore(point);
            _model.ClearBar();
        }
        if (_model.sliderMax <= _view.value)
        {
            _model.ClearBar();
        }
    }
}
