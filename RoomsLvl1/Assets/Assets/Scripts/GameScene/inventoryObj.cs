using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class inventoryObj : MonoBehaviour
{
    private Dictionary<int, InteractableObj> inventory; //Key = slotNum assigned by FillNextSlot

    private int invSpaces;

    public Button slot0;
    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;

    List<Button> slotList = new List<Button>();

    public void AddtoInv(InteractableObj obj) 
    {
        if(inventory.Count < invSpaces && !inventory.ContainsValue(obj))
        {
           FillNextSlot(obj);
           int key = obj.slotNum; 
           inventory.Add(key, obj);
           
        }
        
    }

    public void FillNextSlot(InteractableObj obj)
    {
        foreach(Button b in slotList)
        {
            if(b.gameObject.activeSelf == false)
            {
                b.gameObject.SetActive(true);
                b.image.sprite = obj.sprite;
                obj.slotNum = slotList.IndexOf(b);
                break;
            }
                
        }
    }

    public bool CheckForValue(InteractableObj o)
    {
        Debug.Log("Looking for "+o.obj.name);
        return inventory.ContainsValue(o);
    }

    public InteractableObj GetObjFromButton(Button b)
    {
        int num = slotList.IndexOf(b);
        return inventory[num];
    }

    public void UseItem(InteractableObj i) //
    {
        //InvSlot slot;
        Button slot;
        int num = i.slotNum;
        inventory.Remove(num);
        slot = slotList[num];
        slot.gameObject.SetActive(false);
        
    }

    
    private void Awake()
    {
        inventory = new Dictionary<int, InteractableObj>();
        invSpaces = 5;

        slotList.Add(slot0);
        slotList.Add(slot1);
        slotList.Add(slot2);
        slotList.Add(slot3);
        slotList.Add(slot4);

        foreach(Button b in slotList)
        {
            b.gameObject.SetActive(false);
        }
    }
}

