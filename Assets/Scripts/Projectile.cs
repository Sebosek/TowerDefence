using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    [SerializeField] private float _speed;

    [SerializeField] private float _range = 3f;
    
    [SerializeField] private GameObject _animation;

    [SerializeField] private AudioSource _sound;

    private Rigidbody2D _rb;

    private Vector3 _origin;

    protected void Start()
    {
        _origin = transform.position + Vector3.zero;
        
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _speed;
    }

    protected void Update()
    {
        var distance = Vector3.Distance(_origin, transform.position);
        if (distance < _range) return;
        
        Destroy(gameObject);
    }
    
    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        var health = other.GetComponent<MonsterHealth>();
        if (health.IsDead) return;

        HitMonster();
        health.Hurt(_damage);
        Destroy(gameObject);
    }

    private void HitMonster()
    {
        AudioSource.PlayClipAtPoint(_sound.clip, Camera.main.transform.position, _sound.volume);
        
        var animation = Instantiate(_animation, transform.position, transform.rotation);
        Destroy(animation, 0.6f);
    }
}
