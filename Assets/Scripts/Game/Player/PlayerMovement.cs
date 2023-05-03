using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    // fields required for the player movement
    private GameObject player;
    private Animator playerAnimator;
    private int currentLane;

    //obstacle collision
    public UnityEvent obstacleCollision;

    private void Start()
    {
        // init fields to default values
        player = gameObject;
        playerAnimator = player.GetComponentInChildren<Animator>();
        currentLane = 0;
        obstacleCollision = new UnityEvent();
        MainGameEvents.playerFall.AddListener(playerDeath);
    }

    private void Update()
    {
        // required if the player 'trips'
        resetPlayerAnimation();
    }

    // resets the animations of the player
    private void resetPlayerAnimation()
    {
        playerAnimator.SetBool("isRunning", true);
        playerAnimator.SetBool("isTripping", false);
        playerAnimator.SetBool("isSliding", false);
    }

    private void playerDeath()
    {
        playerAnimator.SetBool("isDead", true);
    }


    // player jump
    public void jump()
    {
        // check if the player is on the ground
        if (transform.position.y < 0.3)
        {
            GameManager._instance.GetComponent<AudioManager>().jumpSound();

            // get the player's Rigidbody component
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();

            playerRigidbody.AddForce(Vector3.up * 32, ForceMode.Impulse);
        }
    }

    // player duck
    public void duck()
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

    // handles the functionality for the player sliding (if the player is already on the ground)
    private void playerSlide()
    {

        // set the slide animation
        playerAnimator.SetBool("isSliding", true);

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
        playerAnimator.SetBool("isTripping", true);
        MainGameEvents.playerTrip.Invoke();
    }

    // obstacle detection
    void OnCollisionEnter(Collision targetObj)
    {
        if (targetObj.gameObject.tag == "obstacle")
        {
            MainGameEvents.fullObstacleCollision.Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            GameManager._instance.GetComponent<AudioManager>().coinSound();
            MainGameEvents.coinCollected.Invoke();
            Debug.Log("coin collided");
        }
    }

}
