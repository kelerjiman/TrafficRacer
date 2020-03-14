using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Car_Card_Prop",menuName ="Car Card")]
public class SO_CarCard : ScriptableObject
{
    [SerializeField] Sprite CarIcon;
    [SerializeField] string CarName;
    [SerializeField] GameObject Prefab;
    [Range(0,1)]
    [SerializeField] float ProductCoinRate = 1;
    [Range(0,1)]
    [SerializeField] float MultipleScoreRate = 1;
    [SerializeField] int Price = 0;
    public Sprite GetCarIcon()
    {

        return CarIcon;
    }
    public string GetCarName()
    {
        return CarName;
    }
    public float GetCoinRate()
    {
        return ProductCoinRate;
    }
    public float GetScoreRate()
    {
        return MultipleScoreRate;
    }
    public GameObject GetPrefab()
    {
        return Prefab;
    }
    public int GetPrice()
    {
        return Price;
    }
}
