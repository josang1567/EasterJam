using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField, Tooltip("Tiempo en segundos")] private float timerTime=0;
    private int minutes, seconds;


    private void FixedUpdate()
    {

        timerTime += Time.deltaTime;

        if (timerTime < 0)
            timerTime = 0;

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime % 60f);


        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }


}

