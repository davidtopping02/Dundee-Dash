using UnityEngine;

/**
 * Swipe detection code was inspired from the following stack overflow thread
 * 
 * https://stackoverflow.com/questions/41491765/detect-swipe-gesture-direction
 */
public class SwipeDetector : MonoBehaviour
{
    // feilds for user input
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public float SWIPE_THRESHOLD = 10f;
    public bool detectSwipeOnlyAfterRelease = true;

    // player movement fields
    public GameObject player;
    private int currentLane = 0;


    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }

    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {

            // swipe up
            if (fingerDown.y - fingerUp.y > 0)
            {
                OnSwipeUp();
            }

            // swipe down
            else if (fingerDown.y - fingerUp.y < 0)
            {
                OnSwipeDown();
            }

            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            // swipe right
            if (fingerDown.x - fingerUp.x > 0)
            {
                OnSwipeRight();
            }

            //swipe left
            else if (fingerDown.x - fingerUp.x < 0)
            {
                OnSwipeLeft();
            }

            fingerUp = fingerDown;
        }
    }

    /**
     * Helper functions for the swipe checkers
     */
    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////

    // jump
    void OnSwipeUp()
    {
        Debug.Log("Swipe Up");

        // check if the player is on the ground
        if (player.transform.position.y == 1)
        {
            // get the player's Rigidbody component
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

            // consitent jump height
            float jumpHeight = 2.5f; // set the desired jump height in units
            float timeToJumpApex = Mathf.Sqrt(2 * jumpHeight / Physics.gravity.magnitude);
            float jumpVelocity = Mathf.Abs(Physics.gravity.y) * timeToJumpApex;
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, jumpVelocity, playerRigidbody.velocity.z);
        }
    }

    void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
    }


    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");

        // checking the player is not in the left-most lane
        if (currentLane == 0 || currentLane == 1)
        {
            // move the player to the left lane
            currentLane--;
            player.transform.position = new Vector3(currentLane * 2, player.transform.position.y, player.transform.position.z);
        }
    }

    void OnSwipeRight()
    {

        Debug.Log("Swipe Right");

        // checking the player is not in the left-most lane
        if (currentLane == -1 || currentLane == 0)
        {
            // move the player to the left lane
            currentLane++;
            player.transform.position = new Vector3(currentLane * 2, player.transform.position.y, player.transform.position.z);

        }
    }
}