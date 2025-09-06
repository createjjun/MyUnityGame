using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MoveSpeed = 1f;
    public float H;
    public float W;
   

    private void Update()
    {
        
    }
    public void PosVal(float h, float w)
    {
        H = h;
        W = w;
    }
}
