using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private static readonly int Upgrade = Animator.StringToHash("Upgrade");
    
    [SerializeField] private Cannon _cannon;
    
    [SerializeField] private GameObject _shot;
    
    [SerializeField] private float _reloadTime = 1f;

    [SerializeField] private Animator _animator;

    [SerializeField] private int _maxLevels = 3;

    [SerializeField] private GameObject _levelUpEffect;

    private float _reloadTimer;

    public int Level { get; private set; } = 1;

    public bool HasNextLevel => Level < _maxLevels;
    
    protected void Start()
    {
        _reloadTimer = _reloadTime;
    }

    protected void Update()
    {
        if (!_cannon.Locked) return;

        _reloadTimer -= Time.deltaTime;
        if (_reloadTimer > 0) return;

        Fire();
        _reloadTimer = _reloadTime;
    }

    public void LevelUp(float reloadTimeDecrease)
    {
        _reloadTime -= _reloadTime * reloadTimeDecrease;
        _animator.SetTrigger(Upgrade);
        Level += 1;

        var effect = Instantiate(_levelUpEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2.75f);
    }
    
    private void Fire()
    {
        var cannon = _cannon.transform;
        
        Instantiate(_shot, cannon.position, cannon.rotation);
    }
}
