using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PokeJsonInterpreter))]
public class PokemonDictionary : MonoBehaviour
{
    private PokeJsonInterpreter _pokeJson;

    public Dictionary<string, Pokemon> PokeNameDict = new Dictionary<string, Pokemon>();

    // Start is called before the first frame update
    private void Start()
    {
        _pokeJson = GetComponent<PokeJsonInterpreter>();
        foreach(Pokemon poke in _pokeJson.PokeList)
        {
            
            PokeNameDict.Add(poke.name.english,poke);
        }
        Debug.Log("Pokemon Dictionary size at Start: " + PokeNameDict.Count);
    }

    public Pokemon GetPokemon(string name)
    {
        return PokeNameDict[name];
    }

    public Pokemon GetPokemon(int id)
    {
        id = Mathf.Clamp(id, 1, _pokeJson.PokeList.Count());
        return _pokeJson.PokeList.ElementAt(id - 1);
    }
}