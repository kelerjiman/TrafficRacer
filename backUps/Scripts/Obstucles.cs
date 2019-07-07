using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstucles : MonoBehaviour
{
    // Start is called before the first frame update
    public float Zspeed = -0.5f, Xspeed;
    [SerializeField] bool stop = false;
    [SerializeField] Vector3 CustomSize = new Vector3(1.5f, 1.5f, 1.5f);
    private void OnCollisionEnter(Collision collision)
    {

    }
    void Start()
    {
        tag = "Obs";
        transform.localScale = CustomSize;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Zspeed);
    }
}
