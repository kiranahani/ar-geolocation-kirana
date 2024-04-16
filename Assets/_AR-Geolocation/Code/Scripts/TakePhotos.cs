using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class TakePhotos : MonoBehaviour
{
    // Call this in the button.
    public void TakePhoto()
    {
        StartCoroutine(TakeAPhoto());
    }

    IEnumerator TakeAPhoto()
    {
        // Wait until rendering is complete before taking the photo.
        yield return new WaitForEndOfFrame();

        Camera camera = Camera.main;
        int width = Screen.width;
        int height = Screen.height;
        // Create a new render texture the size of the screen.
        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture = rt;

        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;
        RenderTexture.active = rt;

        // Render the camera's view.
        camera.Render();

        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(width, height);
        image.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        image.Apply();

        // Change back the camera target texture.
        camera.targetTexture = null;

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;

        // Save to an image file.
        // Encode the image texture into PNG.
        byte[] bytes = image.EncodeToPNG();
        // Generate a unique file name based on date and time.
        string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

        // Create a folder with the name of the application if it doesn't exist.
        string folderPath = Path.Combine(Application.persistentDataPath, Application.productName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Combine the folder path with the file name.
        string filePath = Path.Combine(folderPath, fileName);

        // Write the bytes to the file.
        File.WriteAllBytes(filePath, bytes);

        // Save the image to the gallery.
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(filePath, "AR_Photo", fileName, (success, path) => {
            if (success)
            {
                Debug.Log("Image saved to gallery: " + path);
            }
            else
            {
                Debug.Log("Failed to save image to gallery");
            }
        });

        Debug.Log("Save image permission: " + permission);

        // Free up memory.
        Destroy(rt);
        Destroy(image);
    }
}
