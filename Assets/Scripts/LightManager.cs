using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] DayCycle Sun;
    [SerializeField] float TimeOfDay;
    [SerializeField] Light[] FrontLight;
    [SerializeField] Light[] BackLight;
    [SerializeField] Light[] Flasher;
    public UnderLightColliders right, left, front, back;
    public GameObject FrontObject, RightObject, LeftObject, BackObject;
    bool Is_DayTime = true;
    bool Is_Breaking = false;
    bool Is_Player = false;
    void Start()
    {
        if (transform.parent.tag == "Player")
            Is_Player = true;
        Sun = FindObjectOfType<DayCycle>();
        Is_DayTime = Sun.IsDay;
        InDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_DayTime != Sun.IsDay)
        {
            Is_DayTime = Sun.IsDay;
            InDay();
        }
    }
    void InDay()
    {
        foreach (var item in FrontLight)
        {
            item.enabled = !Is_DayTime;
        }
        foreach (var item in BackLight)
        {
            item.enabled = !Is_DayTime;
            if (Is_DayTime)
                item.transform.parent.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            else
                item.transform.parent.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            Is_DayTime = Sun.IsDay;
        }
    }
}
