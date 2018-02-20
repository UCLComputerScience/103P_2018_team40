using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
// this pool handles all types of recyclables
{
    private Dictionary<RecyclableObject, List<RecyclableObject>> _recyclableDict = new Dictionary<RecyclableObject, List<RecyclableObject>>();

    public void Create(GameObject prefab, Vector3 pos)
    {
        var recyclable = prefab.GetComponent<RecyclableObject>();
        if (recyclable != null)
        {
            Recycle(recyclable, pos);
            return;
        }

        GameObject.Instantiate(prefab).transform.position = pos; // potential issues ?
    }

    private void Recycle(RecyclableObject recyclable, Vector3 pos)
    {
        if (_recyclableDict.ContainsKey(recyclable))
        {
            foreach (var ro in _recyclableDict[recyclable])
            {
                if (!ro.gameObject.activeSelf)
                {
                    ro.Restart(pos);
                    return;
                }
            }
        }
        else
        {
            _recyclableDict.Add(recyclable,new List<RecyclableObject>());
        }

        // need to create new instance
        var go = GameObject.Instantiate(recyclable.gameObject);
        go.transform.position = pos;
        go.transform.parent = transform;

        _recyclableDict[recyclable].Add(go.GetComponent<RecyclableObject>()); //?
    }
}