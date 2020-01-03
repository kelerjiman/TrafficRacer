using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRSCorner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int ChangeConsPos = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var x = FindObjectOfType<ConstantBehavior>();
            x.NewXPos = x.transform.position.x + ChangeConsPos;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Obs"))
        {
            Destroy(other.gameObject);
        }
    }
    void Awake()
    {
        //var BTemp = FindObjectsOfType<BuildingSpawner>();
        //var Dec = FindObjectsOfType<Decoration>();
        //if (name == "LTtoF(Clone)" || name == "RFtoT(Clone)")
        //{
        //    Debug.Log(name);
        //    if (name == "LTtoF(Clone)")
        //    {
        //        foreach (var item in BTemp)
        //        {
        //            if (!item.is_RightSide)
        //                item.XPadding = item.CurrentPos.x + ChangeConsPos;
        //        }
        //        foreach (var TempDec in Dec)
        //        {
        //            if (!TempDec.IsRightSide)
        //                TempDec.NewXPos = TempDec.CurrentPos.x + ChangeConsPos;
        //        }

        //    }
        //    else
        //    {

        //        foreach (var item in BTemp)
        //        {
        //            if (item.is_RightSide)
        //                item.XPadding = item.CurrentPos.x + ChangeConsPos;
        //        }
        //        foreach (var TempDec in Dec)
        //        {
        //            if (TempDec.IsRightSide)
        //                TempDec.NewXPos = TempDec.CurrentPos.x + ChangeConsPos;
        //        }

        //    }
        //}
        //else if (name == "LFtoT(Clone)" || name == "RTtoF(Clone)")
        //{
        //    Debug.Log(name);
        //    if (name == "LFtoT(Clone)")
        //    {
        //        foreach (var item in BTemp)
        //        {
        //            if (item.is_RightSide)
        //                item.XPadding = item.CurrentPos.x + ChangeConsPos;
        //        }
        //        foreach (var TempDec in Dec)
        //        {
        //            if (TempDec.IsRightSide)
        //                TempDec.NewXPos = TempDec.CurrentPos.x + ChangeConsPos;
        //        }

        //    }
        //    else
        //    {
        //        foreach (var item in BTemp)
        //        {
        //            if (!item.is_RightSide)
        //                item.XPadding = item.CurrentPos.x + ChangeConsPos;
        //        }
        //        foreach (var TempDec in Dec)
        //        {
        //            if (!TempDec.IsRightSide)
        //                TempDec.NewXPos = TempDec.CurrentPos.x + ChangeConsPos;
        //        }

        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
