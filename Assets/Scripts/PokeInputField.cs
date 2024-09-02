using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeInputField : MonoBehaviour
{
    [SerializeField] private PokemonDictionary _pDic;
    [SerializeField] private Visualizer _visualizer;

    public void OnPokemonEntered(string ename)
    {
        if (_visualizer != null)
        {
            Pokemon identifiedPoke = _pDic.GetPokemon(ename);

            if (identifiedPoke != null)
            {
                Debug.Log("Input Field successfuly found " + identifiedPoke.name.english);
                if (_visualizer != null)
                {
                    _visualizer.SetVisualizedPokemon(identifiedPoke);
                }
            }
        }
    }
}
