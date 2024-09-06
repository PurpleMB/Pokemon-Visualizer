using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PokeJsonInterpreter))]
public class PokemonDatabase : Database<Pokemon>
{
    private PokeJsonInterpreter _pokeJson;

    protected override void fillDics()
    {
        _pokeJson = GetComponent<PokeJsonInterpreter>();

        _nameDict.Clear();
        _idDict = new List<Pokemon>();
        foreach (Pokemon poke in _pokeJson.PokeList)
        {
            _nameDict.Add(poke.name.english.ToLower(), poke);
            _idDict.Add(poke);
        }
    }
}