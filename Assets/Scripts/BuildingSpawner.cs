using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BuildingSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> PrefabsList;
    private GameObject currentOBJ;

    [SerializeField]
    int TileCount = 20;

    [SerializeField]
    int refSize = 10;

    [Header("")]
    Movement Player;

    bool is_TwoLine = true;

    public float SpawnZ = 0f;

    [SerializeField] float SpawnX = 0f;

    public int is_RightSide = 1;
    public float XPadding = 0;
    public float ZPadding = 0;




    int Direction = 0;
    bool is_TimeToMove = false;

    private void Awake()
    {
        for (int i = 0; i < TileCount; i++)
        {
            Handle_Spawn(PrefabsList[i]);
        }
    }

    private void Start()
    {
        Player = FindObjectOfType<Movement>();
    }
    private void Update()
    {
        if (GameManager.GM.GM_Is_Accident)
            return;
        if (Player.transform.position.z > (SpawnZ - TileCount * refSize))
        {
            Handle_Spawn(currentOBJ);
        }
    }
    void Handle_Spawn(GameObject tile)
    {
        var _tile = Instantiate(tile) as GameObject;
        Handle_Rotation(_tile, is_RightSide);
        _tile.transform.parent = transform;
        Handle_Z_Spawn(_tile);
        currentOBJ = PrefabsList[UnityEngine.Random.Range(0, PrefabsList.Count)];
    }

    private void Handle_Z_Spawn(GameObject tile)
    {
        Vector3 _size = tile.GetComponent<Collider>().bounds.size;
        var tempPos = tile.transform.position;
        tempPos.z = SpawnZ + (_size.z / 2) + ZPadding;
        tile.transform.position = tempPos;
        Handle_X_Spawn(tile, _size, tempPos, is_RightSide);
        SpawnZ += _size.z + ZPadding;
    }
    private void Handle_X_Spawn(GameObject tile, Vector3 _size, Vector3 pos, int rightSide)
    {
        pos.x = SpawnX + is_RightSide * ((_size.x / 2) + XPadding);
        tile.transform.position = pos;
    }
    private void Handle_Rotation(GameObject tile, int _rightSide)
    {
        var temp = tile.transform.localScale;
        temp.x *= _rightSide;
        tile.transform.localScale = temp;
    }
    public void Handle_Move(int value)
    {
            SpawnX += value;
    }
}
