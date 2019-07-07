using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{/// <summary>
/// for instantiate coin just toggle Time To Respawn
/// in the game manager
/// game manager will decide which one of spawner must spawn the coins
/// </summary>
    public enum PUSelector
    {
        EncSpeed,
        DecSpeed,
        EncScale,
        DecScale,
        Shield,
        none
    }
    [Header("Coin Properties")]
    [SerializeField] Coins CoinPrefab;
    //delay between coins
    [SerializeField] float DelaybetweenCoins = 0.5f;
    //numbers of respawned coins
    [SerializeField] int RepeatRate = 5;
    //for triggering the respawns
    [SerializeField] bool TimeToRespawn = false;
    [SerializeField] int CoinCounter = 0;
    [Header("Shield Properties")]
    [SerializeField]
    GameObject Shield;
    [Header("shield must be compeleted work On it")]
    [SerializeField]string delete_it;

    void Start()
    {
        StartCoroutine(coin());
    }
    private void Update()
    {

    }
    void PowerUp(PUSelector pUselector)
    {
        switch (pUselector)
        {
            case PUSelector.EncSpeed:
                break;
            case PUSelector.DecSpeed:
                break;
            case PUSelector.EncScale:
                break;
            case PUSelector.DecScale:
                break;
            case PUSelector.Shield:
                break;
            case PUSelector.none:
                break;
            default:
                break;
        }
    }
    IEnumerator coin()
    {
        if (CoinCounter == RepeatRate)
        {
            TimeToRespawn = false;
            CoinCounter = 0;
        }

        if (TimeToRespawn)
        {
            CoinCounter += 1;
            var x = Instantiate(CoinPrefab);
            x.transform.position = transform.position;
        }
        yield return new WaitForSeconds(DelaybetweenCoins);
        StartCoroutine(coin());
    }
}
