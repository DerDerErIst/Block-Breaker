using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    #region Singleton
    static MusicPlayer instance = null;

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
}
