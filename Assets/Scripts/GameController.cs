using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject[] spawnSpots;
    private float m_StartTime = 200000;  // 运行2s后开始生成
    private float m_LoopTime = 1;
    private float m_RemainedTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpots = GameObject.FindGameObjectsWithTag("SpawnSpot");
        m_RemainedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_StartTime <= 0)
        {
            // 如果已经开始，就减少remainedtime
            m_RemainedTime -= Time.deltaTime;
            if (m_RemainedTime <= 0)
            {
                m_RemainedTime = m_LoopTime;  //重置循环时间
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = 
                    spawnSpots[Random.Range(0, spawnSpots.Length)].transform.position;
            }
        }
        else
        {
            //如果还没开始，就减少startTime
            m_StartTime -= Time.deltaTime;
        }
    }
}
