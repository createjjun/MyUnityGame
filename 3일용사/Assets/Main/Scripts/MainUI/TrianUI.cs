using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;

public class TrianUI : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private List<Sprite> sprite;
    [SerializeField] TextMeshProUGUI text;
    private int GameNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameNum = 1;
        img.sprite = sprite[0];
        text.text = "Strength Train";
    }

    public void OnStrButton()
    {
        img.sprite = sprite[0];
        GameNum = 1;
        text.text = "Strength Train";
    }
    public void OnAgiButton()
    {
        img.sprite = sprite[1];
        GameNum = 2;
        text.text = "Agility Train";
    }
    public void OnWisButton()
    {
        img.sprite = sprite[2];
        GameNum = 3;
        text.text = "Wisdom Train";
    }
    public void OnArmButton()
    {
        img.sprite = sprite[3];
        GameNum = 4;
        text.text = "Armor Train";
    }
    public void OnHPButton()
    {
        img.sprite = sprite[4];
        GameNum = 5;
        text.text = "Health Train";
    }
    public void OnMPButton()
    {
        img.sprite = sprite[5];
        GameNum = 6;
        text.text = "Mana Train";
    }
    public void OnExitButton()
    {
        Destroy(gameObject);
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(GameNum);
    }

}
