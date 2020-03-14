using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : GenericSpawner
{
    public override void Start()
    {
        base.Start();
        Timer = Random.Range(randomTimeRange.x, randomTimeRange.y);
    }
    public override void Update()
    {
        base.Update();
        m_Timer += Time.deltaTime;
        if (m_Timer >= Timer)
        {
            SpawnObjects();
            m_Timer = 0;
            Timer = Random.Range(randomTimeRange.x, randomTimeRange.y);
        }
    }
}
