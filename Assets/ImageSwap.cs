using UnityEngine;
using UnityEngine.UI;

public class ImageSwap : MonoBehaviour
{
    // Variables to store touch positions
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    // Minimum distance for a swipe to be recognized
    public float swipeDistanceThreshold = 50f;

    public Button leftButton;
    public RawImage swipeArea; // Reference to the RawImage component of the swipe area

    // Update is called once per frame
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if touch is within the swipe area
            if (RectTransformUtility.RectangleContainsScreenPoint(swipeArea.rectTransform, touch.position))
            {
                // Check if touch began
                if (touch.phase == TouchPhase.Began)
                {
                    // Store the touch position
                    touchStartPos = touch.position;
                }

                // Check if touch ended
                if (touch.phase == TouchPhase.Ended)
                {
                    // Store the end touch position
                    touchEndPos = touch.position;

                    // Calculate the swipe direction and distance
                    Vector2 swipeDirection = touchEndPos - touchStartPos;
                    float swipeDistance = swipeDirection.magnitude;

                    // Check if swipe distance is greater than threshold and swipe direction is left
                    if (swipeDistance > swipeDistanceThreshold && swipeDirection.x < 0)
                    {
                        // Check if the leftButton is assigned
                        if (leftButton != null)
                        {
                            // Simulate a button click
                            leftButton.onClick.Invoke();
                        }
                    }
                }
            }
        }
    }
}