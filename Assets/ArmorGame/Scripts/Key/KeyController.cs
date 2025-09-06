using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private KeySpawnHandler _spawn;
    [SerializeField] private KeyModel _model;
    [SerializeField] private GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawn.KeyStore();
        for(int i=0; i < 6; i++) 
        {
            _spawn.KeySpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        string pressedKey = "";

        if (Input.GetKeyDown(KeyCode.W)) pressedKey = "W_0";
        if (Input.GetKeyDown(KeyCode.A)) pressedKey = "A_0";
        if (Input.GetKeyDown(KeyCode.S)) pressedKey = "S_0";
        if (Input.GetKeyDown(KeyCode.D)) pressedKey = "D_0";

        if (pressedKey != "")
        {
            _spawn.KeySpawn();
            _model.Success(pressedKey);
            pressedKey = "";
        }
    }
}
