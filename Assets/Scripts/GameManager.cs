using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int EggsFound = 0;
    public int EggsLeft = 0;
    public int duckOnZonaA;
    public int duckOnZonaB;
    public int duckOnZonaC;
    public int duckOnZonaD;

    public GameObject[] doors;


    public GameObject[] eggSprite;

    public static GameManager GMInstance;

    public TMP_Text DucksOnZone;
    public GameObject[]  alerts;

    public int totalDucks = 0;

    [SerializeField] private TMP_Text timerText;
    [SerializeField, Tooltip("Tiempo en segundos")] private float timerTime = 0;
    private int minutes, seconds;



    private void Awake()
    {
        if (GMInstance == null)
        {
            GMInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameObject[] ducksTotal = GameObject.FindGameObjectsWithTag("EasterDuck");
        totalDucks=ducksTotal.Length;

        DucksOnZone.text = duckOnZonaA.ToString();
        checkDucks();

        EggsLeft = eggSprite.Length;
    }

    // Update is called once per frame
    void Update()
    {
        checkDucksOnZone();
    }
    public void eggFound(int eggType)
    {
        eggSprite[eggType].gameObject.SetActive(true);
        EggsLeft--;
        EggsFound++;

    }

    void checkDucksOnZone()
    {
        if (duckOnZonaA == 0)
        {
            doors[0].SetActive(false);
            alerts[0].SetActive(true);
            //alerts[0].GetComponent<Animator>().Play("Vanish");

        }
        if (duckOnZonaB == 0)
        {
            doors[1].SetActive(false);
            alerts[1].SetActive(true);
            //alerts[1].GetComponent<Animator>().Play("Vanish");

        }
        if (duckOnZonaC == 0)
        {
            doors[2].SetActive(false);
            alerts[2].SetActive(true);
           // alerts[2].GetComponent<Animator>().Play("Vanish");

        }
        if (duckOnZonaD == 0)
        {
            int finalPoints = (((totalDucks*25)-(int)timerTime)*(1+EggsFound));
            PlayerPrefs.SetInt("finalPoints", finalPoints);
            PlayerPrefs.SetString("TimeLeft", timeConverter());
            SceneManager.LoadScene("DemoScene");
        }
    }
    public void checkDucks()
    {

        GameObject[] ducksOnGame = GameObject.FindGameObjectsWithTag("EasterDuck");

        for (int i = 0; i < ducksOnGame.Length; i++)
        {

            if (ducksOnGame[i].GetComponentInChildren<EnemyStats>().zoneName.ToString() == "zonaA")
            {
                duckOnZonaA++;
            }
            if (ducksOnGame[i].GetComponentInChildren<EnemyStats>().zoneName.ToString() == "zonaB")
            {
                duckOnZonaB++;
            }
            if (ducksOnGame[i].GetComponentInChildren<EnemyStats>().zoneName.ToString() == "zonaC")
            {
                duckOnZonaC++;
            }
            if (ducksOnGame[i].GetComponentInChildren<EnemyStats>().zoneName.ToString() == "zonaD")
            {
                duckOnZonaD++;
            }
        }
    }


    private void FixedUpdate()
    {

        timerTime += Time.deltaTime;

        if (timerTime < 0)
            timerTime = 0;

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime % 60f);


        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }

    string timeConverter()
    {
        string timeFormated;



        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime % 60f);


        timeFormated = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timeFormated;


    }

    public void deleteDuck(string zone)
    {

        switch (zone)
        {
            case "zonaA":
                duckOnZonaA--;
                DucksOnZone.text = duckOnZonaA.ToString() + " left";
                if (duckOnZonaA <= 0)
                {
                    DucksOnZone.text = "No Ducks left on Area";

                }


                break;
            case "zonaB":
                duckOnZonaB--;
                DucksOnZone.text = duckOnZonaB.ToString() + " left";
                if (duckOnZonaB <= 0)
                {
                    DucksOnZone.text = "No Ducks left on Area";

                }

                break;
            case "zonaC":
                duckOnZonaC--;
                DucksOnZone.text = duckOnZonaC.ToString() + " left";
                if (duckOnZonaC <= 0)
                {
                    DucksOnZone.text = "No Ducks left on Area";

                }
                break;
            case "zonaD":
                duckOnZonaD--;
                DucksOnZone.text = duckOnZonaD.ToString() + " left";
                if (duckOnZonaD <= 0)
                {
                    DucksOnZone.text = "No Ducks left on Area";

                }
                break;

        }

    }
}
