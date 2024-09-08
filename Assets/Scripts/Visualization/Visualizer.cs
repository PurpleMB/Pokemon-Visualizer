using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    [SerializeField] private PokemonDatabase _pokemonDb;
    [SerializeField] private MoveDatabase _moveDb;
    [SerializeField] private TypeDictionary _typeDic;

    [SerializeField] private BasicDisplay _basicDisplay;
    [SerializeField] private StatsDisplay _statsDisplay;
    [SerializeField] private TypeDisplay _typeDisplay;
    [SerializeField] private MatchupDisplay _matchupDisplay;
    [SerializeField] private BackgroundDisplay _backgroundDisplay;

    [SerializeField] private MoveDisplay _moveDisplay;

    [SerializeField] private TextMeshProUGUI _debugText;
    [SerializeField] private Color _errorMsgCol;
    [SerializeField] private string _invalidPokeMsg;
    [SerializeField] private string _invalidMoveMsg;

    private Pokemon _visualizedPoke;

    private void Start()
    {
        VisualizePokemon("???");
        for (int i = 0; i < 4; i++)
        {
            VisualizeMove("---", i);
        }
    }

    public string GetVisualizedPokemonName()
    {
        if(_visualizedPoke == null)
        {
            return "NoPokemonSelected";
        }
        return _visualizedPoke.name.english;
    }

    public bool VisualizePokemon(string pokemonName)
    {
        Pokemon identifiedPoke = _pokemonDb.LookupByName(pokemonName);
        if (identifiedPoke != null)
        {
            setVisualizedPokemon(identifiedPoke);
            return true;
        }
        _debugText.text = _invalidPokeMsg;
        _debugText.color = _errorMsgCol;
        setVisualizedPokemon(_pokemonDb.LookupByName("???"));
        return false;   
    }

    public bool VisualizePokemon(int pokemonId) 
    {
        Pokemon identifiedPoke = _pokemonDb.LookupById(pokemonId);
        if (identifiedPoke != null)
        {
            setVisualizedPokemon(identifiedPoke);
            return true;
        }
        return false;
    }

    private void setVisualizedPokemon(Pokemon pokemon)
    {
        if (pokemon == null) { return; }
        _visualizedPoke = pokemon;
        TypeSO primType = null, secType = null;
        _typeDic.LookupPokemomTypes(_visualizedPoke,ref primType,ref secType);

        _basicDisplay.SetBasicDisplay(pokemon);
        _statsDisplay.SetStatDisplay(pokemon.basestats);
        _typeDisplay.SetDisplayedTyping(primType, secType);
        _matchupDisplay.DisplayMatchup(primType, secType);
        _backgroundDisplay.SetBackgroundByType(primType, secType);
    }

    public bool VisualizeMove(string moveName, int slot) 
    {
        Move identifiedMove = _moveDb.LookupByName(moveName);

        if (identifiedMove != null)
        {
            setVisualizedMove(identifiedMove, slot);
            return true;
        }
        _debugText.text = _invalidMoveMsg;
        _debugText.color = _errorMsgCol;
        setVisualizedMove(_moveDb.LookupByName("???"), slot);
        return false;
    }

    private void setVisualizedMove(Move move, int slot)
    {
        if(move == null || slot < 0 || slot > 3) { return; }
        Debug.Log("Visualizer: Attempting to visualize move: " + move.ename);
        TypeSO moveType = _typeDic.LookupType(move.type);
        _moveDisplay.DisplayMoveInSlot(move, moveType, slot);
    }
}
