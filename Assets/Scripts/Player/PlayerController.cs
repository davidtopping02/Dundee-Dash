using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // rate of movement through the game
    public static float moveSpeed;

    // player components
    public GameObject player;
    private Animator animator;
    private int currentLane;
    private double playerHealth;
    public int playerScore;
    public TextMeshProUGUI scoreText;

    // Stopwatch for the player's score
    public Stopwatch gameStopWatch;

    private void Start()
    {
        gameStopWatch = new Stopwatch();
        playerHealth = 1;
        playerScore = 0;
        currentLane = 0;
        moveSpeed = 30;
        animator = player.GetComponentInChildren<Animator>();

    }

    void Update()
    {
        // required if the player 'trips'
        resetPlayerAnimation();


        updatePlayerScore();

        // broadcast player dead
        if (playerHealth <= 0)
        {
            // reset game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


    private void updatePlayerScore()
    {
        playerScore += Mathf.RoundToInt(gameStopWatch.GetElapsedTime() * 3);
        scoreText.text = playerScore.ToString();

        Debug.Log(playerScore);
    }

    // resets the animations of the player
    private void resetPlayerAnimation()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isTripping", false);
        animator.SetBool("isSliding", false);
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
     * Helper functions called on swipe events
     */

    public void jump()
    {
        // check if the player is on the ground
        if (transform.position.y < 0.3)
        {
            // get the player's Rigidbody component
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();

            playerRigidbody.AddForce(Vector3.up * 28, ForceMode.Impulse);
            //playerRigidbody.AddForce(Vector3.down * 10f, ForceMode.Impulse);
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
            playerSlide();
        }
    }

    // handles the functionality for the player sliding
    private void playerSlide()
    {

        // set the slide animation
        animator.SetBool("isSliding", true);

        // change the capsule collider to the correct height
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.height = 1.2f;
        capsuleCollider.center = new Vector3(0, 0.8f, 0.2f);

        // change the capsule collider back to the correct size
        StartCoroutine(changeCrouchCollider(capsuleCollider));
    }

    // change the capsule collider to the correct size after a set period of time
    IEnumerator changeCrouchCollider(CapsuleCollider capsuleCollider)
    {
        yield return new WaitForSeconds(0.5f);
        capsuleCollider.height = 3.5f;
        capsuleCollider.center = new Vector3(0, 01.75f, 0.2f);
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
            transform.position = new Vector3(currentLane * 5f, transform.position.y, transform.position.z);
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
            transform.position = new Vector3(currentLane * 5f, transform.position.y, transform.position.z);

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
        yield return new WaitForSeconds(delay);
        playerHealth = 1;
    }

}
