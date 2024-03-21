using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChange : MonoBehaviour
{
  public enum Zone
    {
        zonaA, zonaB, zonaC, zonaD
    }
    public Zone zoneName;
    public GameObject[] checkpoint;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.tag == "Player")
        {
            switch (zoneName)
            {

                case Zone.zonaA: 
                    GameManager.GMInstance.DucksOnZone.text = GameManager.GMInstance.duckOnZonaA.ToString() + " left";
                    if (GameManager.GMInstance.duckOnZonaA <= 0)
                    {
                        GameManager.GMInstance.DucksOnZone.text = "No Ducks left on Area";
                    }
                    collision.gameObject.GetComponent<RabbitMovement>().checkpoint = checkpoint[0];

                    break;
                case Zone.zonaB:
                    GameManager.GMInstance.DucksOnZone.text = GameManager.GMInstance.duckOnZonaB.ToString() + " left";
                    if (GameManager.GMInstance.duckOnZonaB <= 0)
                    {
                        GameManager.GMInstance.DucksOnZone.text = "No Ducks left on Area";

                    }
                    collision.gameObject.GetComponent<RabbitMovement>().checkpoint = checkpoint[1];

                    break;
                case Zone.zonaC:
                    GameManager.GMInstance.DucksOnZone.text = GameManager.GMInstance.duckOnZonaC.ToString() + " left";
                    if (GameManager.GMInstance.duckOnZonaC <= 0)
                    {
                        GameManager.GMInstance.DucksOnZone.text = "No Ducks left on Area";

                    }
                    collision.gameObject.GetComponent<RabbitMovement>().checkpoint = checkpoint[2];

                    break;
                case Zone.zonaD:
                    GameManager.GMInstance.DucksOnZone.text = GameManager.GMInstance.duckOnZonaD.ToString() + " left";
                    if (GameManager.GMInstance.duckOnZonaD <= 0)
                    {
                        GameManager.GMInstance.DucksOnZone.text = "No Ducks left on Area";

                    }
                    collision.gameObject.GetComponent<RabbitMovement>().checkpoint = checkpoint[3];

                    break;
            }
        }
    }
}
