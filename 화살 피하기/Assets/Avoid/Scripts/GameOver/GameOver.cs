using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TimerView timerView;
    [SerializeField] private TimerModel timerModel;
    [SerializeField] private Button retryB;
    [SerializeField] private Button rankB;
    [SerializeField] private GameObject rankUI;
    [SerializeField] private Canvas canvas;

    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        retryB.onClick.AddListener(RestartGame);
        rankB.onClick.AddListener(ScoreRank);

    }

    // Update is called once per frame
    public void Gameover()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        timerText.text = timerView._timerText.text;
    }
    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void ScoreRank()
    {
        GameObject rank = Instantiate(rankUI, new Vector2(0, 0), Quaternion.identity);
        rank.transform.SetParent(canvas.transform, false);
        var rk = rank.GetComponent<RankController>();
        rk.Insert(timerModel);
    }
}
