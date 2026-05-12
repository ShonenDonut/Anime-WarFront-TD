using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    [Header("Music Clips")]
    public AudioClip mainMenuMusic;
    public AudioClip forestMusic;
    public AudioClip desertMusic;
    public AudioClip cityMusic;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1f);
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    private void PlayMusicForScene(string sceneName)
    {
        AudioClip selectedClip = mainMenuMusic;

        if (sceneName == "Gameplay_Forest")
            selectedClip = forestMusic;
        else if (sceneName == "Gameplay_Desert")
            selectedClip = desertMusic;
        else if (sceneName == "Gameplay_City")
            selectedClip = cityMusic;
        else if (sceneName == "MainMenu" || sceneName == "MapSelect" || sceneName == "ShopMenu" || sceneName == "UnitsMenu")
            selectedClip = mainMenuMusic;

        if (selectedClip == null || audioSource == null)
            return;

        if (audioSource.clip == selectedClip && audioSource.isPlaying)
            return;

        audioSource.clip = selectedClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}