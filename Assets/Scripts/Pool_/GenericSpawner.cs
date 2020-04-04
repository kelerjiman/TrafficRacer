using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public Vector2 randomTimeRange = Vector2.zero;
    [SerializeField]
    protected string Tag = string.Empty;
    [SerializeField]
    protected GameObject respawnPoint = null;
    protected float Timer = 0;
    protected float m_Timer = 0f;
    [SerializeField] protected ObjectPooler OP;

    public virtual void Start()
    {

    }
    public virtual void Update()
    {

    }
    public virtual void SpawnObjects()
    {
        if (!GameManager.Instance.GM_Is_Accident)
            OP.SpawnFromPool(Tag, respawnPoint.transform.position, respawnPoint.transform.rotation);
    }
}
