using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public static List<Spawner> Lines;
    public static float GlobalSpeed = 5f;
    public static bool Is_Accident = false;
    //[Range(0, 1)]
    //public static float ChangeLineSpeed = 0.5f;
    //[Range(0, 1)]
    //public static float RotateSpeed = 0.5f;

    [SerializeField] float PGlobalSpeed = 5f;
    [SerializeField] int changeAmount = 0;
    //[Range(0, 1)]
    //[SerializeField]
    //float PChangeLineSpeed = 0.5f;
    //[Range(0, 1)]
    //[SerializeField]
    //float PRotateSpeed = 0.5f;
    //[SerializeField] int MaxCarInGame = 10;
    void Start()
    {
        //Lines = FindObjectsOfType<Spawner>().ToList();
        //StartCoroutine(DestroyUnwantedCars());
    }
    private void Update()
    {
        GlobalSpeed = PGlobalSpeed;
        //ChangeLineSpeed = PChangeLineSpeed;
        //RotateSpeed = PRotateSpeed;
    }
    //IEnumerator DestroyUnwantedCars()
    //{
    //    yield return new WaitForSeconds(1f);
    //    var temp = FindObjectsOfType<cars>();
    //    var temp2 = FindObjectsOfType<NormCars>();
    //    if (temp.Length > MaxCarInGame || temp2.Length > MaxCarInGame)
    //    {
    //        if (temp.Length > MaxCarInGame)
    //            Destroy(temp[0].gameObject);
    //        if (temp2.Length > MaxCarInGame)
    //            Destroy(temp2[0].gameObject);
    //    }
    //    StartCoroutine(DestroyUnwantedCars());
    //}
}
