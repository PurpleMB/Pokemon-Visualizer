using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeInputField : MonoBehaviour
{
    [SerializeField] private Visualizer _visualizer;

    public void OnPokemonEntered(string name)
    {
        Debug.Log(name.ToLower());
        if (_visualizer != null)
        {
            if(!_visualizer.VisualizePokemon(name.ToLower()))
            {
                //TODO: Behavior for when pokemon input is invalid
            }
        }
    }
}
