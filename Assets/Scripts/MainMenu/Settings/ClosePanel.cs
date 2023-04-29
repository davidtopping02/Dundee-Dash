using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject canvas;

    public void closePanel()
    {
        canvas.SetActive(false);
    }
}
