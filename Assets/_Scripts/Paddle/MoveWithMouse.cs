using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
	void Update ()
    {
        MouseMove();
	}

    void MouseMove()
    {
        //We Move the Paddle with the Mouse from Left to Ride and Clamp the Position this also works on Mobile Devices
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 20;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 20f);
        this.transform.position = paddlePos;
    }
}
