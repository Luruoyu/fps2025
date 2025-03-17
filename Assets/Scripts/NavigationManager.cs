using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationManager : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    //[SerializeField]
    //private float m_StopDistance;
    private GameObject player;
    private ZombieController m_ZombieController;
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = this.GetComponent<NavMeshAgent>();
        m_ZombieController = this.GetComponent<ZombieController>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        AgentBehavior();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    private void AgentBehavior()
    {
        float m_Distance = Vector3.Distance(this.transform.position, player.transform.position);
        //Debug.Log(m_Distance);
        if (m_Distance > m_Agent.stoppingDistance)
        {
            WalkToPlayer();
        }
        else
        {
            Stop();
        }
    }

    private void WalkToPlayer()
    {
        m_Agent.destination = player.transform.position;
        m_Agent.isStopped = false;
        m_ZombieController.Walk();
    }

    private void Stop()
    {
        m_Agent.isStopped = true;
        m_ZombieController.Attack();
    }
}
