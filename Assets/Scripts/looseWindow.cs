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
    ScoreManager SM;
    public override void Start()
    {
        SM = FindObjectOfType<ScoreManager>();
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
        m_TotalDistance.text = SM.TotalDistance.ToString();
        m_TotalScore.text= SM.TotalScore.ToString();
        m_OverTakes.text = SM.OverTakes.ToString();
        m_PowerUps.text = SM.Powerups.ToString();
        m_Opposite.text = SM.OppositeLine.ToString();
        GameManager.Instance.player.gameObject.SetActive(false);
        base.reloadSetting();
    }
}
