using UnityEngine;
using UnityEngine.UI;

public class MasterVolSlider : MonoBehaviour
{
    public Slider masterVol;

    // Start is called before the first frame update
    void Start()
    {
        masterVol.value = GameManager._instance.GetComponent<AudioManager>().getMasterVol();
    }

    public void updateMasterVol()
    {
        GameManager._instance.GetComponent<AudioManager>().changeMasterVol(masterVol.value);
    }

}
