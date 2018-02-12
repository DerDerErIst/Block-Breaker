using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    public Vector3 newPos;
    public float moveSpeed;

	void Update ()
    {
        MouseMove();
	}

    void MouseMove()
    {
        newPos.x += Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
        newPos.y += Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -7.5f, 7.5f);
        newPos.y = Mathf.Clamp(newPos.y, 0, 0);
        gameObject.transform.localPosition = newPos;

        /*//We Move the Paddle with the Mouse from Left to Ride and Clamp the Position this also works on Mobile Devices
        Vector3 paddlePos = new Vector3(0f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition();
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, -8f, 8f);
        this.transform.position = paddlePos;*/
    }
}
