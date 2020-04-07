using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class looseWindow : GenericWindow
{
    [Space(10)]
    [Header("===========================")]
    [SerializeField]
    Text m_TotalDistance;
    [SerializeField]
    Text m_OverTakes;
    [SerializeField]
    Text m_Opposite;
    [SerializeField]
    Text m_PowerUps;
    [SerializeField]
    Text m_TotalScore;
    public override void Start()
    {
        base.Start();
        CloseButton.gameObject.SetActive(false);
    }
    public override void OnNextScene(int SIndex)
    {
        GameManager.Instance.GM_Is_Accident = false;
        base.OnNextScene(SIndex);
    }
    public override void reloadSetting()
    {
        m_TotalDistance.text = ScoreManager.Instance.TotalDistance.ToString();
        Debug.Log("ScoreManager total score is : "+ScoreManager.Instance.totalScore);
        m_TotalScore.text= ScoreManager.Instance.totalScore.ToString();
        m_OverTakes.text = ScoreManager.Instance.OverTakes.ToString();
        m_PowerUps.text = ScoreManager.Instance.Powerups.ToString();
        m_Opposite.text = ScoreManager.Instance.OppositeLine.ToString();
        GameManager.Instance.player.gameObject.SetActive(false);
        //Coins.text = ScoreManager.Instance.TotalCash.ToString();
        base.reloadSetting();
        //hesab ketab loose panel dorost shavad
    }
}
