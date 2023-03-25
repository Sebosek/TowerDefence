using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    [SerializeField] private int _numberOfSpeedLevels = 3;

    [SerializeField] private int _gameSpeedMultiplier = 1;

    private int _currentSpeedLevel = 1;
    
    public void IncreaseGameSpeedHandle()
    {
        _currentSpeedLevel += 1;

        if (_currentSpeedLevel > _numberOfSpeedLevels)
        {
            _currentSpeedLevel = 1;
        }
        else
        {
            _currentSpeedLevel *= _gameSpeedMultiplier;
        }

        Time.timeScale = _currentSpeedLevel * 1f;
    }
}
