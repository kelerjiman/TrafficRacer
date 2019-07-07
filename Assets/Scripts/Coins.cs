using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int CoinLevel;
    [SerializeField] AudioClip CoinVFX;
    [SerializeField] float RotationSpeed;
    [SerializeField] float Speed = 0;
    AudioSource AS;
    Rigidbody rig;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AS.Play();
            Destroy(gameObject, CoinVFX.length);
        }

    }
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
        AS = GetComponent<AudioSource>();
        AS.clip = CoinVFX;
    }

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.magnitude == 0)
            rig.velocity = new Vector3(0, 0, -Speed);
        if (rig.velocity.magnitude > 0)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, RotationSpeed + transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
