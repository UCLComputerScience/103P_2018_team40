//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class GameObjectUtil
//{
//    private static Dictionary<RecyclableObject, ObjectPool> _pools = new Dictionary<RecyclableObject, ObjectPool>();
//
//    public static void Instantiate(GameObject prefab, Vector3 pos)
//    {
//        var recyclable = prefab.GetComponent<RecyclableObject>();
//        if (recyclable != null) // the object is recyclable
//        {
//            // recycle the object
//        }
//        else
//        {
//            GameObject.Instantiate(prefab).transform.position = pos; // potential issues
//        }
//    }
//
//    public static void Destory(GameObject gameObject)
//    {
//        var recyclable = gameObject.GetComponent<RecyclableObject>();
//        if (recyclable != null)
//        {
//            recyclable.ShutDown();
//        }
//        else
//        {
//            GameObject.Destroy(gameObject);
//        }
//    }
//    private static ObjectPool getObjectPool(RecyclableObject reference)
//    {
//        
//        if (_pools.ContainsKey(reference))
//        {
//            return _pools[reference];
//        }
//        
//        var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
//        var pool = poolContainer.AddComponent<ObjectPool>();
//        pool.prefab = reference;
//        _pools.Add(reference, pool);
//        
//
//        
//    }
//}