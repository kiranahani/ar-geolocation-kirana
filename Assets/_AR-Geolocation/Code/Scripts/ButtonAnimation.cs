using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public GameObject targetObject;
    public string animationName;

    public void buttonPress()
    {
        if (targetObject != null)
        {
            Animation targetAnimation = targetObject.GetComponent<Animation>();
            if (targetAnimation != null)
            {
                targetAnimation.Play(animationName);
            }
            else
            {
                Debug.LogWarning("Target object does not have Animation component.");
            }
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
