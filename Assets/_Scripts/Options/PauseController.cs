using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject pauseCanvas;
    public GameObject pauseUI;
    public GameObject settingsUI;

    OptionsController controller;
    LevelManager levelManager;
    AudioSource[] allAudioSources;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        controller = GetComponent<OptionsController>();
    }

    void Update()
    {
        //Only for PC Version, Mobile Devices need to Use the Pause Button in ScreenView
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Activate");
            OpenMenue();
        }
    }

    public void ExitToStart()
    {
        Time.timeScale = 1f;
        levelManager.LoadLevel("01a Start Menu");    
    }

    public void OpenMenue()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        TimeScale();
    }

    private void StopAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
    private void StartAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Play();
        }
    }

    private void TimeScale()
    {
        if (!pauseCanvas.activeSelf)
        {
            StartAudio();
            controller.Save();
            if (settingsUI)
            {
                Cursor.visible = false;
                settingsUI.SetActive(false);
            }
            Time.timeScale = 1f;
        }
        else if (pauseCanvas.activeSelf)
        {
            StopAudio();
            if (pauseUI)
            {
                Cursor.visible = true;
                pauseUI.SetActive(true);
            }
            Time.timeScale = 0f;
        }
    }
}
