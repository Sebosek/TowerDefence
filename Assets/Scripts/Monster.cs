using UnityEngine;

public class Monster : MonoBehaviour
{
    private int _nextWayPoint = 0;
    
    [SerializeField] private Transform[] _wayPoints;
    
    [SerializeField] private float _speed = 0.01f;
    
    [SerializeField] private MonsterHealth _health;

    [SerializeField] private IntVariable _lives;

    private Transform _transform;

    private Vector3 _target;

    private bool _flipped;

    private float _delta;
    
    protected void Start()
    {
        _transform = GetComponent<Transform>();
    }

    protected void Update()
    {
        if (_health.IsDead || _nextWayPoint >= _wayPoints.Length) return;

        var target = _wayPoints[_nextWayPoint];
        var enemy = _transform.position;
        _target = target.position;
        
        var heading = _target - enemy;
        _flipped = heading.x < 0;
    }

    protected void FixedUpdate()
    {
        var y = _flipped ? -180 : 0;
        
        _transform.rotation = Quaternion.Euler(0, y, 0);
        _transform.position = Vector2.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WP"))
        {
            _nextWayPoint += 1;
        }
        
        if (other.CompareTag("Finish"))
        {
            _lives.Value -= 1;
            Destroy(gameObject);
        }
    }
}
