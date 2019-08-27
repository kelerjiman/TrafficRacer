using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> PrefabsList;
    [SerializeField] int TileLenght = 10;
    [SerializeField] float spawnZ = -210;
    [SerializeField] int TileCount = 22;
    public Vector3 CurrentPos = Vector3.zero;
    public float NewXPos = 0;
    GameObject player;
    Road road;
    private void Awake()
    {
        CurrentPos = transform.position;
        NewXPos = CurrentPos.x;
    }
    private void Start()
    {
        road = FindObjectOfType<Road>();
        player = FindObjectOfType<Movement>().gameObject;
        for (int i = 0; i < PrefabsList.Count; i++)
        {
            TileRespawnHandle(PrefabsList[Random.Range(0, PrefabsList.Count)]);
        }
    }
    private void Update()
    {
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
        tile.transform.parent = transform;
        tile.transform.position = Vector3.forward * spawnZ;
        var tempX = CurrentPos.x + Mathf.Sign(CurrentPos.x) * (tile.GetComponent<BoxCollider>().bounds.extents.x / 2);
        tile.transform.position = new Vector3(tempX, CurrentPos.y, tile.transform.position.z);
        spawnZ += tile.GetComponent<BoxCollider>().bounds.size.z;
    }
    public void ConvertingLines(bool Is_TwoLine, bool Is_LeftConverting)
    {
    }
}
