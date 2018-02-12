using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject optionUI;

    LevelManager levelManager;
    AudioSource[] allAudioSources;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        optionUI.SetActive(false);
    }
    void Update()
    {
        //Only for PC Version, Mobile Devices need to Use the Pause Button in ScreenView
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenue();
        }
    }

    public void ExitToLose()
    {
        Time.timeScale = 1f;

        //We Ask in what level we are to Save Datas to the Cloud if we Exit
        if(PlayerSceneManager.playerManager.raiderLevel)
        {
            FindObjectOfType<ShipLiveSystem>().SavePlayerData();
        }
        if (PlayerSceneManager.playerManager.breakerLevel)
        {
            AccountDetailRequest.accReq.SaveBrickData();
        }
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadLevelStartWithReset();    
    }

    public void OpenMenue()
    {
        optionUI.SetActive(!optionUI.activeSelf);
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
        if (!optionUI.activeSelf)
        {
            StartAudio();
            if (PlayerSceneManager.playerManager.breakerLevel)
            {
                Cursor.visible = false;
            }
            Time.timeScale = 1f;
        }
        else if (optionUI.activeSelf)
        {
            StopAudio();
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }
}
