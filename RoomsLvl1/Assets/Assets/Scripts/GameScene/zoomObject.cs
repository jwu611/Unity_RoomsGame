using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomObject : MonoBehaviour
{

    public static int objectNum;
    public static bool zoomIn = false;
    
    Vector3 cam1Pos = new Vector3(3, 2, -15);
    Vector3 cam2Pos = new Vector3(-3, 2, -15);
    Vector3 cam3Pos = new Vector3(0, 1, -15);
    Vector3 cam4Pos = new Vector3(-1.2f, -0.5f, -15);
    float cam1FOV = 18;
    float cam2FOV = 11;
    float cam3FOV = 4;
    float cam4FOV = 4;

    private clockInput clockIn;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       /*if(objectNum == 1) //clockPic Cam
        {
            transform.position = cam1Pos;
            GetComponent<Camera>().fieldOfView = cam1FOV;
        }
        else if(objectNum == 2) //wallClock Cam
        {
            SetClock(true);
            transform.position = cam2Pos;
            GetComponent<Camera>().fieldOfView = cam2FOV;
           
        }
       else if(objectNum == 4)
        {
            transform.position = cam2Pos;
            GetComponent<Camera>().fieldOfView = cam2FOV;
            SetClock(false);
        }*/

        switch (objectNum)
        {
            case 1: //Clock Pic zoom
                transform.position = cam1Pos;
                GetComponent<Camera>().fieldOfView = cam1FOV;
                break;

            case 2: //Clock zoom
                SetClock(true); 
                transform.position = cam2Pos;
                GetComponent<Camera>().fieldOfView = cam2FOV;
                break;

            case 3: //Music sheet zoom
                transform.position = cam3Pos;
                GetComponent<Camera>().fieldOfView = cam3FOV;
                break;

            case 4: //Door lock zoom
                transform.position = cam4Pos;
                GetComponent<Camera>().fieldOfView = cam4FOV;
                break;

            case 5: //Back button reset zoom
                transform.position = cam2Pos;
                GetComponent<Camera>().fieldOfView = cam2FOV;
                SetClock(false);
                break;


        }
        
        GetComponent<Camera>().enabled = zoomIn;
        objectNum = 0;


    }

    public void SetClock(bool active)
    {
        clockButtons.cButton1.SetActive(active);
        clockIn.inputField.SetActive(active);
        clockIn.inputObj.SetActive(active);
    }

    private void Awake()
    {
        clockIn = GameObject.FindObjectOfType<clockInput>();
    }
}
