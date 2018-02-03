using UnityEngine;
using TMPro;

public class DisplayPlayerName : MonoBehaviour {

    PlayerManager playerManager;
    // Use this for initialization
    void Start ()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText("Welcome " + playerManager.player.playerName);
    }
	

}
