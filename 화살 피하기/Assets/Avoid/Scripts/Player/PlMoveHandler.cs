using UnityEngine;

public class PlMoveHandler : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 Pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Pos = rb.position;
    }
    public void Movement(float h, float w, float MoveSpeed)
    {
        Vector2 delta = new Vector2(h, w) * MoveSpeed;
        rb.MovePosition(rb.position + delta);
    }
}
