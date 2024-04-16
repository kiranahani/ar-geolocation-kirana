using UnityEngine;
using UnityEngine.UI;

public class SwipeLeftDetection : MonoBehaviour
{

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;


    public float swipeDistanceThreshold = 50f;

    public Button leftButton;


    void Update()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Began)
            {

                touchStartPos = touch.position;
            }


            if (touch.phase == TouchPhase.Ended)
            {
 
                touchEndPos = touch.position;

                Vector2 swipeDirection = touchEndPos - touchStartPos;
                float swipeDistance = swipeDirection.magnitude;

                if (swipeDistance > swipeDistanceThreshold && swipeDirection.x < 0)
                {

                    if (leftButton != null)
                    {

                        leftButton.onClick.Invoke();
                    }
                }
            }
        }
    }
}
