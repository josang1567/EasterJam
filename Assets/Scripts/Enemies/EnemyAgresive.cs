using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgresive : MonoBehaviour
{

    //ai nav
    private NavMeshAgent agent;
    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;
    public int xMax, xMin, yMax, Ymin;
   
    public bool Rotate = false;
    [SerializeField] Vector3 destiny;

    public AudioClip sound;
    public AudioSource audioSource;
    bool isPlaying = false;

    public enum behaviour
    {
        chase,
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
        if (Rotate == true && destiny != null)
        {
            rotateTowardsPoint(destiny);

        }

    }

    void enemyBehaviour()
    {
        switch (currentBehaviour)
        {
            case behaviour.chase:
                chase();
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

            currentBehaviour = behaviour.chase;
        }
        else
        {
            if (agent.destination == Player.transform.position)
            {
                newDestinationPoint();
            }
            currentBehaviour = behaviour.walk;
        }


    }
    void chase()
    {

        bark();
        agent.SetDestination(Player.transform.position);
        destiny = agent.destination;



    }
    void walk()
    {


        if (agent.remainingDistance <= 0.1)
        {

            newDestinationPoint();
        }
        agent.SetDestination(destiny);
    }

    IEnumerator bark()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sound);
            yield return new WaitForSeconds(sound.length);
        }
       
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
