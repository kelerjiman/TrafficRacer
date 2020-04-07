using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    enum Type
    {
        none,
        coin,
        speed,
        scale
    }
    [SerializeField] string PUName;
    [SerializeField] Type types;
    [SerializeField] GameObject Particle;
    [SerializeField] int prize = 1;
    [SerializeField] int score = 1;
    Movement player;
    [Header("Model: ")]
    [SerializeField]
    GameObject model;
    [SerializeField] bool IsPositive = true;
    [SerializeField] int Timer = 2;
    private void Start()
    {
        player = FindObjectOfType<Movement>();
        Destroy(gameObject, 20);
        Timer = PlayerPrefsScript.getPowerUpLevel(PUName) * Timer;
        Debug.Log(PlayerPrefsScript.getPowerUpLevel(PUName));
    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.GM_Is_Accident)
            if (other.tag == player.tag)
            {
                if (prize > 0)
                    Coins();
                else
                {
                    _other();
                    ScoreManager.Instance.Powerups += score;
                }
                //instantiate particle
                instantiate();
            }
        //hide game object

    }

    private void Coins()
    {
        //Debug.Log("Power Up On triggerEnter is triggered !");
        //set coin in run time window 
        var RunTime = FindObjectOfType<RunTimeWindow>();
        RunTime.Cash_Ingame += prize;
        ScoreManager.Instance.TotalCash += prize;
        RunTime.T_InGameCash.text = RunTime.Cash_Ingame.ToString();
        //--------------------------------------------------------
        //saving total coin in player prefs
        var totalCoin = PlayerPrefsScript.getTotalCoin();
        totalCoin += prize;
        PlayerPrefsScript.setTotalCoin(totalCoin);
        GameManager.Instance.GM_Total_Coins = totalCoin;
        //--------------------------------------------------------
    }
    private void _other()
    {
        switch (types)
        {
            //case Type.none:
            //    break;
            //case Type.coin:
            //    break;
            case Type.speed:
                GameManager.Instance.speed(player, Timer, IsPositive);
                break;
            case Type.scale:
                GameManager.Instance.Scale(player, Timer, IsPositive);
                break;
            default:
                break;
        }
    }

    private void instantiate()
    {
        var p = Instantiate(Particle, player.transform.position, Quaternion.identity);
        var partical = p.GetComponent<ParticleSystem>();
        p.transform.parent = player.transform;
        partical.Play();
        model.SetActive(false);
        gameObject.SetActive(false);
        Destroy(gameObject, partical.main.duration);
    }
}
