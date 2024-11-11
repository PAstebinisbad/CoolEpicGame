using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayWhenClicked : MonoBehaviour
{
    public GameObject Canvas;
    
    public void ButtonPressed()
    {
        PlayerMovement Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (Player)
        {
            Canvas.SetActive(false);
            Player.StartGame();
        }    
    }

}

