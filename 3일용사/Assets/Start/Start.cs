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
        EditorApplication.isPlaying = false; // 에디터에서는 실행 중지
#else
        Application.Quit(); // 빌드된 실행파일에서는 게임 종료
#endif
    }
}
