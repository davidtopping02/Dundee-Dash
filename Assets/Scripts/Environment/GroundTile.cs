using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundGenerator groundGenerator;

    // Start is called before the first frame update
    void Start()
    {
        groundGenerator = GameObject.FindObjectOfType<GroundGenerator>();
    }

    private void OnTriggerExit(Collider other)
    {
        //spawns the next tile
        groundGenerator.spawnTile();

        //destroys the current tile 1 seconds after the player exits it
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
