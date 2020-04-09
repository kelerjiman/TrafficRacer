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
    [SerializeField] internal int TotalCoin = 0;
    [SerializeField] internal int totalScore = 0;
    public bool timeToCount = false;
    [SerializeField] float Timer = 5;
    float m_TimerTemp = 0;
    [SerializeField] looseWindow looseWin;
    float m_SpeedTimer = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            m_TimerTemp += Time.deltaTime;
            if (timeToCount && !GameManager.Instance.GM_Is_Accident)
            {
                OppositeLine = (int)m_TimerTemp;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_TimerTemp = 0;
            timeToCount = false;
        }
    }
    private void Start()
    {
        Instance = this;
        OppositeLine = 0;
        StartCoroutine(Handle_EncSpeed());
    }
    private void Update()
    {
        if (GameManager.Instance.GM_Is_Accident)
            return;
        if (m_TimerTemp > Timer)
            timeToCount = true;
        else
            timeToCount = false;
        totalScore = OverTakes + Powerups + OppositeLine + TotalDistance;
    }
    IEnumerator Handle_EncSpeed()
    {
        yield return new WaitForSeconds(GameManager.Instance.timer);
        GameManager.Instance.Handle_EncSpeed();
        StartCoroutine(Handle_EncSpeed());
    }
}
