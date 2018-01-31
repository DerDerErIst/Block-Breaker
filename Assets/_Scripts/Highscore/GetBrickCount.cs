using UnityEngine;
using UnityEngine.UI;

using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using System.Collections.Generic;
using GameSparks.Core;

public class GetBrickCount : MonoBehaviour {

    Text brickCount;
    int count = 1;

    List<string> leaderboardEntries = new List<string>();

    // Use this for initialization
    void Start()
    {
        brickCount = GetComponent<Text>();

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("LOAD_BRICKS")
                .Send((response) => {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Recieved Player Data From GameSparks...");
                        GSData data = response.ScriptData.GetGSData("brick_Data");
                        brickCount.text = data.GetString("destroyedBricks");
                        print(data.GetString("destroyedBricks"));
                        print(data.GetString("playerID"));

                    }
                    else
                    {
                        Debug.Log("Error Loading Player Data...");
                    }
                });
    }
}
