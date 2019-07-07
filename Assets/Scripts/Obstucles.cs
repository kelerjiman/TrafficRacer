using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstucles : MonoBehaviour
{
    // Start is called before the first frame update
    public float Zspeed = -2f, Xspeed, DefaultSpeed;
    public bool Inverse = false;
    border GBorder;
    Rigidbody rig;
    [SerializeField] bool stop = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ground")
            Destroy(gameObject);
    }
    void Start()
    {
        if (gameObject.GetComponents<BoxCollider>().Length == 0)
            gameObject.AddComponent<BoxCollider>().enabled = true;
        if (gameObject.GetComponents<MeshCollider>().Length > 0)
            Destroy(GetComponent<MeshCollider>());
        rig = GetComponent<Rigidbody>();
        rig.useGravity = true;
        GBorder = FindObjectOfType<border>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Inverse)
            transform.rotation = Quaternion.LookRotation(GBorder.transform.position);
        if (!stop)
            transform.Translate(0, 0, Zspeed * Time.deltaTime);
    }
}
