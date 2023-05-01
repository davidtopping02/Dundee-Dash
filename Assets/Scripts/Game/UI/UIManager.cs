using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;


    // Start is called before the first frame update
    void Start()
    {
    }

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
