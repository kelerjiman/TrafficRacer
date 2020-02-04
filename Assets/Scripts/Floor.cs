using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the+ first frame update
    [SerializeField] float speed;
    [SerializeField] GameObject[] prefabsList;
    public GameObject car;
    public GameObject carHolder;
    void Start()
    {
        car = prefabsList[0];
        var temp = Instantiate(car);
        temp.transform.parent = transform;
        temp.transform.position = carHolder.transform.position;
        temp.transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
    public void OnChangeCar(int Index)
    {

    }
}
