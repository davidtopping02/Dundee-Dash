using TMPro;
using UnityEngine;

public class ChangeNickName : MonoBehaviour
{
    public TMP_InputField newNickName;

    private void Start()
    {
        newNickName.placeholder.GetComponent<TMP_Text>().text = "Current: " + GameManager._instance.playerStats.getNickName();
    }

    public void submitBtnClick()
    {
        GameManager._instance.playerStats.setNickName(newNickName.text);
        newNickName.placeholder.GetComponent<TMP_Text>().text = "Current: " + GameManager._instance.playerStats.getNickName();
        newNickName.text = "";
        Debug.Log(newNickName.text);
    }
}
