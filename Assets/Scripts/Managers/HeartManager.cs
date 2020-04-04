using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public GameObject HeartPrefab;
    public List<GameObject> children;
    int lenght;
    Movement player;
    private void Start()
    {
        player = FindObjectOfType<Movement>();
        for (int i = 0; i < player.health; i++)
        {
            children.Add(Instantiate(HeartPrefab, transform.position, Quaternion.identity));
            children[i].transform.parent = transform;
        }
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
