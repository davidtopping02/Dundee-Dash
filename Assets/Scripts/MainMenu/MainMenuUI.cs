using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;


    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + GameManager._instance.playerStats.getHighScore();
    }
}
