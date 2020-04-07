using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] internal int TotalDistance = 0;
    [SerializeField] internal int OverTakes = 0;
    [SerializeField] internal int Powerups = 0;
    [SerializeField] internal int OppositeLine = 0;
    [SerializeField] internal int TotalCash = 0;
    [SerializeField] internal int totalScore = 0;
    [SerializeField]
    float timer = 5;
    float timerTemp = 0;
    public bool timeToCount = false;
    [SerializeField] looseWindow looseWin;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            timerTemp += Time.deltaTime;
            if (timeToCount && !GameManager.Instance.GM_Is_Accident)
            {
                OppositeLine = (int)timerTemp;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            timerTemp = 0;
            timeToCount = false;
        }
    }
    private void Start()
    {
        Instance = this;
        OppositeLine = 0;
    }
    private void Update()
    {
        if (GameManager.Instance.GM_Is_Accident)
            return;
        if (timerTemp > timer)
            timeToCount = true;
        else
            timeToCount = false;
        totalScore = OverTakes + Powerups + OppositeLine + TotalDistance;
    }
    ..
    //total score mohasebe mishavad vali dar loose window lahaz nemishavad
    //zamani ke button reload marboot be loose window ra 
    //bezanim error GameManager.Instance.GM_... ra midahad
    //fix shavad
}
