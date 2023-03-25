using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _nextWayPoint = 0;
    
    [SerializeField] private Transform[] _wayPoints;
    
    [SerializeField] private float _speed = 1f;
    
    [SerializeField] private MonsterHealth _health;

    [SerializeField] private IntVariable _lives;

    private Transform _transform;

    private bool _flipped;
    
    protected void Start()
    {
        _transform = GetComponent<Transform>();
    }

    protected void Update()
    {
        if (_health.IsDead || _nextWayPoint >= _wayPoints.Length) return;

        var target = _wayPoints[_nextWayPoint];
        var delta = _speed * Time.deltaTime;

        var enemy = _transform.position;
        var wp = target.position;
        var heading = wp - enemy;
        
        _flipped = heading.x < 0;
        _transform.position = Vector2.MoveTowards(enemy, wp, delta);
    }

    protected void FixedUpdate()
    {
        var y = _flipped ? -180 : 0;
        
        _transform.rotation = Quaternion.Euler(0, y, 0);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WP")) _nextWayPoint += 1;
        if (other.CompareTag("Finish")) _lives.Value -= 1;
    }
}
