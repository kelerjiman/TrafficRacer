using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class EncDecSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]bool IsEncSpeed=false;
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
            EncDecFunc();
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

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.magnitude == 0)
            rig.velocity = new Vector3(0, 0, -Speed);
        if (rig.velocity.magnitude > 0)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, RotationSpeed + transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    void EncDecFunc()
    {
        if (IsEncSpeed)
        {
            print("Encrease speed is triggered");
        }
        else
        {
            print("Decrease speed is triggered");

        }
    }
}
