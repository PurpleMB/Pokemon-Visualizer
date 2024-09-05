using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenshotTex = new Texture2D(0, 0);
    }
}
