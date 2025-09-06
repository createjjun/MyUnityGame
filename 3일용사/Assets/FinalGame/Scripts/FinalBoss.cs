using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FinalBoss: MonoBehaviour
{
    public event Action<int> BossAttack;
    public event Action<int> BossDamaged;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int Hp = 1000;
    [SerializeField] private int MP = 30;
    [SerializeField] private int Arm = 5;
    [SerializeField] private int Wis = 15;
    [SerializeField] private int Agi = 10;
    [SerializeField] private int Str = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Damaged(int attack)
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand >= Agi)
        {
            Hp -= attack + Arm;
            BossDamaged?.Invoke(attack + Arm);
        }
        else
        {
            BossDamaged?.Invoke(-1);
        }
        text.text = " Boss     HP " + Hp + "/1000";
    }
    public void BossTurn()
    {
        if (MP >= 5)
        {
            int rand = UnityEngine.Random.Range(0, 2);
            BossAttack?.Invoke(rand == 1 ? Str : Wis * 2);
        }
    }
}
