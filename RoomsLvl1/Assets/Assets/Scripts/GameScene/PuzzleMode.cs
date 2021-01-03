using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleMode : MonoBehaviour
{
    public KingBox kingBox;
    public ChessBox chessBox;

    GameObject[] colliders;
    GameObject filter;
    Puzzle puzzle;

    GameObject[] puzzleObjs;

    // Start is called before the first frame update
    void Start() //Deactivate PuzzleObjs and filter at start
    {
        DeactivateAllPuzzleObjs();
        ToggleMode(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ToggleMode(true);
        SetPuzzle(true);
    }

    public void ToggleMode(bool b)
    {
        //Debug.Log(filter.name);
        filter.SetActive(b);
        SetColliders(!b);

    }

    public void SetColliders(bool b)
    {
        foreach (GameObject collider in colliders)
        {
            collider.GetComponent<BoxCollider>().enabled = b;
        }
    }

    public void SetPuzzle(bool b)
    {
        string name = gameObject.name;

        if (b == true)
        {
            switch (name)
            {
                case "KingBox Collider":
                    puzzle = kingBox.numBox;
                    break;

                case "ChessBox Collider":
                    puzzle = chessBox.chessPuzzle;
                    break;
            }
            puzzle.SetUpPuzzle();
            
        }
        else if (b == false)
        {
            //if(puzzle != null)
                DeactivateAllPuzzleObjs();

            
        }
    }

    public void DeactivateAllPuzzleObjs()
    {
        foreach (GameObject g in puzzleObjs)
        {
            g.SetActive(false);
        }
    }

    private void Awake()
    {
        filter = GameObject.Find("PuzzleMode Filter");
        //kingBox = GameObject.FindObjectOfType<KingBox>();
        //chessBox = GameObject.FindObjectOfType<ChessBox>();
        colliders = GameObject.FindGameObjectsWithTag("Colliders");
        puzzleObjs = GameObject.FindGameObjectsWithTag("Puzzle Objs");
    }

}
