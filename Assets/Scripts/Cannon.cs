using System.Collections;
using System.Linq;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private const string ENEMY = "Enemy";
    
    private const float WAIT_TIME = 0.1f;

    [SerializeField] private float _radius;
    
    private GameObject[] _enemies;

    private GameObject _target;

    public bool Locked => _target is not null;

    protected void Update()
    {
        StartCoroutine(FindClosestEnemy());
        AimTowardsEnemy();
    }
    
    private IEnumerator FindClosestEnemy()
    {
        // Infinite coroutine
        while (true)
        {
            var enemies = GameObject.FindGameObjectsWithTag(ENEMY);

            var ordered = enemies
                .Select(s => new
                {
                    Enemy = s,
                    Distance = Vector3.Distance(transform.position, s.transform.position),
                })
                .Where(w => w.Distance < _radius)
                .OrderBy(o => o.Distance);

            var record = ordered.FirstOrDefault();
            _target = record?.Enemy;

            AimTowardsEnemy();
            yield return new WaitForSeconds(WAIT_TIME);
        }
    }

    private void AimTowardsEnemy()
    {
        if (_target is null) return;

        var direction = _target.transform.position - transform.position;
        transform.up = new Vector2(direction.x, direction.y);
    }
}
