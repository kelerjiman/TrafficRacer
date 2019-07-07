using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 30f;
    [SerializeField] List<GameObject> PrefabList;
    [SerializeField] int counter;
    [Header("respawn time (x=min , y= max")]
    [Tooltip("Edit the X to Zero and  Y for random respawn")]
    [SerializeField]
    Vector2 RespawnTimer = new Vector2(1f, 5f);
    public bool reverseLine = false;
    void Start()
    {
        StartCoroutine(RewpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator RewpawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(RespawnTimer.x, RespawnTimer.y));
        counter = Random.Range(0, PrefabList.Count);
           var x = Instantiate(PrefabList[counter], transform.position,Quaternion.identity);
        x.transform.parent = transform;
        x.tag = "Obs";
        if (reverseLine)
        {
            
            x.transform.rotation = Quaternion.Inverse(transform.rotation);
            x.GetComponent<cars>().Inverse = true;
            x.GetComponent<cars>().Zspeed = Speed * 2 +Random.Range(0,10);
        }
        else
        {
            x.GetComponent<cars>().Zspeed = -Speed-Random.Range(1,30);
        }
        StartCoroutine(RewpawnDelay());
    }
}
