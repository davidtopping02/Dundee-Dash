using LootLocker.Requests;
using System.Collections;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private int leaderboardID;
    private string playerNames;
    private string playerScores;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the leaderboard ID
        leaderboardID = 13754;
    }

    // This method logs in the player to the LootLocker server
    public void loginToOnlineServices()
    {
        StartCoroutine(LoginRoutine());
    }

    // This coroutine sets the player's name
    public IEnumerator setPlayerName(string playerName)
    {
        bool done = false;

        // Call the LootLocker SDK's SetPlayerName method to set the player's name
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

        // Wait until the name change is done
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

        yield return new WaitWhile(() => done == false);

        yield return getTopHighScores();

        // Call getTopHighScores() every 10 seconds
        while (true)
        {
            yield return new WaitForSeconds(10);
            yield return getTopHighScores();
        }
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
                Debug.Log("score uploaded");
            }
            else
            {
                Debug.Log("failed to upload score");
            }
            done = true;
        });

        // Wait until the score submission is done
        yield return new WaitWhile(() => done == false);
    }

    // This coroutine gets the top high scores from the leaderboard
    public IEnumerator getTopHighScores()
    {
        bool done = false;

        // Call the LootLocker SDK's GetScoreListMain method to get the top high scores from the leaderboard
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
