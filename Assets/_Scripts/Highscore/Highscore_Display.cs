using UnityEngine;
using UnityEngine.UI;

public class Highscore_Display : MonoBehaviour
{
    public GameObject rankingPanel;
    public GameObject outputData;

    public Text breakerHighscore;
    public Text breakerOverallScore;
    public Text breakerBricks;

    public Text killStreak;
    public Text asteroids;
    public Text difficult;
    public Text normalShip;
    public Text doubleShip;
    public Text strongShip;

    string entryCount = "50";

    RankingPanel[] inPanel;

    void Start()
    {
        GetBreakerScore();
    }

    public void SaveTestData()
    {
        AccountDetailRequest.accReq.SaveBrickData();
        AccountDetailRequest.accReq.SaveRaiderData();
    }

    public void GetBreakerScore()
    {
        breakerHighscore.text = PlayerSceneManager.playerManager.breakerHighscore.ToString();
        breakerOverallScore.text = PlayerSceneManager.playerManager.breakerOverallScore.ToString();
        breakerBricks.text = PlayerSceneManager.playerManager.destroyedBricks.ToString();
    }

    public void GetRaiderScore()
    {
        killStreak.text = PlayerSceneManager.playerManager.destroyedAsteroidsInRow.ToString();
        asteroids.text = PlayerSceneManager.playerManager.destroyedAsteroids.ToString();
        difficult.text = PlayerSceneManager.playerManager.highestDifficultInRaider.ToString();
        normalShip.text = PlayerSceneManager.playerManager.longestTimeInRaiderWithNormal.ToString();
        doubleShip.text = PlayerSceneManager.playerManager.longestTimeInRaiderWithDouble.ToString();
        strongShip.text = PlayerSceneManager.playerManager.longestTimeInRaiderWithStrong.ToString();
    }

    public void SetEntryFifty()
    {
        entryCount = "50";
    }
    public void SetEntryHundred()
    {
        entryCount = "100";
    }


    public void ClearPanel()
    {
        inPanel = FindObjectsOfType<RankingPanel>();
        for (int i = 0; i < inPanel.Length; i++)
        {
            Destroy(inPanel[i].gameObject);
        }
        //Debug.Log("Data Cleared");
    }

    public void GetPlayerHighscore()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("BREAKER_HIGHSCORE")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-HIGHSCORE"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetAsteroidsInRow()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("RAIDER_ASTEROIDS_INROW")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-ASTEROIDS_DESTROYED_INROW"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetAsteroids()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("RAIDER_ASTEROIDS")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-ASTEROIDS_DESTROYED"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetDifficult()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("RAIDER_DIFFICULT")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-HIGHEST_DIFFICULT"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else


                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetDoubleShipTime()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("RAIDER_DOUBLETIME")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-TIME_DOUBLE"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetNormalShipTime()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("RAIDER_NORMALTIME")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-TIME_NORMAL"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetStrongShipTime()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("RAIDER_STRONGTIME")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-TIME_STRONG"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetBricks()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("BREAKER_BRICKS")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-BRICK"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    public void GetOverallScore()
    {
        ClearPanel();
        //Debug.Log("Fetching Leaderboard Data...");

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("BREAKER_OVERALLSCORE")
            .SetEntryCount(int.Parse(entryCount)) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");
                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        int rank = (int)entry.Rank; // we can get the rank directly
                        string playerName = entry.UserName;
                        string score = entry.JSONData["MAX-SCORE_ALL"].ToString(); // we need to get the key, in order to get the score
                        GameObject Panel = Instantiate(rankingPanel);
                        RankingPanel panel = Panel.GetComponent<RankingPanel>();
                        panel.rankText.text = rank.ToString();
                        panel.nameText.text = playerName;
                        panel.scoreText.text = score;
                        Panel.transform.SetParent(outputData.transform);
                    }
                }
                else

                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }
}
