using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class palanca : MonoBehaviour
{
    public Sprite palancaActivada;
    public Sprite palancaDesActivada;
    public GameObject pared;
    public enum mode
    {
        Button,
        Switch
    }
    public mode type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           

            if (pared != null)
            {
                action();
            }

        }
    }

    void action()
    {
        switch (type)
        {

            case mode.Button:
                GetComponent<SpriteRenderer>().sprite = palancaActivada;

              
                    pared.SetActive(false);
                
                break;
                case mode.Switch:
                if (pared.gameObject.activeSelf == false)
                {
                    GetComponent<SpriteRenderer>().sprite = palancaDesActivada;
                    pared.SetActive(true);

                }
                else
                {
                    pared.SetActive(false);
                    GetComponent<SpriteRenderer>().sprite = palancaActivada;

                }
                break;

        }

        
    }
}
