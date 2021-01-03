using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class clockPicAction : MonoBehaviour
{   
    // Start is called before the first frame update
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        zoomObject.zoomIn = !zoomObject.zoomIn;
        zoomObject.objectNum = 1;
    }
}
