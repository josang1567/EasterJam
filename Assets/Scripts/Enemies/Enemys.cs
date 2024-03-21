using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemys : MonoBehaviour
{
    //reward
    public int rewardPos;
    //ai nav
    private NavMeshAgent agent;
    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;
    Vector3 startPos;
    public enum behaviour
    {
        flee,
        walk,
        stay
    }
    public behaviour currentBehaviour;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        enemyBehaviour();
    }

    void enemyBehaviour()
    {
        switch (currentBehaviour)
        {
            case behaviour.flee:
                flee();
                break;
            case behaviour.walk:

                break;
            case behaviour.stay:
                stay();
                break;
        }
    }
    void flee()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(new Vector3(newPos.x, newPos.y, transform.position.z));
            Debug.Log("Distance: " + distance);

        }
    }
    void walk()
    {

    }
    void stay()
    {

    }
}
