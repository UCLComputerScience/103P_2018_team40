using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycleComponent
{
    void Restart();
    void ShutDown();
}


public class RecyclableObject : MonoBehaviour
{
    private List<IRecycleComponent> _recycleComponents;

    private void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        foreach (var com in components)
        {
            if (com is IRecycleComponent)
            {
                _recycleComponents.Add(com as IRecycleComponent);
            }
        }
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        foreach (var com in _recycleComponents)
        {
            com.Restart();
        }
    }

    public void ShutDown()
    {
        gameObject.SetActive(false);
        foreach (var com in _recycleComponents)
        {
            com.ShutDown();
        }
    }
}