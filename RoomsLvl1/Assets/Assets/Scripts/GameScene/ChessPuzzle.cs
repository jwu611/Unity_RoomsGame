using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzle : MonoBehaviour
{

    Vector3 newPos;
    //public Transform newTransform;
    //Collider collider;


    InvButton invButton;
    inventoryObj _inventoryObj;
    ChessBox chessBox;

    GameObject kingCollider;
    GameObject knightCollider;
    GameObject activeCollider;
    public static bool kingSet, knightSet = false; //Keeping track of whether pieces have been placed so correct pieces are activated if board is left and reentered

    GameObject kingAnswer;
    GameObject knightAnswer;
    

    // Start is called before the first frame update
    void Awake()
    {
        //collider = GetComponent<Collider>();
        invButton = GameObject.FindObjectOfType<InvButton>();
        if (invButton == null)
            Debug.Log("Error: InvButton not found");
        _inventoryObj = GameObject.FindObjectOfType<inventoryObj>();
        chessBox = GameObject.FindObjectOfType<ChessBox>();
        
        kingCollider = gameObject.transform.Find("King Puzzle Collider").gameObject;
        knightCollider = gameObject.transform.Find("Knight Puzzle Collider").gameObject;
        kingAnswer = gameObject.transform.Find("King Answer").gameObject;
        knightAnswer = gameObject.transform.Find("Knight Answer").gameObject;


        if (kingCollider == null || knightCollider == null)
            Debug.Log("Error: ChessBoard Colliders not found");
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetMouseButtonDown(0))
        {
            if (CheckSelected(invButton.GetSelected()))
            {
                newPos = Input.mousePosition;
                if (collider.bounds.Contains(newPos))
                {
                    TryPuzzle();
                }            
            }
            
               
        }*/
    }

    private void OnEnable()
    {
        if (kingSet)
            kingCollider.SetActive(true);
        if (knightSet)
            knightCollider.SetActive(true);
    }

    private void OnMouseDown()
    {
        //Debug.Log("ChessPuzzle SelectedName = " + invButton.GetSelectedName());
        string objName = invButton.GetSelectedName();

        if (CheckSelected(objName))
        {
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            MoveActivePiece();
            Debug.Log("Chess board solved = "+ CheckIfSolved());
            if (CheckIfSolved())
            {
                chessBox.SetPuzzleSolved();
                Debug.Log("Puzzle Solved");
            }
            
        }
    }

    public bool CheckSelected(string name) //Check if name is a valid obj to use in puzzle & assign appropriate collider if so
    {
        if(string.Equals(name, "kingpiece"))
        {
            activeCollider = kingCollider;
            kingSet = true;
            return true;
        }
        else if(string.Equals(name, "knightpiece"))
        {
            activeCollider = knightCollider;
            knightSet = true;
            return true;
        }

        return false;
    }
    public void MoveActivePiece() //Put in ChessCollider class
    {
        activeCollider.SetActive(true);
        activeCollider.transform.position = newPos;
        _inventoryObj.UseItem(InvButton.selectedObj);
        Debug.Log("ActiveCollider: "+activeCollider.name+" move to "+newPos);
    }

    bool CheckIfSolved()
    {
        if(kingSet && knightSet)
        {
            kingAnswer.SetActive(true);
            knightAnswer.SetActive(true);
            if (kingAnswer.GetComponent<Collider>().bounds.Contains(kingCollider.transform.position) && knightAnswer.GetComponent<Collider>().bounds.Contains(knightCollider.transform.position))
                return true;
        }
        return false;
       
    }



   

}
