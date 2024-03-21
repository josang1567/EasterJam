using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Vector3 Mouse;
    [SerializeField] private Camera camera;
    public GameObject[] pages;
    public GameObject rabbit;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateRabbit();
    }
    public void rotateRabbit()
    {

        Mouse = camera.ScreenToWorldPoint(Input.mousePosition);
        float anguloRadianes = Mathf.Atan2(Mouse.y - rabbit.transform.position.y, Mouse.x - rabbit.transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
       rabbit.transform.rotation = Quaternion.Euler(0, 0, anguloGrados);

    }
    



}
