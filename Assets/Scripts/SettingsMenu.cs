using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI")]
    public Slider volumeSlider;
    public TMP_Dropdown graphicsDropdown;

    private const string VolumeKey = "Volume";
    private const string GraphicsKey = "GraphicsQuality";

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        int savedGraphics = PlayerPrefs.GetInt(GraphicsKey, QualitySettings.GetQualityLevel());

        savedVolume = Mathf.Clamp01(savedVolume);
        savedGraphics = Mathf.Clamp(savedGraphics, 0, QualitySettings.names.Length - 1);

        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = savedVolume;
        }

        if (graphicsDropdown != null)
        {
            graphicsDropdown.ClearOptions();
            graphicsDropdown.AddOptions(new System.Collections.Generic.List<string>
            {
                "Low",
                "Medium",
                "High",
                "Ultra"
            });

            graphicsDropdown.value = Mathf.Clamp(savedGraphics, 0, graphicsDropdown.options.Count - 1);
            graphicsDropdown.RefreshShownValue();
        }

        ApplyVolume(savedVolume);
        ApplyGraphics(savedGraphics);
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);

        ApplyVolume(volume);

        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        qualityIndex = Mathf.Clamp(qualityIndex, 0, QualitySettings.names.Length - 1);

        ApplyGraphics(qualityIndex);

        PlayerPrefs.SetInt(GraphicsKey, qualityIndex);
        PlayerPrefs.Save();
    }

    private void ApplyVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    private void ApplyGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }
}