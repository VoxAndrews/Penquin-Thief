﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool inGame;

    GameObject currentMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(inGame == false)
        {
            Time.timeScale = 0; //Freezes time so game freezes

            Cursor.lockState = CursorLockMode.Confined; //Locks cursor to the game view (Cannot move mouse outside of it, only works in BUILD, not EDITOR)
            Cursor.visible = true; //Shows Cursor
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateInfo()
    {
        Time.timeScale = 1; //Freezes time so game freezes

        currentMenu = GameObject.Find("Level Info");
        Cursor.visible = false; //Hides Cursor
        inGame = true;

        currentMenu.SetActive(false);
    }

    void ActivateMenu()
    {

    }

    void DeactivateMenu()
    {

    }
}