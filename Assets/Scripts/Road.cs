using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    Material Rmaterial;
    [SerializeField] float speed;
    [SerializeField] Vector2 widthOfRoad = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Rmaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Rmaterial.mainTextureOffset += new Vector2(1 * speed * Time.deltaTime, 0);
        if (Rmaterial.mainTextureOffset.x > 10)
            Rmaterial.mainTextureOffset = Vector2.zero;
    }
}
