using System;
using System.Collections;
using UnityEngine;

public class Screenshots : MonoBehaviour
{
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(TakeScreenShot());
        }
    }
    
    private static IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();

        var filename = $"tower-defence-{DateTime.Now:MM-dd-yy (HH-mm-ss)}.png";
        ScreenCapture.CaptureScreenshot(filename);
        Debug.Log($"Screen shot '{filename}' has been taken");
    }
}
