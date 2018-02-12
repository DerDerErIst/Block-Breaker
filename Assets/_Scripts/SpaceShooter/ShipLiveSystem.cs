using System;
using UnityEngine;
using UnityEngine.UI;

public class ShipLiveSystem : MonoBehaviour
{
    public GameObject endCondition;

    public Image hullImage;    

    public GameObject explosion;
    public float maxHullPoints;

    [Header("Leave This Empty")]
    public float hullPoints;

    public bool gameRunning = true;

    void Awake()
    {
        gameRunning = true;
        if (endCondition != null)
        {
            endCondition.SetActive(false);
        }
        hullPoints = maxHullPoints;
        if(hullImage != null)
        {
            hullImage.fillAmount = hullPoints / maxHullPoints;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        hullPoints -= damage;
        if(hullImage != null)
        {
            hullImage.fillAmount = hullPoints / maxHullPoints;
        }
        if(hullPoints <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        gameRunning = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        DeactivateGame();
        SavePlayerData();
        endCondition.SetActive(true);
        Debug.Log("Happen Die");
    }

    void DeactivateGame()
    {   //We Need to Deactivate the Player because we using the UI System on PlayerObject
        ShipController controller = GetComponent<ShipController>();
        controller.enabled = false;
        ShipAbilitySystem ability = GetComponent<ShipAbilitySystem>();
        ability.enabled = false;
        Collider col = GetComponent<Collider>();
        col.enabled = false;
        MeshRenderer[] renderer = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderer.Length; i++)
        {
            renderer[i].enabled = false;
        }
        //Deactivate the Asteroid Controller to prevent System from Spawning more Asteroids
        AsteroidController[] asteroidController = FindObjectsOfType<AsteroidController>();
        for (int i = 0; i < asteroidController.Length; i++)
        {
            asteroidController[i].gameObject.SetActive(false);
        }
    }

    public void SavePlayerData()
    {   //We Saving the Data now when the Level is done and not anymore when the next Level get loaded.
        PlayerSceneManager playerManager = FindObjectOfType<PlayerSceneManager>();
        //Set Asteroids and Reset (No Display Update to see in Scene the Values)
        FindObjectOfType<DifficultyIncreaser>().CheckForHighscoreCondition();       

        if (playerManager.destroyedAsteroidsInRow <= playerManager.actualAsteroids)
        {
            playerManager.destroyedAsteroidsInRow = playerManager.actualAsteroids;
        }
        playerManager.destroyedAsteroids += playerManager.actualAsteroids;
        playerManager.actualAsteroids = 0;
        AccountDetailRequest.accReq.SaveRaiderData();

        //Set Currency and Reset (No Display Update to see in Scene the Values)
        playerManager.spacebricksCurrency = playerManager.earnedSpaceBricks;
        AccountDetailRequest.accReq.SaveCashData();
        playerManager.earnedSpaceBricks = 0;
    }

    public void Restart(string restart)
    {   //We Can Restart the Scene from UI
        FindObjectOfType<LevelManager>().LoadInvaderLevel(restart);
    }

    public void Exit()
    {   //We Can Exit the Scene to Main from UI        
        FindObjectOfType<LevelManager>().LoadLevelStartWithReset();
    }
}
