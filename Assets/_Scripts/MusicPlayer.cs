using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    #region Singleton
    static MusicPlayer instance = null;

    public AudioMixer audioMixer;
    public AudioClip[] soundtrack;

    public AudioSource audioSource;

    private void Awake()
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
    }
    #endregion

    private void Start()
    {
        SetAllVolume();
        audioSource = GetComponent<AudioSource>();        
        if (!audioSource.playOnAwake)
        {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
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
