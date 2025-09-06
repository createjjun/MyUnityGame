using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyModel : MonoBehaviour
{
    [SerializeField] private Transform panel;
    [SerializeField] private KeySpawnHandler _spawn;
    [SerializeField] private Score score;
    private string name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Success(string answer)
    {
        GameObject KeyPrefab = null;
        foreach(Transform child in panel.transform)
        {
            KeyPrefab = child.gameObject;
            if (KeyPrefab.activeSelf) break;
        }
        var sr = KeyPrefab.GetComponent<Image>();
        this.name = sr.sprite.name;
        if (answer == name)
        {
            score.UpdateScore(30);
        }
        else score.UpdateScore(-5);
        KeyPrefab.SetActive(false);
        KeyPrefab.transform.SetAsLastSibling();
    }
}
