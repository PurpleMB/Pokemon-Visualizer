using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokeJsonInterpreter : MonoBehaviour
{
    [SerializeField] private TextAsset _pokejson;

    [System.Serializable]
    public class PokemonList : IEnumerable<Pokemon>
    {
        public Pokemon[] pokes;

        public IEnumerator<Pokemon> GetEnumerator()
        {
            foreach(Pokemon poke in pokes)
            {
                yield return poke;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public PokemonList PokeList = new PokemonList();

    // Start is called before the first frame update
    void Awake()
    {
        PokeList = JsonUtility.FromJson<PokemonList>(_pokejson.text);
        Debug.Log("# of Pokemon interpreted from Json at Awake: " + PokeList.Count());
    }
}
