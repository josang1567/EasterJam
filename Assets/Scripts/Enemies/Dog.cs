using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<RabbitMovement>().transform.position = collision.gameObject.GetComponent<RabbitMovement>().checkpoint.transform.position; 

        }
    }
}
