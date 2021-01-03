using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clockInput : MonoBehaviour
{
    public string clockTime;
    private string ans1 = "3:00";
    private string ans2 = "3";
    public GameObject inputField;
    public GameObject inputObj;
    public GameObject activeText;
    public GameObject solvedClock;

    private float timeToShowText = 5f;
    private float timeToDisappear;

    private interactable interactable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeText.activeSelf == true && Time.time >= timeToDisappear)
            activeText.SetActive(false);
    }

    public void CheckTime()
    {
        clockTime = inputField.GetComponent<Text>().text;

        if(string.Equals(clockTime, ans1) || string.Equals(clockTime, ans2))
        {
            Debug.Log("inputfield: "+inputObj.name);
            ShowText();
            solvedClock.SetActive(true);
            interactable.knight.SetActive(true);
        }
    }

    void ShowText()
    {
        activeText.SetActive(true);
        activeText.GetComponent<Text>().text = "Something fell from the clock!";
        timeToDisappear = Time.time + timeToShowText;
    }

    private void Awake()
    {
        interactable = GameObject.FindObjectOfType<interactable>();

        inputObj.SetActive(false);
        inputField.SetActive(false);
        solvedClock.SetActive(false);
    }
}
