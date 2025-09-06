using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameEnd : MonoBehaviour
{
    [SerializeField] private PlayerInfo _info;
    public void OnRetry()
    {
        SceneManager.LoadScene(0);
        _info.val[0].value = 0;
        _info.val[1].value = 2;
        _info.val[2].value = 2;
        _info.val[3].value = 2;
        _info.val[4].value = 2;
        _info.val[5].value = 8;
        _info.val[6].value = 2;
        _info.val[7].value = 9;

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
