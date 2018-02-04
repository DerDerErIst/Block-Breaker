using UnityEngine;

public class MobileBallLauncher : MonoBehaviour {

    public GameObject buttonLaunch;

    Ball ballInstance;

    void Start()
    {
        Ball.onMobile += SetBallInstance; // Listener to the Ball
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
        ballInstance = FindObjectOfType<Ball>();
        if (ballInstance.hasStarted)
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
