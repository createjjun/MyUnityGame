using Unity.VisualScripting;
using UnityEngine;

public class MeteoModel : MonoBehaviour
{
    [SerializeField] private Score score;
    Rigidbody2D rb;
    SpriteRenderer sp;
    int Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Land"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            score.UpdateScore(Score);
            Destroy(gameObject);
        }

    }
    public void insert(int s, Score score)
    {
        this.score = score;
        Score = s;
    }
}
