using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public Scene scenes;
}

public class HowToAudioClip : MonoBehaviour
{
    //If you not want to set that you can Set the AudioClip in the AudioSource and remove
    public AudioClip audioClip; //For Playing an Sound set in Inspector
    //remove this Part

    //You Need to Attach an AudioSource to the GameObject
    AudioSource audioSource; // We Need a Reference to the Audiosource to play the Sound

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Get the Audiosource on the Component this Script is Attached
    }

    //If You work with an Trigger Collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(audioClip); //Everytime the Collider with an Trigger on it he Play the AudioClip
        //for remove audioClip see Instruction at OnCollisionEnter2D
    }
    //if You work with an Collision Collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioSource.clip); //Everytime the Collider get an collision on it he Play the AudioClip
        //if you remove audioClip the you need to call the audioSource.clip
    }

}
