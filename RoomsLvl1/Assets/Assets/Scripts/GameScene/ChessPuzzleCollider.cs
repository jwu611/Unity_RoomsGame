using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzleCollider : MonoBehaviour
{
    inventoryObj invObj;
    ChessPuzzle chessPuzzle;
    interactable _interactable;
    // Start is called before the first frame update
    void Start()
    {
        invObj = GameObject.FindObjectOfType<inventoryObj>();
        chessPuzzle = GameObject.FindObjectOfType<ChessPuzzle>();
        _interactable = GameObject.FindObjectOfType<interactable>();
        string name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        switch (name)
        {
            case "Knight Puzzle Collider":
                invObj.AddtoInv(_interactable.knight_i);
                ChessPuzzle.knightSet = false;
                this.gameObject.SetActive(false);
                break;
            case "King Puzzle Collider":
                invObj.AddtoInv(_interactable.king_i);
                ChessPuzzle.kingSet = false;
                this.gameObject.SetActive(false);
                break;
            /*case "King Answer Collider":
                ChessPuzzle.kingSet = true;*/

        }
    }
}
