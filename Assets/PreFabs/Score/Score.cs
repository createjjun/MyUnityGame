using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    public int score { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void UpdateScore(int point)
    {
        score += point;
        scoreUI.text = score.ToString();
    }
}
