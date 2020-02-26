using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public string tagOfPrefabs;
    public List<GameObject> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPooler Instance;
    private void Start()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        Queue<GameObject> objectPool = new Queue<GameObject>();
        foreach (var pool in pools)
        {
            var obj = Instantiate(pool);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        poolDictionary.Add(tagOfPrefabs, objectPool);
    }
    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tagOfPrefabs))
        {
            Debug.LogWarning("is empty");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tagOfPrefabs].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        poolDictionary[tagOfPrefabs].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

}
