using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    #region Singleton
    public static MusicPlayer instance = null;

    public AudioMixer audioMixer;
    [Header("MultiClipList")]
    public AudioClip[] soundtrackMenu;
    public AudioClip[] soundtrackBreaker;
    public AudioClip[] soundtrackRaider;
    [Header("Single Clips")]
    public AudioClip lostBreaker;
    public AudioClip wonBreaker;


    public bool isBreaker;
    public bool isRaider;
    public bool isBreakerLost;
    public bool isBreakerWon;
    public bool isMenue = true;

    AudioSource audioSource;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        audioSource = GetComponent<AudioSource>();
    }
    #endregion

    void OnEnable()
    {
        SceneManager.sceneLoaded += CheckMusic;
    }

    void CheckMusic(Scene arg0, LoadSceneMode arg1)
    {
        CheckForMusic();
    }

    void Start()
    {
        SetAllVolume();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            CheckForMusic();
        }
    }

    void CheckForMusic()
    {
        if (isMenue)
        {
            if (audioSource.isPlaying)
            {
                //TODO FadeOut the Music and go into the Soundtrack of the Game Part
                return;
            }
            else
            {
                audioSource.clip = soundtrackMenu[Random.Range(0, soundtrackMenu.Length)];
                audioSource.Play();
            }
        }
        else if (isBreaker)
        {
            if (audioSource.isPlaying)
            {
                return;
            }
            else
            {
                audioSource.clip = soundtrackBreaker[Random.Range(0, soundtrackBreaker.Length)];
                audioSource.Play();
            }
        }
        else if (isRaider)
        {
            if (audioSource.isPlaying)
            {
                return;
            }
            else
            {
                audioSource.clip = soundtrackRaider[Random.Range(0, soundtrackRaider.Length)];
                audioSource.Play();
            }
        }
        else if (isBreakerLost)
        {
            audioSource.Stop();
            audioSource.clip = lostBreaker;
            audioSource.Play();
        }
        else if (isBreakerWon)
        {
            audioSource.Stop();
            audioSource.clip = wonBreaker;
            audioSource.Play();
        }
    }

    void SetAllVolume()
    {
        audioMixer.SetFloat("masterVolume", PlayerPrefsManager.GetMasterVolume());
        audioMixer.SetFloat("musicVolume", PlayerPrefsManager.GetMusicVolume());
        audioMixer.SetFloat("effectVolume", PlayerPrefsManager.GetEffectVolume());
    }
}
