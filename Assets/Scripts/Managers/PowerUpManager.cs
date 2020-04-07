using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PowerUpManager : MonoBehaviour
{
    public Transform[] RespawnPosition;
    public GameObject[] coinPrefabs;
    public GameObject[] otherPrefabs;
    [SerializeField] int m_PuIndex = 0;
    [SerializeField] int m_Distance = 5;
    [SerializeField] Vector2 Delay = Vector2.zero;
    private GameObject m_currentObj;
    float m_ZPos;
    float m_Coin_Counter = 0;
    [SerializeField] float m_CTimer = 0;
    float m_Other_Counter = 0;
    [SerializeField] float m_OTimer = 0;
    Movement m_Player;
    void Start()
    {
        m_Player = FindObjectOfType<Movement>();
        m_ZPos = m_Player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        m_Coin_Counter += Time.deltaTime;
        m_Other_Counter += Time.deltaTime;
        CoinSpawner();
        OtherPUSpawner();
    }
    public void CoinSpawner()
    {
        if (m_ZPos + m_Distance <= m_Player.transform.position.z && m_Coin_Counter >= m_CTimer)
        {
            var _coin = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
            float random;
            random = Random.Range(Delay.x, Delay.y);
            if (_coin.name == "Baloon")
            {
                if (random < 5)
                    SpawnPU(_coin);
            }
            else
            {
                SpawnPU(_coin);
            }
            m_ZPos = m_Player.transform.position.z;
            m_Coin_Counter = 0;
        }
    }
    public void OtherPUSpawner()
    {
        if (m_Other_Counter >= m_OTimer)
        {
            int RandomIndex = Random.Range(0, otherPrefabs.Length);
            int random = Random.Range(0, 100);
            if (random <= 25)
                SpawnPU(otherPrefabs[RandomIndex]);
            m_Other_Counter = 0;
        }
    }
    public void SpawnPU(GameObject PowerUp)
    {
        m_PuIndex = Random.Range(0, 3);
        Instantiate(PowerUp, RespawnPosition[m_PuIndex].position, Quaternion.identity);
    }

}
