using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Screenshotter : MonoBehaviour
{
    [SerializeField] private RectTransform _imgRect;
    [SerializeField] private Image _bg;
    [SerializeField] private Visualizer _visualizer;

    public void ExportPokemonVisual()
    {
        StartCoroutine(CoroutineScreenshot());
    }

    private IEnumerator CoroutineScreenshot()
    {
        _bg.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        float widthMult = Screen.width / 1920.0f;
        float heightMult = Screen.height / 1080.0f;

        int imgWidth = Mathf.RoundToInt(_imgRect.rect.width * widthMult);
        int imgHeight = Mathf.RoundToInt(_imgRect.rect.height * heightMult);
        Texture2D screenshotTex = new Texture2D(imgWidth, imgHeight, TextureFormat.ARGB32, false);

        float leftBound = Screen.width - (545 * widthMult) - (1020 / 2.0f * widthMult); 
        float bottomBound = 40.0f * heightMult;
        Rect rect = new Rect(leftBound, bottomBound, imgWidth, imgHeight);
        screenshotTex.ReadPixels(rect, 0, 0);
        screenshotTex.Apply();

        byte[] byteArray = screenshotTex.EncodeToPNG();
        //System.IO.File.WriteAllBytes(Application.dataPath + "/TestPokemon.png", byteArray);

        var path = EditorUtility.SaveFilePanel("Export visual as PNG",
            "", _visualizer.GetVisualizedPokemonName()  + "Graph.png", "png");
        if(path != null)
        {
            System.IO.File.WriteAllBytes(path, byteArray);
            Debug.Log("Picture taken");
        }
        _bg.gameObject.SetActive(true);
    }
}
