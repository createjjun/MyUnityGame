using Unity.Hierarchy;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerModel _plModel;
    [SerializeField] private PlMoveHandler _plMove;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private TimerModel _timerModel;
    [SerializeField] private GameOver _game;
    [SerializeField] private RankController _rkControll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float w = Input.GetAxisRaw("Vertical");

        _plModel.PosVal(h, w);
    }
    private void FixedUpdate()
    {
        _plMove.Movement(_plModel.H, _plModel.W, _plModel.MoveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            float time = _timerModel.Gameover();
            _game.Gameover();
            
        }
            
    }
}
