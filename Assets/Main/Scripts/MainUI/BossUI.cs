using UnityEngine;
using UnityEngine.SceneManagement;


public class BossUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnExitButton()
    {
        Destroy(gameObject);
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(7);
    }
}
