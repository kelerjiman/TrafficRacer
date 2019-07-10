using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Angle = 30;
    NormCars NormalCars;
    Quaternion NewRot;
    [SerializeField]
    [Range(0, 1)]
    float H_R_Speed = 0.5f;
    void Start()
    {
        NewRot = transform.rotation;
        NormalCars = transform.parent.GetComponent<NormCars>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NormalCars.TimeToTurn)
        {
            NewRot = transform.rotation;
            if (NormalCars.GoRight)
                NewRot = Quaternion.AngleAxis(NewRot.eulerAngles.y + 1, Vector3.up);
            else
            if (NormalCars.GoLeft)
                NewRot = Quaternion.AngleAxis(NewRot.eulerAngles.y - 1, Vector3.up);
        }
        else
            NewRot = Quaternion.Lerp(NewRot, Quaternion.identity, GameManager.RotateSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, GameManager.RotateSpeed);
    }
}
