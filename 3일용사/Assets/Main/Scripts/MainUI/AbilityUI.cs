using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private PlayerInfo _info;
    [SerializeField] private List<TextMeshProUGUI> texts;
    [SerializeField] private GameObject Boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int Day = _info.val[texts.Count - 1].value / 3;
        int time = (_info.val[texts.Count - 1].value % 3) * 8;
        texts[0].text = "Ability";
        for (int i = 1; i < texts.Count - 1; i++)
        {
            texts[i].text = _info.val[i].Ability + ":  " + _info.val[i].value.ToString();
        }
        texts[texts.Count - 1].text = Day.ToString() + "Day " + time.ToString() + "Hour";
        if (_info.val[7].value==0) Boss.SetActive(true);
    }
    public void AbilityChanged(int num)
    {
        texts[num].text = _info.val[num].Ability + ":  " + _info.val[num].value.ToString();
    }

    // Update is called once per frame
    
}
