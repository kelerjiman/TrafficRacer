using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> DecorationPrefabs;
    [SerializeField] bool IsRightSide = false;
    float sign = -1;
    public float Speed = 30f;
    public float DelayTime = 1f;
    [SerializeField] Vector2 PositionOfTrees = Vector3.zero;
    border GBorder;
    int counter = 0;
    float defPosX = 0;
    Vector3 defPos = Vector3.zero;
    void Start()
    {
        defPos = transform.position;
        defPosX = defPos.x;
        if (IsRightSide)
            sign *= sign;
        GBorder = FindObjectOfType<border>();
        StartCoroutine(RespawnDelay());
    }
    IEnumerator RespawnDelay()
    {
        var temp = Random.Range(PositionOfTrees.x, PositionOfTrees.y);
        counter = Random.Range(0, DecorationPrefabs.Count);
        yield return new WaitForSeconds(DelayTime);
        var x = Instantiate(DecorationPrefabs[counter]);
        x.transform.parent = transform;
        x.transform.position = new Vector3(sign * temp + defPosX , -0.5f, defPos.z);
        x.gameObject.AddComponent<Obstucles>().Zspeed = Speed;
        x.tag = "Obs";
        x.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        StartCoroutine(RespawnDelay());
    }
}
