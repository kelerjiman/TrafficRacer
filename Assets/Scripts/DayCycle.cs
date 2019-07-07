using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 DefRotation;
    public float MinMaxAngle = 0f;
    public bool IsDay = true;
    [SerializeField] float MinPerSec = 60f;
    [SerializeField] Light Sun, Moon;
    void Start()
    {
        Sun = gameObject.GetComponent<Light>();
        Moon = transform.Find("Moon").GetComponent<Light>();
        MinMaxAngle = Random.Range(0f, 359f);
        DefRotation = new Vector3(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        //if (IsDay)
        //    MinMaxAngle = Random.Range(0, 180f);

        //else
        //    MinMaxAngle = Random.Range(180f, 360f);
        transform.rotation = Quaternion.Euler(MinMaxAngle, DefRotation.y, DefRotation.z);

    }

    // Update is called once per frame
    void Update()
    {
        DayNightFunc();
        NightBehavior();
    }
    void DayNightFunc()
    {
        if (MinMaxAngle < 180)
            IsDay = true;
        else
        {
            IsDay = false;
            Sun.intensity = 0.01f;
        }
        transform.rotation = Quaternion.Euler(MinMaxAngle, DefRotation.y, DefRotation.z);
        MinMaxAngle += MinPerSec * Time.deltaTime;
        if (MinMaxAngle >= 360)
            MinMaxAngle -= 360f;
        if (MinMaxAngle <= -360)
            MinMaxAngle += 360f;
    }
    void NightBehavior()
    {
        if (IsDay)
        {
            Sun.intensity = 0.75f;
            return;
        }
    }
}
