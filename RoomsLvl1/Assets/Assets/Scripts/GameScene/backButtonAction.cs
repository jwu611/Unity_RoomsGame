using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButtonAction : MonoBehaviour
{
    public PuzzleMode puzzleMode;
    public ExamineButton examineButton;
    public DoorLock doorLock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetZoom()
    {
       
        puzzleMode.ToggleMode(false);
        puzzleMode.SetPuzzle(false);
        examineButton.ToggleExamineView(false);
        doorLock.SetInputs(false);
        doorLock.GetComponent<Collider>().enabled = true;
        
        zoomObject.zoomIn = false;
        zoomObject.objectNum = 5;
    }

    private void Awake()
    {
        //puzzleMode = GameObject.FindObjectOfType<PuzzleMode>();
    }
}
