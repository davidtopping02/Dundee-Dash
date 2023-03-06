using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public static float moveSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

    }

    void OnCollisionEnter(Collision targetObj)
    {
        Debug.Log(targetObj.gameObject.name);
        if (targetObj.gameObject.tag == "obstacle")
        {

            // currently floor is a collision detection...
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
