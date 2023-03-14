using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject GroundTile;
    public GameObject EmptyTile;
    LinkedList<GameObject> allTiles = new LinkedList<GameObject>();
    GameObject currentTile;

    // Start is called before the first frame update
    void Start()
    {
        // spawns the initial tiles for the path
        for (int i = 0; i < 5; i++)
        {
            spawnTile();
        }
    }

    private GameObject newTile(Vector3 spawnCoordinates)
    {
        // randomly select one of the game tile objects
        return Instantiate(GroundTile, spawnCoordinates, Quaternion.identity);
    }

    // Spawns the next tile in the path
    public void spawnTile()
    {
        // spawns the very first tile
        if (currentTile == null)
        {
            //currentTile = newTile(new Vector3(0, 0, 0));
            currentTile = Instantiate(EmptyTile, new Vector3(0, 0, 0), Quaternion.identity);

        }
        else
        {
            currentTile = newTile(new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, currentTile.transform.position.z + 100));
        }

        allTiles.AddLast(currentTile);
    }

    // Deleted tile at the start of the list
    public void deleteTile()
    {
        GameObject tileToRemove = allTiles.First.Value;

        if (tileToRemove != null)
        {
            Destroy(tileToRemove, 2);
            allTiles.RemoveFirst();
        }
    }


}

