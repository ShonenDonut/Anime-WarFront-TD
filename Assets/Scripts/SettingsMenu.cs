using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_Dropdown graphicsDropdown;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        int savedGraphics = PlayerPrefs.GetInt("GraphicsQuality", QualitySettings.GetQualityLevel());

        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        graphicsDropdown.value = savedGraphics;
        graphicsDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
        PlayerPrefs.Save();
    }
}