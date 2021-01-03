using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    string objName;
    private inventoryObj inventoryObj;
    
    public GameObject knight;
    public InteractableObj knight_i;
    public Sprite knight_s;

    public GameObject king;
    public InteractableObj king_i;
    public Sprite king_s;

    public GameObject codeNote;
    public InteractableObj codeNote_i;
    public Sprite codeNote_s;

    private Dictionary<string, InteractableObj> interactablesList; //Key = obj.name of InteractableObj's associated gameObject


    // Start is called before the first frame update
    void Start()
    {
        knight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        objName = gameObject.name;
        inventoryObj.AddtoInv(interactablesList[objName]);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        //Set all interactables inactive
        inventoryObj = GameObject.FindObjectOfType<inventoryObj>();

        knight_i = new InteractableObj(knight, knight_s);
        king_i = new InteractableObj(king, king_s);
        codeNote_i = new InteractableObj(codeNote, codeNote_s);

        interactablesList = new Dictionary<string, InteractableObj>();
        interactablesList.Add(knight.name, knight_i);
        interactablesList.Add(king.name, king_i);
        interactablesList.Add(codeNote.name, codeNote_i);


    }
}
public class InteractableObj
{
    public GameObject obj;
    public Sprite sprite;
    public int slotNum;

    public InteractableObj(GameObject name, Sprite s)
    {
        obj = name;
        sprite = s;

    }
}

public class Puzzle : InteractableObj
{
    Sprite solvedSprite;
    InteractableObj unlockedItem; //Item unlocked after solved puzzle
    InteractableObj solutionItem;
    public GameObject puzzleObj; //Ex. chess board or num lock
    bool solvedState = false;
    inventoryObj inventoryObj = GameObject.FindObjectOfType<inventoryObj>();

    //GameObject[] puzzleObjs = GameObject.FindGameObjectsWithTag("Puzzle Objs");

    public Puzzle(GameObject name, Sprite sprite, Sprite solved_s, GameObject puzzleBoard, InteractableObj unlocked) : base(name, sprite) 
    {
        solvedSprite = solved_s;
        unlockedItem = unlocked;
        unlockedItem.obj.SetActive(false);
        puzzleObj = puzzleBoard;
    }

    public void SetUpPuzzle()
    {
        obj.SetActive(true);

        if(solvedState == false)
        {
            obj.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else if(solvedState == true)
        {
            obj.GetComponent<SpriteRenderer>().sprite = solvedSprite;
            if (inventoryObj.CheckForValue(unlockedItem)==false)
            {
                unlockedItem.obj.SetActive(true);
            }
            else
            {
                unlockedItem.obj.SetActive(false);
            }
            Debug.Log(unlockedItem.obj.name+" found in inv: " + inventoryObj.CheckForValue(unlockedItem));
        }
        
    }

    public void DeactivatePuzzle()
    {
        this.puzzleObj.SetActive(false);
    }

    /*public void DeactivateAllPuzzles()
    {
        foreach(GameObject g in puzzleObjs)
        {
            g.SetActive(false);
        }
    }*/

    public bool GetSolvedState()
    {
        return solvedState;
    }
    
    public void SetSolved()
    {
        obj.GetComponent<SpriteRenderer>().sprite = solvedSprite;
        unlockedItem.obj.SetActive(true);
        solvedState = true;
    }

}

