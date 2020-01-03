using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RT_Props", menuName = "Road Tile Props", order = 2)]
public class RT_Properties : ScriptableObject
{
    [SerializeField] GameObject Obj;
    public GameObject Get_Obj()
    {
        return Obj;
    }


    [SerializeField] int X_Spawn = 0;
    public int Get_X_Spawn()
    {
        return X_Spawn;
    }


    [SerializeField] int Law_Code = -1;
    public int Get_Law_Code()
    {
        return Law_Code;
    }
}
