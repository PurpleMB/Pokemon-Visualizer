using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicDisplay : MonoBehaviour
{
    [SerializeField] private Image _pokeImg;
    [SerializeField] private TextMeshProUGUI _pokeText;

    public void SetBasicDisplay(Pokemon visualizedPoke)
    {
        string imgPath = $"Images/{visualizedPoke.id.ToString("000")}";
        Sprite pokeSprite = Resources.Load<Sprite>(imgPath);
        _pokeImg.sprite = pokeSprite;

        _pokeText.text = visualizedPoke.name.english;
    }
}
