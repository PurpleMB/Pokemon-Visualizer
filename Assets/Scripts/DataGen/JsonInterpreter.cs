using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class JsonInterpreter<T> : MonoBehaviour
{
    [SerializeField] protected TextAsset _sourceJson;

    [System.Serializable]
    public class DataList: IEnumerable<T>
    {
        public T[] Data;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T dataPoint in Data)
            {
                yield return dataPoint;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public DataList JsonData = new DataList();

    protected void parseData()
    {
        JsonData = JsonUtility.FromJson<DataList>(_sourceJson.text);
    }
}
