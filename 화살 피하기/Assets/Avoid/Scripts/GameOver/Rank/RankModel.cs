using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class RankModel : MonoBehaviour
{
    [SerializeField] private Rank rank;
    public List<float> rankList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rankList = rank.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RankAdd(float time)
    {
        if (rankList.Count == 0) rankList.Add(time);
        else if (time > rankList[0]) rankList.Insert(0, time);
        else
        {
            for (int i = rankList.Count - 1; i >= 0; i--)
            {
                if (time < rankList[i])
                {
                    rankList.Insert(i + 1, time);
                    break;
                }
            }
        }
        if (rankList.Count > 10)
        {
            rankList.RemoveRange(10, rankList.Count - 10);
        }
    }
}
