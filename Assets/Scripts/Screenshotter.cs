using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Screenshotter : MonoBehaviour
{
    [SerializeField] private RectTransform _imgRect;
    [SerializeField] private Image _bg;
    [SerializeField] private Visualizer _visualizer;
    [SerializeField] private TextMeshProUGUI _debugText;

    public void ExportPokemonVisual()
    {
        StartCoroutine(CoroutineScreenshot());
    }

    private IEnumerator CoroutineScreenshot()
    {
        if(_visualizer.GetVisualizedPokemonName() == "???")
        {
            _debugText.text = "Error: Please enter a pokemon to visualize first.";
            _debugText.color = Color.yellow;
            yield break;
        }

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

        //string path = Application.dataPath + _visualizer.GetVisualizedPokemonName() + "Graph.png";

        //string path = EditorUtility.SaveFilePanel("Export visual as PNG",
        //    "", _visualizer.GetVisualizedPokemonName()  + "Graph.png", "png");

#if !UNITY_WEBGL
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\PokeVisualizer";
        if(!System.IO.Directory.Exists(path))
        {
            var dir = System.IO.Directory.CreateDirectory(path);
        }
        path +=  "\\" + _visualizer.GetVisualizedPokemonName() + "Graph.png"; 
        if (path != null)
        {
            System.IO.File.WriteAllBytes(path, byteArray);
            _debugText.text = "Picture saved successfully! It will be in your Documents within a \"PokeVisualizer\" folder";
            _debugText.color = Color.green;
            Debug.Log("Picture taken");
        }
#else
        _debugText.text = "Warning: Currently the web build cannot properly export images.";
        _debugText.color = Color.yellow;
#endif
        _bg.gameObject.SetActive(true);
    }
}
