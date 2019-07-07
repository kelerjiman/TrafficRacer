using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> PrefabsList;
    [SerializeField] float respawn_Speed = 1f;
    [SerializeField] float Zspeed = -2f;
    [SerializeField] string ParentName;
    int counter = 0;
    void Start()
    {
        StartCoroutine(RespawnDelay());
        ParentName = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(respawn_Speed);
        counter = Random.Range(0, PrefabsList.Count);
       var x= Instantiate(PrefabsList[counter], transform.position, Quaternion.Euler(0, 270f, 0));
        x.GetComponent<Building>().zSpeed = Zspeed;
        StartCoroutine(RespawnDelay());
    }

}
