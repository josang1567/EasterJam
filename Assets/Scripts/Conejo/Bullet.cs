using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public AudioClip sound;
    public AudioSource audioSource;

    void Start()
    {
        
        audioSource.PlayOneShot(sound);
       
        Destroy(gameObject,3);
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<EnemyStats>()==true)
        {

            GameManager.GMInstance.deleteDuck(collision.gameObject.GetComponentInChildren<EnemyStats>().zoneName.ToString());
            collision.gameObject.GetComponent<EnemyDeath>().death();
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Valla")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Dog")
        {
            collision.gameObject.GetComponent<EnemyDeath>().death();

            Destroy(gameObject);
        }

    }
}
