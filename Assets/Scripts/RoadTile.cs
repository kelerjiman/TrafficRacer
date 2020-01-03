using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class RoadTile : MonoBehaviour
{
    RT_Properties Props;
    float Z_Area = 10;
    int Law_Breaking = 0;
    bool Is_TwoLine = true;
    private void Start()
    {
        Handle_Law();
    }
    void Handle_Law()
    {
        int x = Props.Get_Law_Code();
        switch (x)
        {
            case 0:
                {
                    Debug.Log("بوق زدن ممنوع");
                    break;
                }
            case 1:
                {
                    Debug.Log("جاده دوطرفه است");
                    break;
                }
            case 2:
                {
                    Debug.Log("حداکثر سرعت مجاز");
                    break;
                }
            case 3:
                {
                    Debug.Log("تبدیل دو لاین به چهار لاین از راست");
                    break;
                }
            case 4:
                {
                    Debug.Log("تبدیل دولاین به چهار لاین از چپ ");
                    break;
                }
            case 5:
                {
                    Debug.Log("تبدیل چهارلاین  به دو لاین از راست");
                    break;
                }
            case 6:
                {
                    Debug.Log("تبدیل چهار لاین  به دولاین از چپ ");
                    break;
                }
            case 7:
                {
                    Debug.Log("جاده یک طرفه است");
                    break;
                }
            case 8:
                {
                    Debug.Log("جاده یک طرفه- برعکس - است");
                    break;
                }
            case 9:
                {
                    Debug.Log("اخطار ( برای حوادث یا موانع دیگر )س");
                    break;
                }
            default:
                break;
        }
    }
}
