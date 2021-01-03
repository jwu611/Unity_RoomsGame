using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorLock : MonoBehaviour
{
    public GameObject codeInputField;
    public GameObject codeInput;
    public GameObject completionText;
    public GameObject setCodeButton;
    public GameObject unlockedDoorCollider;

    private string codeAns = "53123"; 
    void Start()
    {
        //openDoor.SetActive(false);
        SetInputs(false);
        completionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SetInputs(true);
        zoomObject.zoomIn = !zoomObject.zoomIn;
        zoomObject.objectNum = 4;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public void CheckCode()
    {
        string codeEntered = codeInput.GetComponent<Text>().text;

        if(string.Equals(codeEntered, codeAns))
        {

            Debug.Log("Door opened");
            completionText.GetComponent<Text>().text = "Door unlocked!";
            completionText.SetActive(true);
            SetInputs(false);
            zoomObject.zoomIn = false;
            zoomObject.objectNum = 5;
            unlockedDoorCollider.SetActive(true);
        }
    }

    public void SetInputs(bool b)
    {
        codeInputField.SetActive(b);
        codeInput.SetActive(b);
        setCodeButton.SetActive(b);
    }
}
