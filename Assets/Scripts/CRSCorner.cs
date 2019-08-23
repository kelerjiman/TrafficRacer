using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRSCorner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int ChangeConsPos = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var x = FindObjectOfType<ConstantBehavior>();
            x.NewXPos = x.transform.position.x + ChangeConsPos;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
