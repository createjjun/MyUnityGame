using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardModel : MonoBehaviour
{
    public event Action Reset;
    [SerializeField] private GameObject Btn;
    [SerializeField] private Transform gridParent;
    [SerializeField] private CardType _type;
    public List<Sprite> SprList = new List<Sprite>();
    [SerializeField] private CardView _view;
    [SerializeField] private int sel;
    [SerializeField] private List<(GameObject card, string name)> CardName = new List<(GameObject, string)>();
    [SerializeField] private CardModel _model;
    [SerializeField] private Score score;
    private int c = 2;
    public int PassCard;
    public void AddSpr(int n)
    {
        
        for (int i = 0; i < n; i++)
        {
            SprList.Add(_type.Sp[i]);
            SprList.Add(_type.Sp[i]);
        }
    }
    public void ShuffleCard(int num)
    {
        for (int i = 0; i < num; i++)
        {
            int r = UnityEngine.Random.Range(i, num);
            (SprList[i], SprList[r]) = (SprList[r], SprList[i]);
        }
    }
    public void SpawnCard()
    {
       
        for(int i = 0; i < SprList.Count; i++)
        {
            GameObject B = Instantiate(Btn, gridParent);
            var view = B.GetComponent<CardView>();
            view.CardSprite(SprList[i]);
            view.select += CardCheck;
            view.Insert(_model);
            Reset += view.Des;
        }
    }

    public void CardCheck(int n, GameObject card, string name)
    {
        sel += n;
        CardName.Add((card, name));
        if(sel == 2)
        {
            StartCoroutine(check());
        }
        
    }
    private IEnumerator check()
    {
        yield return new WaitForSeconds(0.5f);
        if (CardName[0].name != CardName[1].name)
        {
            var B1 = CardName[0].card.GetComponent<CardView>();
            var B2 = CardName[1].card.GetComponent<CardView>();
            B1.TurnAgain();
            B2.TurnAgain();
            Debug.Log(0);
            sel = 0;
            CardName.Clear();
            score.UpdateScore(45);
        }
        else
        {
            PassCard += 1;
            sel = 0;
            CardName.Clear();
        }
    }
    public void Restart()
    {
        Reset?.Invoke();

        SprList.Clear();
        score.UpdateScore(200);
    }
    public void SetColumns()
    {
        var grid = gridParent.GetComponent<GridLayoutGroup>();
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount; // 중요: Flexible이면 무시됨
        c += 1;
        grid.constraintCount = c;
    }
}
