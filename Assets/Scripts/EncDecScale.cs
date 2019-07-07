using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class EncDecScale : MonoBehaviour
{
    [SerializeField] bool IsEncreaseScale = false;
    [SerializeField] int EncDecLevel;
    [SerializeField] AudioClip EncDecVFX;
    [SerializeField] float RotationSpeed;
    [SerializeField] float Speed = 0;
    AudioSource AS;
    Rigidbody rig;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AS.Play();
            Destroy(gameObject, EncDecVFX.length);
        }

    }
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
        AS = GetComponent<AudioSource>();
        AS.clip = EncDecVFX;
    }
    void Update()
    {
        if (rig.velocity.magnitude == 0)
            rig.velocity = new Vector3(0, 0, -Speed);
        if (rig.velocity.magnitude > 0)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, RotationSpeed + transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    void EncDecFunc()
    {
        if (IsEncreaseScale)
        {
            print("Encrease speed is triggered");
        }
        else
        {
            print("Decrease speed is triggered");

        }
    }
}
