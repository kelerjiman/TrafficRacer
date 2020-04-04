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
    [SerializeField] internal int TotalScore = 0;
    [SerializeField]
    float timer = 5;
    float timerTemp = 0;
    public bool timeToCount = false;
    looseWindow looseWin;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !timeToCount)
        {
            timerTemp += Time.deltaTime;
        }
        if (timeToCount)
        {
            OppositeLine += (int)timerTemp;
            FindObjectOfType<looseWindow>().GetComponent<IWindowGeneric>().reloadSetting();
            timerTemp = 0;
            timeToCount = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (timerTemp >= timer)
            {
                OppositeLine += (int)timerTemp;
                timerTemp = 0;
            }

            Debug.Log("score manager ontrigger exit time to count : " + ScoreManager.Instance.OppositeLine);
        }
    }
    private void Start()
    {
        Instance = this;
        OppositeLine = 0;
    }
    private void Update()
    {

    }
}
