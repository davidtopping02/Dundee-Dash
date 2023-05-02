using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;


    // Update is called once per frame
    void Update()
    {
        updateScoreText();
    }

    private void updateScoreText()
    {
        coinText.text = GameManager._instance.playerStats.getCoins().ToString();
        scoreText.text = GameManager._instance.playerStats.getCurrentScore().ToString();
    }
}
