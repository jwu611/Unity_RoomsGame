using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction(bool b);
    public static event ClickAction OnClicked;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()// for box colliders on kingBox and chessBox in room1Complete
    {
        if(OnClicked != null)
        {
            OnClicked(true);
        }
    }

}
