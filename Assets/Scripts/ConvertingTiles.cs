using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertingTiles : MonoBehaviour
{
    public string TYPE_OF_SIGN = string.Empty;
    public GameObject NAME_OF_SIGN;
    [SerializeField] bool Is_Signed = false;
    public bool Is_TwoLine = true;
    [SerializeField] Road road;
    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("GroundTile");
        road = FindObjectOfType<Road>();
    }
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Is_Signed)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("i colliding wit Player");
                SignedCollisionHandle();
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {

    }

    private void SignedCollisionHandle()
    {
        ///این قسمت از کد تصمیم به چند لاین کردن می گیرد
        //برای تغییر لاین از 2 به 4 و بلعکس
        switch (TYPE_OF_SIGN)
        {
            case "Converting":
                {
                    if (Is_TwoLine)
                        OPRHandler(4);
                    else
                        OPRHandler(2);
                    break;
                }
            default:
                OPRHandler(-1);
                break;
        }
    }
    private void OPRHandler(int Index)
    {
        //road.SignedTileHandle(Index, NAME_OF_SIGN);
    }
}
