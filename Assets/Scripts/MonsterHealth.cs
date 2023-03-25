using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    private static readonly int DeadAnimation = Animator.StringToHash("IsDead");
    
    private static readonly int HurtAnimation = Animator.StringToHash("Hurt");
    
    [SerializeField] private float _health;

    [SerializeField] private Animator _animator;

    [SerializeField] private int _bounty;

    [SerializeField] private IntVariable _coins;
    
    [SerializeField] private IntVariable _liveMonsters;

    public bool IsDead => _health <= 0;

    public void Hurt(float damage)
    {
        _health -= damage;
        _animator.SetTrigger(HurtAnimation);
        
        if (_health > 0) return;
        
        _animator.SetBool(DeadAnimation, true);
        _coins.Value += _bounty;
        
        Destroy(gameObject, 1f);
    }

    protected void OnDestroy()
    {
        _liveMonsters.Value -= 1;
    }
}
