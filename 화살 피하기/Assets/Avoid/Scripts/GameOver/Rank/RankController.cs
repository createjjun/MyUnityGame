using System.Collections.Generic;
using UnityEngine;

public class RankController : MonoBehaviour
{
    [SerializeField] private RankModel _model;
    [SerializeField] private RankView _view;
    [SerializeField] private TimerModel _timeModel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _model.RankAdd(_timeModel._curTime);
        _view.UpdateRank(_model.rankList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Insert(TimerModel Tm)
    {
        _timeModel = Tm;
    }

    
}
