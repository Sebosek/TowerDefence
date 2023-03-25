using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    private const string VOLUME = "MasterVolume";
    private const string EFFECTS = "SFXVolume";
    private const string MUSIC = "MusicVolume";
    
    [SerializeField] private GameObject _dialog;
    
    [SerializeField] private AudioMixer _mixer;
    
    [SerializeField] private Slider _volume;
    
    [SerializeField] private Slider _effects;
    
    [SerializeField] private Slider _music;

    public void Close() => _dialog.SetActive(false);
    
    public void Open() => _dialog.SetActive(true);
    
    public void Toggle() => _dialog.SetActive(!_dialog.activeInHierarchy);

    public void VolumeChanged()
    {
        SetValue(VOLUME, _volume.value);

        _effects.value = Math.Min(_effects.value, _volume.value);
        SetValue(EFFECTS, _effects.value);

        _music.value = Math.Min(_music.value, _volume.value);
        SetValue(MUSIC, Math.Min(_effects.value, _volume.value));
    }
    
    public void EffectsChanged() => SetValue(EFFECTS, _effects.value);
    
    public void MusicChanged() => SetValue(MUSIC, _music.value);
    
    protected void Start()
    {
        LoadSettings(VOLUME, _volume);
        LoadSettings(EFFECTS, _effects);
        LoadSettings(MUSIC, _music);
    }

    protected void Update()
    {
        if (!Input.GetKeyDown(KeyCode.V)) return;

        _dialog.SetActive(!_dialog.activeInHierarchy);
    }

    private void SetValue(string key, float value)
    {
        Debug.Log($"Set volume of {key} to value {value}");
        
        _mixer.SetFloat(key, value);
        PlayerPrefs.SetFloat(key, value);
    }
    
    private void LoadSettings(string key, Slider slider)
    {
        var value = PlayerPrefs.GetFloat(key, 0f);

        Debug.Log($"Loaded volume of {key} to value {value}");
        _mixer.SetFloat(key, value);
        // slider.value = value;
        slider.SetValueWithoutNotify(value);
    }
}
