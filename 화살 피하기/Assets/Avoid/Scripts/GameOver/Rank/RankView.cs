using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
public class RankView : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> rankText;
   
    [SerializeField] private Button Exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Exit.onClick.AddListener(exit);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateRank(List<float> times)
    {
        for (int i = 0; i < rankText.Count && i < times.Count; i++)
        {
            rankText[i].text = $"Rank:{i + 1}  {times[i]:F2} Second";
        }
    }
    private void exit()
    {
        Destroy(gameObject);
    }
}
