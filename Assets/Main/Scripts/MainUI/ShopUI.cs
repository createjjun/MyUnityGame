using NUnit.Framework;
using TMPro;
using UnityEditor.Playables;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private PlayerInfo _info;
    [SerializeField] private AbilityUI _ability;
    [SerializeField] private MainUi _main;
    private int AbilityNum;
    [SerializeField]private int val = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void InsertA(AbilityUI ab)
    {
        _ability = ab;
    }
    public void InsertB(MainUi main)
    {
        _main = main;
    }

    // Update is called once per frame
    public void OnSTRButton()
    {
        Text.text = "Strength + " + val +"\n cost: 100G";
        AbilityNum = 1;
    }
    public void OnAigButton()
    {
        Text.text = "Agility + " + val + "\n cost: 100G";
        AbilityNum = 2;
    }
    public void OnWisButton()
    {
        Text.text = "Widsom + " + val + "\n cost: 100G";
        AbilityNum = 5;
    }
    public void OnArmButton()
    {
        Text.text = "Armor + " + val + "\n cost: 100G";
        AbilityNum = 3;
    }
    public void OnHPButton()
    {

        Text.text = "Health + " + val + "\n cost: 100G";
        AbilityNum = 4;
    }
    public void OnMPButton()
    {
        Text.text = "Mana +" + val + "\n cost: 100G";
        AbilityNum = 6;
    }
    public void OnExitButton()
    {
        Destroy(gameObject);
    }
    public void OnApplyButton()
    {
        if (_info.val[0].value >= 100)
        {
            _info.val[0].value -= 100;
            _main.Gold();
            _info.Add(AbilityNum, val);
            _ability.AbilityChanged(AbilityNum);
        }
        else
        {
            Text.text = "Not enough money.";
        }
    }
}
