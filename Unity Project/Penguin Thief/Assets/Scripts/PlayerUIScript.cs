﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Brought in to control the UI Elements
using TMPro; //Includes commands for TextMesh Pro

/*
 *  Player UI Script (VER 1, 15-05-2020) 
 *  
 *  ATTACH TO 'playerUI' OBJECT IN SCENE HIERARCHY
 *  
 *  NOTE: NEED TO ADD SCROLL FUNCTIONALITY
 *  
 *  Description:
 *      - This script controls the visibility/positions of various elements for the Player's UI, these functions including:
 *          - Switching the UI Icons for the Usable Items (Controlled by Scroll Wheel)
 *          - Controlling Collected Item UI Element
 *      
 *  Changelog:
 *      - 15-05-2020 (Darcy Wilson, 32926762):
 *          - Created ChangeUsableItem()
 *              
 *  Known Bugs:
 *      - N/A
*/

public class PlayerUIScript : MonoBehaviour
{
    public TextMeshProUGUI currentItemText; //Current Item player is Using
    public TextMeshProUGUI totalKeys; //Total Number of Keys the player has
    public TextMeshProUGUI totalCollectables; //Total Number of Collectables the player has

    string[] usableItemNames; //A list of names for the Usable Items
    int itemArrayNumber; //Current Array position player has selected

    void Awake()
    {
        usableItemNames = new string[] {"Grapple Gun", "Reaching Claw", "Cart", "Screwdriver"}; //Initialising the List of Suable Item names
        itemArrayNumber = -1; //Sets the Array to -1 to start with

        currentItemText.text = "No Items";
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.mouseScrollDelta.y > 0f) || (Input.mouseScrollDelta.y < 0f)) //Checks to see if the Scroll Wheel has been used before activating ChangeUsableItem()
        {
            ChangeUsableItem(); //Changes the current usable item
        }
    }

    void ChangeUsableItem() //Changes Usable Item UI Position
    {
        if (Input.mouseScrollDelta.y > 0f) //If the Scroll Wheel is scrolled up
        {
            Debug.Log("Scrolling Up");

            if(itemArrayNumber < 3) //Makes sure the player can only scroll up if the value is Lower than 3
            {
                itemArrayNumber++; //Increases array number
                currentItemText.text = usableItemNames[itemArrayNumber]; //Changes the TextMeshPro Text to current item selected
            }
        }

        if (Input.mouseScrollDelta.y < 0f) //If the Scroll Wheel is scrolled down
        {
            Debug.Log("Scrolling Down");

            if (itemArrayNumber > 0) //Makes sure the player can only scroll down if the value is Higher than 0
            {
                itemArrayNumber--; //Decreases array number
                currentItemText.text = usableItemNames[itemArrayNumber]; //Changes the TextMeshPro Text to current item selected
            }
        }
    }

    public void UpdateKeys(int newKeys) //Updates the current key total that the player has (totalKeys ('Total Keys' in Hierarchy))
    {
        totalKeys.SetText(newKeys.ToString()); //Sets the players number of Keys to the current total
    }

    public void UpdateCollectables(int newCollectables) //Updates the current collectables total that the player has (totalCollectables ('Total Collectables' in Hierarchy))
    {
        totalCollectables.SetText(newCollectables.ToString()); //Sets the players number of collectables to the current total
    }
}

/*
 * References:
 *      - https://docs.unity3d.com/ScriptReference/Input-mouseScrollDelta.html
 *      - https://www.geeksforgeeks.org/c-sharp-arrays-of-strings/
*/
