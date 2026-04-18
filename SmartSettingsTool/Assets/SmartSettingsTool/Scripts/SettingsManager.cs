using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    // UI elements
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;

    // Event System to apply settings
    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SettingsManager exists and persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Load saved settings
        LoadSettings();
    }

    // Save settings
    public void SaveSettings()
    {
        // Save audio settings
        PlayerPrefs.SetFloat("masterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);

        // Save resolution and quality settings
        PlayerPrefs.SetInt("resolutionIndex", resolutionDropdown.value);
        PlayerPrefs.SetInt("qualityIndex", qualityDropdown.value);
        PlayerPrefs.SetInt("fullscreen", fullscreenToggle.isOn ? 1 : 0);

        // Save all settings to PlayerPrefs
        PlayerPrefs.Save();
    }

    // Load settings
    public void LoadSettings()
    {
        // Load audio settings
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.8f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0.8f);

        // Load resolution and quality settings
        resolutionDropdown.value = PlayerPrefs.GetInt("resolutionIndex", GetDefaultResolutionIndex());
        qualityDropdown.value = PlayerPrefs.GetInt("qualityIndex", 2);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("fullscreen", 1) == 1;

        // Apply settings to the game
        ApplySettings();
    }

    // Apply settings in the game (change resolution, quality, etc.)
    public void ApplySettings()
    {
        // Set screen resolution
        Resolution[] resolutions = Screen.resolutions;
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullscreenToggle.isOn);

        // Set quality level
        QualitySettings.SetQualityLevel(qualityDropdown.value);

        // Save the settings after applying
        SaveSettings();
    }

    // Reset to default values
    public void ResetToDefaults()
    {
        masterVolumeSlider.value = 1f;
        musicVolumeSlider.value = 0.8f;
        sfxVolumeSlider.value = 0.8f;
        resolutionDropdown.value = GetDefaultResolutionIndex();
        qualityDropdown.value = 2;
        fullscreenToggle.isOn = true;

        // Apply default settings
        ApplySettings();
    }

    // Get the index of the current resolution
    private int GetCurrentResolutionIndex(Resolution[] resolutions)
    {
        Resolution currentResolution = Screen.currentResolution;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }
        return 0; // Default if no matching resolution is found
    }

    // Get the default resolution index (for the default or current resolution)
    private int GetDefaultResolutionIndex()
    {
        Resolution[] resolutions = Screen.resolutions;
        return GetCurrentResolutionIndex(resolutions);
    }
}