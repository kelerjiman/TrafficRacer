using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCarWindow : GenericWindow
{
    [SerializeField] GameObject CardButton;
    [SerializeField] GameObject ContentHolder;
    [SerializeField] SO_CarCard[] CarCards;
    public override void Start()
    {
        base.Start();
        Define_carCards();
    }

    public void Define_carCards()
    {
        foreach (var item in CarCards)
        {
            var x = Instantiate(CardButton);
            x.transform.parent = ContentHolder.transform;
            x.GetComponent<CardButton>().SetInfo(item);
        }
    }
    
}
