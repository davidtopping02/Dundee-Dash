using UnityEngine;
using UnityEngine.Events;

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
    public bool controllsEnabled;

    private void Start()
    {
        controllsEnabled = true;
        MainGameEvents.pauseControlls.AddListener(pauseControls);
        MainGameEvents.unPauseControlls.AddListener(unpauseControlls);
    }


    private void pauseControls()
    {
        controllsEnabled = false;
    }

    private void unpauseControlls()
    {
        controllsEnabled = true;
    }



    void Update()
    {

        if (controllsEnabled)
        {
            // checks for user input each frame
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


    // swipe events 
    public UnityEvent swipeUp;
    public UnityEvent swipeDown;
    public UnityEvent swipeLeft;
    public UnityEvent swipeRight;

    void OnSwipeUp()
    {
        swipeUp.Invoke();
    }

    void OnSwipeDown()
    {
        swipeDown.Invoke();
    }
    void OnSwipeLeft()
    {
        swipeLeft.Invoke();
    }

    void OnSwipeRight()
    {
        swipeRight.Invoke();
    }

}