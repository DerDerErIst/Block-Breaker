using UnityEngine;
using TMPro;

public class DisplayPlayerName : MonoBehaviour {

    PlayerSceneManager playerManager;
    // Use this for initialization
    void Start ()
    {
        playerManager = FindObjectOfType<PlayerSceneManager>();
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText("Welcome " + playerManager.playerName);
    }
	

}
