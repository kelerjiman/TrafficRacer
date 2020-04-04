using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameButtonManager : MonoBehaviour
{
    [SerializeField] CanvasRenderer PausePanel;
    [SerializeField] CanvasRenderer LoosePanel;
    [SerializeField] CanvasRenderer WinPanel;
    Movement player;
    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }
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
