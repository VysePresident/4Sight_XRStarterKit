using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;

public class TakeScreenshot : MonoBehaviour
{
    public Button screenshotButton;
    public TextMeshProUGUI message;

    public void Start() 
    {
       message = screenshotButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
       message.enabled = false;
    }

    public void Update() 
    {
        
    }

    public void StartScreenshot()
    {
        StartCoroutine(screenShotCoroutine());
    }

    /*
    For iOS builds make sure you have Scripting Backend set to IL2CPP and Architecture set to Universal in Unity Build Settings.

    For Android builds Write Access needs to be set to External (SDCard) to allow saving of images, and Build System set to Gradle. A minimum API level of 16 and target API level of 27 was used during testing.
    */
    IEnumerator screenShotCoroutine()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        //Convert to png
        byte[] imageBytes = screenImage.EncodeToPNG();

        //Save image to gallery
        String name = "Img" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

        message.enabled = true;
        Invoke("HideText", 1f);
        NativeGallery.SaveImageToGallery(imageBytes, "Furniture", name, null);
        
        /*
        string folderPath = Directory.GetCurrentDirectory() + "/Screenshots/";
 
         if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        ScreenCapture.CaptureScreenshot(Path.Combine(folderPath, name));

        Debug.Log(Path.Combine(folderPath, name));*/

    }

    void HideText() 
    {
        message.enabled = false;
    }

}