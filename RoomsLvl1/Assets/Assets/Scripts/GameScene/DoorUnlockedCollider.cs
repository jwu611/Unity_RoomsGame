using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlockedCollider : MonoBehaviour
{
    public blurBackground blur;
    public GameObject completionText;
    void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        completionText.SetActive(false);
        blur.SetBlur();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
