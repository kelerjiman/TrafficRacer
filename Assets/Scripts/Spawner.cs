using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float GlobalSpeed = 30f;
    public bool doJob = false;
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
        GlobalSpeed = GameManager.GlobalSpeed;
    }
    IEnumerator RewpawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(RespawnTimer.x, RespawnTimer.y));
        if (doJob)
        {
            counter = Random.Range(0, PrefabList.Count);
            var x = Instantiate(PrefabList[counter], transform.position, Quaternion.identity, transform);
            if (reverseLine)
            {
                Destroy(x.GetComponent<NormCars>());
                x.transform.rotation = Quaternion.Inverse(transform.rotation);
                x.GetComponent<cars>().Inverse = true;
                x.GetComponent<cars>().Zspeed = GlobalSpeed * 2 * Random.Range(0.5f, 1);
            }
            else
            {
                Destroy(x.GetComponent<cars>());
                x.GetComponent<NormCars>().Zspeed = -GlobalSpeed;
            }
        }
        StartCoroutine(RewpawnDelay());
    }
}
