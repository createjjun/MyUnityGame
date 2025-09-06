using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnStart()
    {
        SceneManager.LoadScene(0);
    }
    public void OnExit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // �����Ϳ����� ���� ����
#else
        Application.Quit(); // ����� �������Ͽ����� ���� ����
#endif
    }
}
