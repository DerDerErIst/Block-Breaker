using UnityEngine;

public class MobileBallLauncher : MonoBehaviour
{
    public GameObject buttonLaunch;

    Ball ballInstance;

    void Start()
    {
        Ball.onMobile += SetBallInstance; // Listener to the Ball
        //When the Delegate onMobile gets called this Script execute SetBallInstance
    }

    void OnDisable()
    {
        Ball.onMobile -= DeActivateButton;
    }

    public void ActivateButton()
    {
        buttonLaunch.SetActive(true);
    }
    public void DeActivateButton()
    {
        buttonLaunch.SetActive(false);
    }

    public void SetBallInstance()
    {
        ballInstance = FindObjectOfType<Ball>(); //TODO Find The Ball on Paddle
        if (ballInstance.hasStarted) //TODO Bug on Mobile when you go back to Main Menue and back into Game he not find the Ball
        {
            return;
        }
        else
        {
            ActivateButton();
        }
    }

    public void LaunchBall()
    {
        if (ballInstance.hasStarted == true)
        {
            return;
        }
        else
        {
            ballInstance.mobileStart = true;
            DeActivateButton();
        }
    }
}
