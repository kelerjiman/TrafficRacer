using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtonManager : MonoBehaviour
{
    Movement player;
    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }
    //متد برای دکمه های یو آی
    public void Event_Dir_Down(int x)
    {
        player.X_Input = x;
    }
    public void Event_Acc_Down(int x)
    {
        player.Z_Input = x;
    }
    public void Event_Up(bool dir)
    {
        if (dir)
            player.X_Input = 0;
        else
            player.Z_Input = 0;
    }
}
