using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.Windows;

public class Visualizer : MonoBehaviour
{
    [SerializeField] private Image _pokeImg;
    [SerializeField] private TextMeshProUGUI _pokeText;

    [SerializeField] private StatsDisplay _statsDisplay;

    private Pokemon _visualizedPoke;

    public bool SetVisualizedPokemon(Pokemon pokemon)
    {
        Debug.Log("wtf is going on");
        Pokemon oldPoke = _visualizedPoke;
        _visualizedPoke = pokemon;

        string imgPath = $"Images/{_visualizedPoke.id.ToString("000")}";
        Debug.Log("Visualizer attempting to load image at path: " + imgPath);
        /*
        Texture2D pokeTex = Resources.Load<Texture2D>(imgPath);
        Debug.Log(pokeTex == null);
        Rect rec = new Rect(0, 0, pokeTex.width, pokeTex.height);
        _pokeImg.sprite = Sprite.Create(pokeTex, rec, new Vector2(0, 0), 1);
        */

        Sprite pokeSprite = Resources.Load<Sprite>(imgPath);
        Debug.Log($"Image Loaded Successfully: {pokeSprite != null}");
        _pokeImg.sprite = pokeSprite;

        _pokeText.text = _visualizedPoke.name.english;

        _statsDisplay.SetStatDisplay(pokemon.basestats);

        return _visualizedPoke != oldPoke;
    }
}
