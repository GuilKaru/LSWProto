using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutfitChanger : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused;

    public Image image;
    
    //Create List of the Outfits you can Equip
    public List<Sprite> options = new List<Sprite>();
    
    [HideInInspector]
    public int currentOption = 0;

    // Next and Previous Outfits
    public void NextOption()
    {
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }
        
        image.sprite = options[currentOption];
    }

    public void PreviousOption()
    {
        currentOption--;
        if(currentOption < 0)
        {
            currentOption = options.Count - 1;
        }
        image.sprite = options[currentOption];
        
    }
   
    
}
