using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FinalPlayer : MonoBehaviour
{
    public event Action<int> PlayerAttack;
    public event Action<int> PlayerDamaged;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayerInfo _info;
    [SerializeField] private ActionHandler _action;
    [SerializeField] private GameObject End;
    [SerializeField] private Transform canvas;
    private float HP;
    private float MP;
    private int Str;
    private int Agi;
    private int Wis;
    private int Arm;
    private bool Defence = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = _info.val[5].value;
        Str = _info.val[1].value;
        MP = _info.val[6].value;
        Agi = _info.val[2].value;
        Wis = _info.val[3].value;
        Arm = _info.val[4].value;
        Debug.Log("HP: " + HP + ", Str: " + Str + ", MP: " + MP + ", Agi: " + Agi + ", Wis: " + Wis + ", Arm: " + Arm);
        text.text = "Player HP " + HP + " / " + _info.val[5].value + " MP " + MP + " / " + _info.val[6].value;

    }
    public void OnNormal()
    {
        Debug.Log(0);
        PlayerAttack?.Invoke(Str);
    }
    public void OnMagic()
    {
        Debug.Log(1);
        MP -= 3;
        PlayerAttack?.Invoke(Wis*2);
    }
    public void OnDefence()
    {
        Defence = true;
        PlayerAttack?.Invoke(0);
        _action.PlayerDef();
    }
    public void OnHeal()
    {
        int healHp = (int)(HP * 0.5f);
        int healMp = (int)(MP * 0.5f);
        HP += (int)(healHp);
        MP += (int)(healMp);
        PlayerAttack?.Invoke(0);
        _action.PlayerHeal(healHp, healMp);
    }
    public void Damaged(int attack)
    {
        int d = attack - Arm;
        HP -= d;
        if (Defence)
        {
            if (attack - Arm * 2 > 0)
            {
                HP = HP + Arm;
            }
            else
            {
                HP = HP + d;
                d = 0;
            }

            Defence = false;
        }
        PlayerDamaged?.Invoke(d);
        if(HP>0)text.text = "Player HP " + HP + " / " + _info.val[5].value + " MP " + MP + " / "+ _info.val[6].value;
        else
        {
            GameObject end = Instantiate(End, canvas);
            Time.timeScale = 0f;
        }
    }
}
