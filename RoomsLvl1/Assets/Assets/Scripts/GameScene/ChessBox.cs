using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBox : MonoBehaviour
{

    public Puzzle chessPuzzle;
    interactable _interactable;

    GameObject cBox; //Chess box object
    GameObject chessBoard;//Chess board obj
    public Sprite chessBoxClosed;
    public Sprite chessBoxOpen;

    // Start is called before the first frame update
    void Awake()
    {
        chessBoard = GameObject.Find("ChessBoard");
        //cBox = GameObject.Find("Chess Box");
        cBox = this.gameObject;
        _interactable = GameObject.FindObjectOfType<interactable>();
        chessPuzzle = new Puzzle(cBox, chessBoxClosed, chessBoxOpen, chessBoard, _interactable.codeNote_i);
        chessPuzzle.DeactivatePuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ActivatePuzzle();
    }

    void ActivatePuzzle()
    {
        chessBoard.SetActive(true);
        cBox.SetActive(false);
    }

    public void SetPuzzleSolved()
    {
        chessPuzzle.SetSolved();
        chessPuzzle.SetUpPuzzle();
        chessBoard.SetActive(false);
        this.GetComponent<Collider>().enabled = false;
    }
}
