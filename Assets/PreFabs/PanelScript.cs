using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PanelScript : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> texts;
    [SerializeField] private PlayerInfo pl;
    private int score;
    private int gold;
    private int TrainNum;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(score);
        gold = score/ 35;
        pl.Add(0, gold);
        pl.Add(TrainNum, score/1000);
        texts[0].text = "Score    " + score.ToString();
        for(int i = 1; i < texts.Count; i++)
        {
            texts[i].text = pl.val[i - 1].Ability + "   " + pl.val[i - 1].value.ToString();
            if (i == 1) texts[i].text += $"    <color=#FFD700>+ {gold}</color>";
            if (i == TrainNum+1) texts[i].text += $"    <color=#FFD700>+ {score/1000}</color>";
        }
    }

    public void OnButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Insert(int sco, int num)
    {
        this.score = sco;
        TrainNum = num;
    }
}
