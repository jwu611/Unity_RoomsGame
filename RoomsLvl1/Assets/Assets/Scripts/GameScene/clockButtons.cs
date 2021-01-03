using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class clockButtons : MonoBehaviour
{
    public static GameObject cButton1;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //cButton1.SetActive(enable);
        //cButton2.SetActive(enable);
    }

    public void Awake()
    {
        cButton1 = GameObject.Find("Set Time");
        cButton1.SetActive(false);
        
    }
}
