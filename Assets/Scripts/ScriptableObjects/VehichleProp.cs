using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Vehichle_", menuName = "Vehichle Properties", order = 0)]
public class VehichleProp : ScriptableObject
{
    //[SerializeField]
    //int MaxSpeed = 10;
    //public int Get_MaxSpeed()
    //{
    //    return MaxSpeed;
    //}

    [SerializeField]
    int GearCount = 3;
    public int Get_GearCount()
    {
        return GearCount;
    }

    [SerializeField]
    float Nitro = 5;
    public float Get_Nitro()
    {
        return Nitro;
    }

    [SerializeField]
    float Mass = 50;
    public float Get_Mass()
    {
        return Mass;
    }

    [Space]
    [Space]
    [Header("Handling")]
    [SerializeField]
    [Range(0, 1)]
    float HandlingRate = 0.2f;
    public float Get_HandlingRate()
    {
        return HandlingRate;
    }

    [SerializeField]
    [Range(0, 1)]
    float HandlingAnim_Rate = 0.2f;
    public float Get_Handling_Anim_Rate()
    {
        return HandlingAnim_Rate;
    }

    [Space]
    [Space]
    [Header("Breaking")]
    [SerializeField]
    [Range(0, 10)]
    float BreakingRate = 2;
    public float Get_Breaking()
    {
        return BreakingRate;
    }

    [SerializeField]
    [Range(0, 1)]
    float Force_Resistance = 0.4f;
    public float Get_ForceResist()
    {
        return Force_Resistance;
    }
    [SerializeField]
    [Range(0, 5)]
    int Health = 3;
    public int Get_Health()
    {
        return Health;
    }
}
