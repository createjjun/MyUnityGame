using System.Collections;
using UnityEngine;

public class ClickController: MonoBehaviour
{
    [SerializeField] private StageBar _bar;
    private bool delay = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _bar.UpdateVal();
        }
    }
    
}
