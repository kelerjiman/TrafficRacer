using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    /// <summary>
    /// in the array Index:
    /// 0- default Prefab
    /// 1- changing to other array { in TwoLine array 2-->4 }
    /// 2-...  from 2 until end of array using for signed prefabs
    /// </summary>
    [Header("Shapes of TwoLine")]
    [SerializeField]
    GameObject[] TwoLine;
    [Header("Shapes of FourLines")]
    [SerializeField]
    GameObject[] FourLine;
    [Header("Current GameObject for instantiating")]
    [SerializeField]
    GameObject CurrentGameObject;
    [SerializeField] bool Is_TwoLineSelected = true;
    GameObject player;
    [Header("Tile Properties")]
    [SerializeField]
    float TileLenght = 10f;
    [SerializeField] float spawnZ = -210;
    [SerializeField] int TileCount = 22;
    [SerializeField] Vector3 CurrentPos = Vector3.zero;
    [Header("badan delete mishavad")]
    [SerializeField]
    int _PrefabIndex = 2;
    private void Awake()
    {
        CurrentPos = transform.position;
    }
    private void Start()
    {
        CurrentGameObject = TwoLine[0];
        player = FindObjectOfType<Movement>().gameObject;
        for (int i = 0; i < TileCount; i++)
        {
            TileRespawnHandle(CurrentGameObject);
        }
    }
    private void FixedUpdate()
    {
        if (player.transform.position.z > (spawnZ - TileCount * TileLenght))
        {
            TileRespawnHandle(CurrentGameObject);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Is_TwoLineSelected)
            {
                CurrentGameObject = TwoLine[Random.Range(1, 3)];
            }
            else
            {
                CurrentGameObject = FourLine[Random.Range(1, 3)];
            }
        }
    }
    void TileRespawnHandle(GameObject obj)
    {
        GameObject tile;
        tile = Instantiate(obj) as GameObject;
        tile.transform.parent = transform;
        tile.transform.position = Vector3.forward * spawnZ;
        tile.transform.position = new Vector3(CurrentPos.x, CurrentPos.y, tile.transform.position.z);
        spawnZ += TileLenght;
        if (CurrentGameObject.name == "LTtoF" || CurrentGameObject.name == "RFtoT")
        {
            CurrentPos.x -= 5;
        }
        if (CurrentGameObject.name == "RTtoF" || CurrentGameObject.name == "LFtoT")
        {
            CurrentPos.x += 5;
        }
        if (Is_TwoLineSelected)
        {
            if (CurrentGameObject != TwoLine[0])
                CurrentGameObject = TwoLine[0];
        }
        else
        {
            if (CurrentGameObject != FourLine[0])
                CurrentGameObject = FourLine[0];
        }

    }
    public void SignedTileHandle(int Index = -1, GameObject SignNameS = null)
    {
        switch (Index)
        {
            case 2:
                {
                    if (!Is_TwoLineSelected)
                    {
                        Debug.Log("Going to 4---->2");
                        CurrentGameObject = SignNameS;
                        Is_TwoLineSelected = true;
                    }
                    break;
                }
            case 4:
                {
                    if (Is_TwoLineSelected)
                    {
                        Debug.Log("Going to 2----->4");
                        CurrentGameObject = SignNameS;
                        Is_TwoLineSelected = false;
                    }
                    break;
                }
            default:
                {

                    break;
                }
        }

    }
}
