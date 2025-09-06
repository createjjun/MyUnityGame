using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;



public class CardView : MonoBehaviour
{
    public event Action<int, GameObject, string> select;
    [SerializeField] private CardType _type;
    [SerializeField] private Button Btn;
    [SerializeField] private Sprite basic;
    [SerializeField] private CardModel _model;
    private Sprite sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Btn.image.sprite = basic;
    }
    // Update is called once per frame
    public void Insert(CardModel model)
    {
        _model = model;
    }
    public void CardSprite(Sprite sp)
    {
        sprite = sp;
    }
    public void OnBtn()
    {
        Btn.image.sprite = sprite;
        Debug.Log(select == null ? "select is NULL" : "select has subscribers");
        select?.Invoke(1, gameObject, sprite.name);
    }

    public void TurnAgain()
    {
        Btn.image.sprite = basic;
    }
    public void Des()
    {
        _model.Reset -= Des;
        Destroy(gameObject);
    }
}
