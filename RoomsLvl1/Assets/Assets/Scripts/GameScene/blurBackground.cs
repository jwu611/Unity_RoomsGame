using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blurBackground : MonoBehaviour
{
   
    
    public GameObject blurScreen;
    public PuzzleMode puzzleMode;


    //GameObject backPanel;
    //GameObject objSprite;

    /*/private void OnEnable()
    {
        EventManager.OnClicked += ToggleBlur;
        

    }

    private void OnDisable()
    {
        EventManager.OnClicked -= ToggleBlur;
        
    }*/

   

    public void SetBlur()
    {
        blurScreen.SetActive(true);
        puzzleMode.SetColliders(false);
        
        
        //backPanel.SetActive(b);
        //objSprite.SetActive(b);


    }

    

    private void Start()
    {
        

        //blurScreen = GameObject.Find("Blur Screen");
        if(blurScreen != null)
            blurScreen.SetActive(false);

        //backPanel = GameObject.Find("Back Panel");
        //objSprite = GameObject.Find("Zoom In Sprite");
       
        //backPanel.SetActive(false);
        //objSprite.SetActive(false);

        //EventManager.OnClicked += ToggleBlur;
        
    }
}
