using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int initialSize = 10;
    
    public GameObject poolPrefab;

    private Transform poolRoot;
    
    private Queue<GameObject> queue = new Queue<GameObject>();
    
    private bool initialized = false;

    private int currentCapacity;
    
    private HashSet<GameObject> poolObjects = new HashSet<GameObject>();

    private void Awake()
    {
        if (poolPrefab == null)
        {
            Debug.LogError("PoolPrefab is null");
            return;
        }

        poolRoot = new GameObject($"{poolPrefab.name}_PoolRoot").transform;
        poolRoot.SetParent(transform);
        currentCapacity = initialSize;
    }

    public void InitializePool()
    {
        if (initialized)
        {
            return;
        }
        initialized = true;
        CreateObjects(initialSize);
    }

    private void CreateObjects(int count)
    {
        if (poolPrefab == null)
        {
            Debug.LogError("Pool prefab is null");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(poolPrefab, poolRoot);
            obj.SetActive(false);
            if (!poolObjects.Add(obj))
            {
                Debug.LogWarning("Duplicate object.");
                Destroy(obj);
                continue;
            }
            queue.Enqueue(obj);
        }
    }

    public GameObject GetObjFromPool()
    {
        // if (queue.Count > 0)
        // {
        //     GameObject obj = queue.Dequeue();
        //     // obj.transform.SetParent(null);
        //     poolObjects.Remove(obj);
        //     obj.SetActive(true);
        //     return obj;
        // }
        // else
        // {
        //     ExpandPool();
        //     GameObject obj = queue.Dequeue();
        //     poolObjects.Remove(obj);
        //     obj.SetActive(true);
        //     return obj;
        // }

        if (queue.Count == 0)
        {
            ExpandPool();
        }
        GameObject obj = queue.Dequeue();
        poolObjects.Remove(obj);
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObjToPool(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }
        obj.SetActive(false);
        obj.transform.SetParent(poolRoot);
        if (!poolObjects.Add(obj))
        {
            return;
        }

        queue.Enqueue(obj);
    }

    private void ExpandPool()
    {
        CreateObjects(currentCapacity);
        currentCapacity *= 2;
    }
}
