using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume);
    }
    public void SetSound (float soundVolume)
    {
        audioMixer.SetFloat("soundVolume", Mathf.Log10(soundVolume) * 20);
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
    }
    public void SetMusic (float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
