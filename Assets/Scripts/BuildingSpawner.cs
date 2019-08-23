using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> PrefabsList;
    [SerializeField] List<GameObject> RoadSignPrefabs;
    [Header("Respawn Properties")]
    [SerializeField]
    float respawn_Speed = 1f;
    [SerializeField] float Speed = -30f;
    [SerializeField] string ParentName;
    [SerializeField] bool IsRightDirection = false;


    /// <summary>
    /// NEWEST CODE DONT DELETE IT
    /// </summary>
    /// 
    /// 
        ////////////////////////////////////////
    int counter = 0;
    void Start()
    {
        StartCoroutine(RD_Building());
        ParentName = name;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator RD_Building()
    {
        yield return new WaitForSeconds(respawn_Speed);
        counter = Random.Range(0, PrefabsList.Count);
        GameObject x;
        if (IsRightDirection)
        {
            x = Instantiate(PrefabsList[counter], transform.position, Quaternion.Euler(0, 270f, 0));
            x.GetComponent<Building>().zSpeed = Speed;
        }
        else
        {
            x = Instantiate(PrefabsList[counter], transform.position, Quaternion.Euler(0, 90f, 0));
            x.GetComponent<Building>().zSpeed = -Speed;
        }
        x.transform.parent = transform;
        x.tag = "Obs";
        StartCoroutine(RD_Building());
    }
}
