using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    const string TOTAL_COINS = "coins";
    const string MASTER_VOLUME = "master_volume";
    const string SCORE = "score_";
    const string MUTE = "mute";
    const string KIND_OF_CONTROL = "kind_of_control";

    public static void setTotalCoin(int coins)
    {
        PlayerPrefs.SetInt(TOTAL_COINS, coins);
    }
    public static int getTotalCoin()
    {
        return PlayerPrefs.GetInt(TOTAL_COINS);
    }
    public static void setCarUnlock(string CarName, bool IsLocked)
    {
        if (IsLocked)
            PlayerPrefs.SetInt(CarName, 0);
        else
            PlayerPrefs.SetInt(CarName, 1);
    }
    public static void setMastervolume(float volume)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
    }
    public static void setScore(string Num, int score)
    {
        PlayerPrefs.SetInt(SCORE + Num, score);
    }
    public static void setMutevolume(bool mute)
    {
        if (mute)
            PlayerPrefs.SetInt(MUTE, 0);
        else
            PlayerPrefs.SetInt(MUTE, 1);
    }
    public static void setKindOfControl(int Index)
    {
        PlayerPrefs.SetInt(KIND_OF_CONTROL, Index);
    }
    public static int getCarUnlock(string CarName)
    {
        return PlayerPrefs.GetInt(CarName);
    }
    public static float getMastervolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME);
    }
    public static int getScore(string Num)
    {
        return PlayerPrefs.GetInt(SCORE + Num);
    }
    public static bool getMutevolume()
    {

        if (PlayerPrefs.GetInt(MUTE) > 0)
            return false;
        else
            return true;
    }
    public static int getKindOfControl()
    {
        return PlayerPrefs.GetInt(KIND_OF_CONTROL);
    }
}
