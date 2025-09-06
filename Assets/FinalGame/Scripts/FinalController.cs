using UnityEngine;

public class FinalController : MonoBehaviour
{
    [SerializeField] private FinalPlayer _player;
    [SerializeField] private FinalBoss _boss;
    [SerializeField] private ActionHandler _action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player.PlayerAttack += _boss.Damaged;
        _boss.BossAttack += _player.Damaged;
        _boss.BossDamaged += _action.BossD;
        _player.PlayerDamaged += _action.PlayerD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
