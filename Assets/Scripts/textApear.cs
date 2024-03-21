using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textApear : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Animator>().Play("Vanish");
    }
}
