using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
     public GameObject padre; 

    public void death()
    {
        Destroy(padre);
    }
}
