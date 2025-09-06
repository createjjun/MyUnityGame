using System.ComponentModel.Design;
using UnityEngine;
using System;
public class PlayerModel : MonoBehaviour
{
    private Vector2 pos;
    public event Action<Vector2> MovePosition;
    [SerializeField] private PlayerInfo _info;
    public int attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        pos = transform.position;
        MovePosition?.Invoke(pos);
        Debug.Log("good");
        attack = _info.val[1].value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        MovePosition?.Invoke(pos);
    }
    public void Die()
    {

    }
}
