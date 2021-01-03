using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    Button button;
    
    inventoryObj inventoryObj;
    public static InteractableObj selectedObj; // Must be static b/c only one selectedObj across all instances of InvButton
   
    void Start()
    {
        inventoryObj = GameObject.FindObjectOfType<inventoryObj>();
        button = gameObject.GetComponent<Button>();

        selectedObj = null;
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void OnSelect(BaseEventData eventData)
    {
        selectedObj = inventoryObj.GetObjFromButton(button);
        Debug.Log(selectedObj.obj.name + " was selected");
        Debug.Log("Select name: " + GetSelectedName());
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selectedObj = null;
        Debug.Log("Deselected");
    }

    public string GetSelectedName()
    {
        if(selectedObj != null)
        {
            Debug.Log("SelectedName = " + selectedObj.obj.name);
            return selectedObj.obj.name;
        }

        return "";
        
    }

}
