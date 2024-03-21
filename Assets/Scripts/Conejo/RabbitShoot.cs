using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shootPos;
    bool gunLoaded = true;
    [SerializeField] public float fireRate = 1;
    public AudioClip sound;
    public AudioSource audioSource;
    void Start()
    {
      
    
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
           
            Instantiate(bulletPrefab, shootPos.transform.position, shootPos.transform.rotation).GetComponent<Bullet>().audioSource=audioSource;
            StartCoroutine(ReloadGun());
        }
    }
    IEnumerator ReloadGun()
    {
        audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(1 / fireRate);
        gunLoaded = true;
    }
}
