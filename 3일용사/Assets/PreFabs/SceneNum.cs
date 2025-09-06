using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNum : MonoBehaviour
{
    public int Num { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Num = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(Num);
    }

   
}
