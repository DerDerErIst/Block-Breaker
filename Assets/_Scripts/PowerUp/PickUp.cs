using UnityEngine;

public class PickUp : MonoBehaviour {

    public PowerUp powerUp;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Paddle>())
        {
            return;
        }
        else if (collision.GetComponent<Paddle>())
        {
            powerUp.Use();
            Destroy(this);
        }
    }
}
