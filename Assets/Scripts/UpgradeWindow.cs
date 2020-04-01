using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWindow : GenericWindow
{
    [SerializeField] GameObject[] powerUps;
    [SerializeField] Transform ContentHolder;

    public override void Start()
    {
        base.Start();
        PauseButton.gameObject.SetActive(false);
        foreach (var powerUp in powerUps)
        {
           var x= Instantiate(powerUp);
            x.transform.parent = ContentHolder;
        }
    }


}
