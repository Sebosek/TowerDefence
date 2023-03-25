using UnityEngine;

public class InitLevel : MonoBehaviour
{
    [SerializeField] private IntVariable _coins;
    
    [SerializeField] private IntVariable _health;
    
    [SerializeField] private IntVariable _liveMonsters;
    
    [SerializeField] private IntVariable _nthWave;
    
    [SerializeField] private IntVariable _monstersCounter;

    protected void Start()
    {
        Debug.Log("Running init!");
        
        _coins.Value = _coins.Default;
        _health.Value = _health.Default;
        _liveMonsters.Value = _liveMonsters.Default;
        _nthWave.Value = _nthWave.Default;
        _monstersCounter.Value = _monstersCounter.Default;
    }
}
