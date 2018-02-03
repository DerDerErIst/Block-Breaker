using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject {

    [Header("Start Here")]
    public GameObject pickUp;    

    public virtual void Use()
    {
    }
}
