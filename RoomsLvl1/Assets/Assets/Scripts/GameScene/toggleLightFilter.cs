using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleLightFilter : MonoBehaviour
{
    GameObject lightsOff;
    GameObject nums;
    public static bool lights;

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
        lights = !lights;
        lightsOff.SetActive(!lights);
        nums.SetActive(!lights);

    }

    private void Awake()
    {
        lights = true;
        
        lightsOff = GameObject.Find("lightsoutfilter");
        nums = GameObject.Find("lightsOffNums");
        lightsOff.SetActive(false);
        nums.SetActive(false);
    }
}
