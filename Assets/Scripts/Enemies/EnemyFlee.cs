using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    
    //ai nav
    private NavMeshAgent agent;
    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;
   public int xMax,xMin, yMax,Ymin;
    bool updateRotation, updateUpAxis;
    public bool Rotate = false;
     [SerializeField]Vector3 destiny;

    public enum behaviour
    {
        flee,
        walk
    }
    public behaviour currentBehaviour;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        newDestinationPoint();

    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerDistance();
        enemyBehaviour();
        if (Rotate==true && destiny != null)
        {
            rotateTowardsPoint(destiny);

        }

    }

    void enemyBehaviour()
    {
        switch (currentBehaviour)
        {
            case behaviour.flee:
                flee();
                break;
            case behaviour.walk:
                walk();
                break;
           
        }
    }
    void checkPlayerDistance()
    {
       
        
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance < EnemyDistanceRun)
            {
            
                currentBehaviour = behaviour.flee;
            }
            else
            {
            currentBehaviour = behaviour.walk;    
            }
        
        
    }
    void flee()
    {

        Vector3 dirToPlayer = transform.position - Player.transform.position;
        Vector3 newPos = transform.position + dirToPlayer;
        agent.SetDestination(new Vector3(newPos.x, newPos.y, transform.position.z));
        destiny = newPos;



    }
    void walk()
    {

      
        if (agent.remainingDistance <= 0.1)
        {
           
            newDestinationPoint();                    
        }
        agent.SetDestination(destiny);
    }
        
     
    void newDestinationPoint()
    {
        Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(Ymin, yMax), transform.position.z);
        destiny = newPos;
    }
    void rotateTowardsPoint(Vector3 pos)
    {
        Vector2 direction = pos - transform.position;

        float angleRadians = Mathf.Atan2(direction.y, direction.x);

        float targetAngle = angleRadians * Mathf.Rad2Deg;

        float turnSpeed = 10;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime);

    }
   
}
