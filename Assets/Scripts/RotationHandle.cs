using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float Angle = 6, Input_setY = 0
        , maxAngle, minAngle;
    [SerializeField]
    float H_R_Speed = 0;
    cars InverseCar;
    border GBorder;
    Quaternion DefRot, NewRot;
    bool Is_Inverse = false;
    void Start()
    {
        //    NewRot = transform.rotation;
        //    DefRot = NewRot;
        //    //H_R_Speed = GameManager.RotateSpeed;
        //    GBorder = FindObjectOfType<border>();
        //    //Is_Inverse = transform.parent.parent.GetComponent<Spawner>().reverseLine;
        //    if (Is_Inverse)
        //    {
        //        InverseCar = transform.parent.GetComponent<cars>();
        //    }
        //    else
        //        NormalCars = transform.parent.GetComponent<NormCars>();

        //    maxAngle = transform.rotation.eulerAngles.y + 6;
        //    minAngle = transform.rotation.eulerAngles.y - 6;
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    //H_R_Speed = GameManager.RotateSpeed;
        //    Direction();
        //    Handling();
        //}
        //void Direction()
        //{
        //    if (Is_Inverse)
        //        EnveseCarDirection();
        //    else
        //        NormCarDirection();
        //}

        //void EnveseCarDirection()
        //{
        //    if (InverseCar.TimeToTurn)
        //    {
        //        if (InverseCar.GoRight)
        //        {
        //            Input_setY = +1;
        //        }
        //        if (InverseCar.GoLeft)
        //        {
        //            Input_setY = -1;
        //        }
        //    }
        //    if (!InverseCar.TimeToTurn || InverseCar.NoWay || !InverseCar.KnowDir)
        //    {
        //        Input_setY = 0;
        //    }
        //}
        //void NormCarDirection()
        //{
        //    if (NormalCars.TimeToTurn)
        //    {
        //        if (NormalCars.GoRight)
        //        {
        //            Input_setY = +1;
        //        }
        //        if (NormalCars.GoLeft)
        //        {
        //            Input_setY = -1;
        //        }
        //    }
        //    if (!NormalCars.TimeToTurn || NormalCars.NoWay || !NormalCars.KnowDir)
        //    {
        //        Input_setY = 0;
        //    }
        //}

        //void Handling()
        //{
        //    if (transform.eulerAngles.y < maxAngle && Input_setY == 1)
        //        NewRot = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Input_setY, 0);
        //    if (transform.eulerAngles.y > minAngle && Input_setY == -1)
        //        NewRot = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Input_setY, 0);
        //    if (Input_setY != 0)
        //    {
        //        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, H_R_Speed);
        //        print(transform.rotation.eulerAngles.y);
        //    }
        //    else
        //    {
        //        transform.rotation = Quaternion.Lerp(transform.rotation, DefRot, H_R_Speed);

        //    }
    }
}
