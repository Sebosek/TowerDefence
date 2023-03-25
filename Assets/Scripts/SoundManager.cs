using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _output;
    
    [SerializeField] private AudioSource _level;
    
    [SerializeField] private AudioSource _boss;
    
    [SerializeField] private AudioSource _victory;
    
    [SerializeField] private AudioSource _gameOver;
    
    protected void Awake()
    {
        var go = gameObject;
        var count = FindObjectsOfType<SoundManager>().Length;
        if (count <= 1)
        {
            DontDestroyOnLoad(go);
            return;
        }
        
        go.SetActive(false);
        Destroy(go);
    }
    
    protected void Start()
    {
        PlayLevelMusic();
    }

    public void PlayLevelMusic()
    {
        Stop();
        _level.Play();
    }
    
    public void PlayBossMusic()
    {
        Stop();
        _boss.Play();
    }
    
    public void PlayVictoryMusic()
    {
        Stop();
        _victory.Play();
    }
    
    public void PlayGameOverMusic()
    {
        Stop();
        _gameOver.Play();
    }

    private void Stop()
    {
        _level.Stop();
        _boss.Stop();
        _victory.Stop();
        _gameOver.Stop();
    }
}
