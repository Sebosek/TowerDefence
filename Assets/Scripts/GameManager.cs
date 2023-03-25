using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float WAIT_TIME = 1f;

    [SerializeField] private GameObject _spawn;

    [SerializeField] private MonsterWave[] _waves;

    [SerializeField] private IntVariable _liveMonsters;
    
    [SerializeField] private IntVariable _nthWave;
    
    [SerializeField] private IntVariable _monstersCounter;
    
    [SerializeField] private IntVariable _lives;
    
    [SerializeField] private GameObject _dialogLost;
    
    [SerializeField] private GameObject _dialogWin;
    
    protected void Start()
    {
        _dialogLost.SetActive(false);
        _dialogWin.SetActive(false);
        StartCoroutine(Spawn());
    }
    
    protected void Update()
    {
        if (_lives.Value <= 0) _dialogLost.SetActive(true);
        if (_nthWave.Value == _waves.Length && _liveMonsters.Value == 0) _dialogWin.SetActive(true);
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(WAIT_TIME);
        
        // Infinite coroutine
        while (true)
        {
            if (_nthWave.Value == _waves.Length)
            {
                Debug.Log("Reached last wave, end the coroutine.");
                break;
            }
            
            var wave = _waves[_nthWave.Value];
            if (_monstersCounter.Value < wave.Monsters.Length)
            {
                Instantiate(wave.Monsters[_monstersCounter.Value], _spawn.transform.position, Quaternion.identity);
                
                _monstersCounter.Value += 1;
                _liveMonsters.Value += 1;
            }
            
            if (_liveMonsters.Value == 0 && _monstersCounter.Value == wave.Monsters.Length)
            {
                Debug.Log($"All monster from wave {_nthWave.Value} killed.");
                _monstersCounter.Value = _monstersCounter.Default;
                _liveMonsters.Value = _liveMonsters.Default;
                _nthWave.Value += 1;
                
                yield return new WaitForSeconds(5f);
                continue;
            }

            yield return new WaitForSeconds(WAIT_TIME);
        }
    }
}
