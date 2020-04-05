using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public GameObject HeartPrefab;
    public List<GameObject> children;
    int lenght;
    Movement player;
    private void Awake()
    {
        player = FindObjectOfType<Movement>();
        for (int i = 0; i < player.health; i++)
        {
            var x = Instantiate(HeartPrefab, transform.position, Quaternion.identity);
            x.transform.parent = transform;
            x.transform.localScale = new Vector3(1, 1, 1);
            children.Add(x);
        }
    }
    private void Start()
    {

    }
    public void OnOffHandle()
    {
        GameObject temp = new GameObject();
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].GetComponent<heart>().IsHeartOn)
                temp = children[i];
            else
                break;
        }
        temp.GetComponent<heart>().Off();
    }
}
