using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject[] prefabs;
    }
    public Pool[] Pools;
    public Dictionary<string, Queue<GameObject>> poolDic;
    private void Start()
    {
        poolDic = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in Pools)
        {
            Queue<GameObject> ObjPoolList = new Queue<GameObject>();
            foreach (var prefab in pool.prefabs)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                ObjPoolList.Enqueue(obj);
            }
            poolDic.Add(pool.tag, ObjPoolList);
        }
    }
    public GameObject SpawnFromPool(string _tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDic.ContainsKey(_tag))
        {
            Debug.LogWarning("is empty");
            return null;
        }
        GameObject objectToSpawn = poolDic[_tag].Dequeue();
        objectToSpawn.SetActive(true);
        IPooler I_ObjectToSpawn = objectToSpawn.GetComponent<IPooler>();
        if (I_ObjectToSpawn != null)
            I_ObjectToSpawn.setDefault();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        poolDic[_tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

}
