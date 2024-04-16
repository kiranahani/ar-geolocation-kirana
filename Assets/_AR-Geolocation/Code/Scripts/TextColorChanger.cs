using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextColorChanger : MonoBehaviour
{
    public TMP_Text textComponentPhoto;
    public TMP_Text textComponentVideo;
    public Color targetColorPhoto;
    public Color targetColorVideo;

    void Start()
    {
        // Assuming you have a Button component attached to this GameObject
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeColor);
    }

    void ChangeColor()
    {
        // Change the color of the text
        textComponentPhoto.color = targetColorPhoto;
        textComponentVideo.color = targetColorVideo;
    }
}
