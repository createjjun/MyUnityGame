using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ActionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private FinalPlayer _player;
    [SerializeField] private FinalBoss _boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "Choose your action";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNormal()
    {
        _player.OnNormal();

    }
    public void OnMagic()
    {
        _player.OnMagic();
    }
    public void OnDefence()
    {
        _player.OnDefence();
    }
    public void OnHeal()
    {
        _player.OnHeal();
    }
    public void BossD(int Damaged)
    {
        if(Damaged>=0)text.text = "The boss took " + Damaged.ToString() + "damage";
        else if (Damaged == -1) text.text = "The boss evaded the attack";
        StartCoroutine(BossAttack());
    }
    public void PlayerD(int Damaged)
    {
        if (Damaged >= 0) text.text = "The Player took " + Damaged.ToString() + "damage";
    }
    public void PlayerHeal(int healHP, int healMP)
    {
        text.text = "Player restores "+healHP+" health and "+healMP+" mana";
    }
    public void PlayerDef()
    {
        text.text = "Players prepare to defend";
    }
    IEnumerator BossAttack()
    {
        yield return new WaitForSeconds(1f);
        _boss.BossTurn();
    }
}
