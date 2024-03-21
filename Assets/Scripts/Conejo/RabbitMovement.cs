using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitMovement : MonoBehaviour
{
    public Vector3 Mouse;
    [SerializeField] private Camera camera;
    Vector3 moveDirection;
    [SerializeField] public float speed = 5;
    Animator animator;
    public bool rotate = false;
    public GameObject checkpoint;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        move();
        if (rotate == true)
        {
            rotateTowardsMouse();
        }
    }

    void move()
    {
       

        float h;
        float v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;

        if (animator != null)
        {
            if (h < 0)
            {
                animator.Play("rabbitMoveX-1");
            }
            else
       if (h > 0)
            {
                animator.Play("rabbitMoveX1");
            }
            else
       if (v < 0)
            {
                animator.Play("rabbitMoveY-1");
            }
            else
       if (v > 0)
            {
                animator.Play("rabbitMoveY1");
            }
        }
       

        transform.position += moveDirection * Time.deltaTime * speed;
    }
    public void rotateTowardsMouse()
    {

        Mouse = camera.ScreenToWorldPoint(Input.mousePosition);
        float anguloRadianes = Mathf.Atan2(Mouse.y - transform.position.y, Mouse.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);

    }
}
