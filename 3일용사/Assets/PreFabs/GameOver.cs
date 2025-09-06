using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject OverUI;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Score score;
    [SerializeField] private SceneNum sceneNum;
    [SerializeField] private PlayerInfo _info;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpwanUI()
    {
        Time.timeScale = 0f;
        GameObject sp = Instantiate(OverUI, new Vector2(0, 0), Quaternion.identity);
        sp.transform.SetParent(canvas.transform, false);
        var Sp = sp.GetComponent<PanelScript>(); 
        Sp.Insert(score.score, sceneNum.Num);
        _info.val[_info.val.Count - 1].value -= 1;
    }
}
