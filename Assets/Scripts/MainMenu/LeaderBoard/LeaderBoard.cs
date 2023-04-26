using LootLocker.Requests;
using System.Collections;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private int leaderboardID;
    private string playerNames;
    private string playerScores;


    void Start()
    {
        // developing
        leaderboardID = 13754;

        // live
        //leaderboardID = 13756;
    }

    public void loginToOnlineServices()
    {
        StartCoroutine(LoginRoutine());
    }

    public IEnumerator setPlayerName(string playerName)
    {

        bool done = false;

        LootLockerSDKManager.SetPlayerName(playerName, (response) =>
        {
            if (response.success)
            {
                Debug.Log("succesfully set the player name");
                done = true;
            }
            else
            {
                Debug.Log("name change failed" + response.Error);
            }
            done = true;
        });

        // Wait until the login is done
        yield return new WaitWhile(() => done == false);
    }

    // This coroutine logs in the player to the LootLocker server and saves the player's ID as a PlayerPrefs
    public IEnumerator LoginRoutine()
    {
        bool done = false;

        // Call the LootLocker SDK's StartGuestSession method to start a guest session
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                // Log a success message
                Debug.Log("succesful login");

                // Save the player's ID as a PlayerPrefs
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                // Log a failure message
                Debug.Log("login failed");
                done = true;
            }
        });

        // Wait until the login is done
        yield return new WaitWhile(() => done == false);

        yield return getTopHighScores();
    }


    // This coroutine submits the player's score to the leaderboard
    public IEnumerator SubmitScore(int scoreToUpload)
    {
        bool done = false;

        // Get the player's ID from PlayerPrefs
        string playerID = PlayerPrefs.GetString("PlayerID");


        // Call the LootLocker SDK's SubmitScore method to submit the score to the leaderboard
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
        {
            if (response.success)
            {
                // Log a success message
                Debug.Log("score uploaded");
            }
            else
            {
                // Log a failure message
                Debug.Log("failed to upload score");
            }
            done = true;
        });

        // Wait until the score submission is done
        yield return new WaitWhile(() => done == false);
    }


    public IEnumerator getTopHighScores()
    {
        bool done = false;

        LootLockerSDKManager.GetScoreListMain(leaderboardID, 10, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }

                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";


                }


                playerNames = tempPlayerNames;
                playerScores = tempPlayerScores;

                Debug.Log("high scores retrieved succesfully");
                done = true;
            }
            else
            {
                Debug.Log("failed" + response.Error);
                done = true;
            }

        });


        yield return new WaitWhile(() => done == false);

    }

    public string PlayerNames
    {
        get { return playerNames; }
    }

    public string PlayerScores
    {
        get { return playerScores; }
    }
}
