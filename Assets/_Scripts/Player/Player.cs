using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public int brickCounter;
    public int score;
    public int highscore;

    public string playerName;
}
