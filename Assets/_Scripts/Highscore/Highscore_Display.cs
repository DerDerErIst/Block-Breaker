using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore_Display : MonoBehaviour {

    public Text outputData;
    public Text entryCount;

    public void Start()
    {
        //GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("HIGHSCORE")
            .SetEntryCount(int.Parse(entryCount.text)) // we need to parse this text input, since the entry count only takes long
            .Send((response) => {

                if (!response.HasErrors)
                {
                    Debug.Log("Found Leaderboard Data...");
                    outputData.text = System.String.Empty; // first clear all the data from the output
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string name = entry.UserName;
                        string score = entry.JSONData["SCORE"].ToString(); // we need to get the key, in order to get the score
                        outputData.text += rank + "  Name" + name + "   Score:" + score + "\n"; // addd the score to the output text
                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }
}
