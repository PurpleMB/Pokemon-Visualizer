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
        return _nameDict[name];
    }

    public T LookupById(int id)
    {
        id = Mathf.Clamp(id, 0, _idDict.Count);
        return _idDict[id];
    }
}
