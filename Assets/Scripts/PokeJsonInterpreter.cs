using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeJsonInterpreter : MonoBehaviour
{
    [SerializeField] private TextAsset _pokejson;

    [System.Serializable]
    public class Name
    {
        public string english;
        public string japanese;
        public string chinese;
        public string french;
    }

    [System.Serializable]
    public class BaseStats
    {
        public int HP;
        public int Attack;
        public int Defense;
        public int SpecialAttack;
        public int SpecialDefense;
        public int Speed;
    }

    [System.Serializable]
    public class Pokemon
    {
        public int id;
        public Name name;
        public string[] type;
        public BaseStats basestats;
    }

    [System.Serializable]
    public class PokemonList
    {
        public Pokemon[] pokes;
    }

    public PokemonList pokeList = new PokemonList();

    // Start is called before the first frame update
    void Start()
    {
        pokeList = JsonUtility.FromJson<PokemonList>(_pokejson.text);
    }
}
