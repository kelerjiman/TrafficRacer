using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Decoration : MonoBehaviour
{
    [SerializeField] List<GameObject> PrefabsList;
    [SerializeField] Vector2 PositionOfTrees = Vector3.zero;
    public bool IsRightSide = false;
    //distance between of to trees
    [SerializeField] int TileLenght = 10;
    //Z cordinate of tree location
    [SerializeField] float spawnZ = -210;
    //numbers of tree that can be exists in same time
    [SerializeField] int TileCount = 50;
    public Vector3 CurrentPos = Vector3.zero;
    public float NewXPos = 0;
    GameObject player;
    Road road;
    private void Awake()
    {

        CurrentPos = transform.position;
        NewXPos = CurrentPos.x;
        tag = "Obs";
        road = FindObjectOfType<Road>();
        for (int i = 0; i < PrefabsList.Count; i++)
        {
            TileRespawnHandle(PrefabsList[Random.Range(0, PrefabsList.Count)]);
        }
    }
    private void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
    }
    private void Update()
    {
        if (GameManager.GM.GM_Is_Accident)
            return;
        if (CurrentPos.x != NewXPos)
        {
            var temp = CurrentPos;
            temp.x = NewXPos;
            CurrentPos = temp;
        }
        if (player.transform.position.z > (spawnZ - TileCount * TileLenght) || GetComponentsInChildren<Transform>().Length < TileCount)
        {
            TileRespawnHandle(PrefabsList[Random.Range(0, PrefabsList.Count)]);
        }
    }
    void TileRespawnHandle(GameObject obj)
    {
        GameObject tile;
        tile = Instantiate(obj) as GameObject;
        tile.tag = "Obs";
        tile.transform.parent = transform;
        tile.transform.position = Vector3.forward * spawnZ;
        tile.transform.position = new Vector3(
            CurrentPos.x + (Mathf.Sign(CurrentPos.x) * (Random.Range(PositionOfTrees.x, PositionOfTrees.y))),
            CurrentPos.y, tile.transform.position.z);
        spawnZ += tile.GetComponent<Collider>().bounds.size.z;
    }
}