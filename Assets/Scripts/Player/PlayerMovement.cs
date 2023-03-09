using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // rate of movement through the game
    public static float moveSpeed;

    // player components
    public GameObject player;
    private Animator animator;
    private int currentLane;
    private double playerHealth;

    private void Start()
    {
        playerHealth = 1;
        currentLane = 0;
        moveSpeed = 30;
        animator = player.GetComponentInChildren<Animator>();
        Debug.Log(player.transform.childCount);
    }

    void Update()
    {
        forwardsMovement();

        if (playerHealth <= 0)
        {
            // reset game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    // this moves the player forward at a constant rate
    void forwardsMovement()
    {
        // continiously moving the player forward
        animator.SetBool("isTripping", false);
        animator.SetBool("isSliding", false);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }



    // obstacle detection
    void OnCollisionEnter(Collision targetObj)
    {
        if (targetObj.gameObject.tag == "obstacle")
        {
            // resets the game when a collision is detected
            playerHealth -= 1;
        }
    }


    /*
     * Functions called on swipe events
     */
    public void jump()
    {
        // check if the player is on the ground
        if (transform.position.y < 0.3)
        {
            // get the player's Rigidbody component
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();

            playerRigidbody.AddForce(Vector3.up * 29f, ForceMode.Impulse);
            playerRigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
    }

    public void slide()
    {

        // check if the player is on the ground
        if (transform.position.y > 1)
        {
            // get the player's Rigidbody component
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();

            playerRigidbody.AddForce(Vector3.down * 11f, ForceMode.Impulse);
        }
        else
        {
            animator.SetBool("isSliding", true);

        }
    }

    public void moveLeft()
    {
        // checking the player is not in the left-most lane
        if (currentLane == 0 || currentLane == 1)
        {
            // reset the player health when moving lanes
            playerHealth = 1;

            // move the player to the left lane
            currentLane--;
            transform.position = new Vector3(currentLane * 3f, transform.position.y, transform.position.z);
        }
        else
        {
            playerTrip();
        }
    }

    public void moveRight()
    {
        // checking the player is not in the left-most lane
        if (currentLane == -1 || currentLane == 0)
        {
            // reset the player health when moving lanes
            playerHealth = 1;

            // move the player to the left lane
            currentLane++;
            transform.position = new Vector3(currentLane * 3f, transform.position.y, transform.position.z);

        }
        else
        {
            playerTrip();
        }
    }

    // animates the players trip and decrements health
    private void playerTrip()
    {
        playerHealth -= 0.5;
        animator.SetBool("isTripping", true);
        StartCoroutine(resetPlayerHealth(1));
    }

    // resets the players health after specified time
    IEnumerator resetPlayerHealth(float delay)
    {
        Debug.Log("here");
        yield return new WaitForSeconds(delay);
        playerHealth = 1;
    }

}
