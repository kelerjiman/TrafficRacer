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
    const string CURRENT_CAR = "CurrentCar";
    const string SFX_VOLUME = "sfx_volume";
    const string SFX_MUTE = "sfx_mute";
    public static void setPowerUpLevel(string PUName,int x)
    {
        PlayerPrefs.SetInt(PUName, x);
    }
    public static int getPowerUpLevel(string PUName)
    {
        return PlayerPrefs.GetInt(PUName);
    }
    public static void setSfxVolume(float sfx)
    {
        PlayerPrefs.SetFloat(SFX_VOLUME, sfx);
    }
    public static float getSfxVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME);
    }
    public static void setSfxMute(bool mute)
    {
        int x = (mute) ? 1 : 0;
        PlayerPrefs.SetInt(SFX_MUTE, x);
    }
    public static bool getSfxMute()
    {
        int x = PlayerPrefs.GetInt(SFX_MUTE);
        bool y = (x == 1) ? true : false;
        return y;
    }
    public static void setCurrentCar(string param)
    {
        PlayerPrefs.SetString(CURRENT_CAR, param);
    }
    public static string getCurrentCar()
    {
        return PlayerPrefs.GetString(CURRENT_CAR);
    }
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
        int x = (mute) ? 1 : 0;
        PlayerPrefs.SetInt(MUTE, x);
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
        int x = PlayerPrefs.GetInt(MUTE);
        bool y = (x == 1) ? true : false;
        return y;
    }
    public static int getKindOfControl()
    {
        return PlayerPrefs.GetInt(KIND_OF_CONTROL);
    }
}
