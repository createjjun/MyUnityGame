using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    [SerializeField] private float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Debug.Log(h);
        if (h != 0)
        {
            sr.flipX = h < 0;
            rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);
            
        }
    }
}
