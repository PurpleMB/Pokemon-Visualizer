using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Database<T> : MonoBehaviour where T : class
{
    protected Dictionary<string, T> _nameDict = new Dictionary<string, T>();
    protected List<T> _idDict;

    protected void Start()
    {
        fillDics();
    }

    protected abstract void fillDics();

    public T LookupByName(string name)
    {
        if (_nameDict.ContainsKey(name))
        {
            return _nameDict[name];
        }
        return null;
    }

    public T LookupById(int id)
    {
        if(id >= 0 && id < _idDict.Count)
        {
            return _idDict[id];
        }
        return null;
    }
}
