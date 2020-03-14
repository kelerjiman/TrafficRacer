using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
public class InGameCash : MonoBehaviour
{
    #region old code
    //public int Score_InGame = 0;//امتیاز داخل بازی
    //public int Score_For_Speed = 6;//مدت زمانی که بعد از آن امتیاز حساب می شود
    //public float Timer = 0;// مدت زمانی که برای محاسبه امتیاز استفاده می شود
    //private int NextSecond = 0;
    //private float m_SpeedCondition = 0;//تعیین کننده ترمز یا گاز
    //private void FixedUpdate()
    //{
    //    speedCondition();
    //    Handle_Score_InGame();
    //}
    //void Handle_Score_InGame()
    //{
    //    Handle_Time();

    //}

    //private void Handle_Time()
    //{
    //    if (m_SpeedCondition == 0)
    //    {
    //        NextSecond = 0;
    //        Timer = 0;
    //    }
    //    else
    //    {
    //        Timer += Time.deltaTime;
    //    }
    //    if (Timer >= 4 && NextSecond == 0)
    //    {
    //        NextSecond = 4;
    //    }
    //    if (Timer < NextSecond)
    //        return;
    //    Score_InGame += Mathf.RoundToInt(Score_For_Speed * m_SpeedCondition);
    //    NextSecond++;

    //}
    //public void speedCondition()
    //{
    //    var temp = Mathf.Round(gameObject.GetComponent<Rigidbody>().velocity.z);
    //    if (temp > GameManager.Instance.GM_MainSpeed + (GameManager.Instance.GM_MainSpeed * 0.5))
    //        m_SpeedCondition = 1;
    //    else if (temp < GameManager.Instance.GM_MainSpeed + 1)
    //        m_SpeedCondition = -1;
    //    else
    //    {
    //        m_SpeedCondition = 0;
    //    }


    //}
    #endregion

}
