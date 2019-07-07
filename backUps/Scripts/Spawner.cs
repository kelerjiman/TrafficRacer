using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> PrefabList;
    [SerializeField] int counter;
    [Header("respawn time (x=min , y= max")]
    [Tooltip("leave the X to Zero and Edit Y for random respawn")]
    [SerializeField]
    Vector2 RespawnTimer = new Vector2(0f, 5f);
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
        GameObject x;
        if (reverseLine)
        {
            x = Instantiate(PrefabList[counter], transform.position, Quaternion.identity);
            x.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            x.GetComponent<Obstucles>().Zspeed *= -1;
        }
        else
        {
            x = Instantiate(PrefabList[counter], transform.position, Quaternion.identity);
        }
        StartCoroutine(RewpawnDelay());
    }
}
