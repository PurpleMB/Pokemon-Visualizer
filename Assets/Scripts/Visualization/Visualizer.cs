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
    [SerializeField] private TypeDisplay _typeDisplay;
    [SerializeField] private MatchupDisplay _matchupDisplay;

    private Pokemon _visualizedPoke;

    public void SetVisualizedPokemon(Pokemon pokemon)
    {   
        _visualizedPoke = pokemon;
        // TODO: Move this chunk into a BasicDispay or something
        string imgPath = $"Images/{_visualizedPoke.id.ToString("000")}";
        Debug.Log("Visualizer attempting to load image at path: " + imgPath);
        Sprite pokeSprite = Resources.Load<Sprite>(imgPath);
        Debug.Log($"Image Loaded Successfully: {pokeSprite != null}");
        _pokeImg.sprite = pokeSprite;

        _pokeText.text = _visualizedPoke.name.english;


        _statsDisplay.SetStatDisplay(pokemon.basestats);


        _typeDisplay.SetDisplayedTyping(pokemon.type);


        _matchupDisplay.DisplayMatchup(pokemon.type);
    }
}
