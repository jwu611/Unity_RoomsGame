using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineButton : MonoBehaviour
{
    public PuzzleMode puzzleMode;
    GameObject examineView;

    // Start is called before the first frame update
    void Start()
    {
        //puzzleMode = GameObject.FindObjectOfType<PuzzleMode>();
        examineView = GameObject.Find("Object Examine View");
        if (examineView != null)
            Debug.Log("ExamineView: "+examineView.name);
       examineView.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && InvButton.selectedObj != null)
        {
            puzzleMode.ToggleMode(true);
            ToggleExamineView(true);
            examineView.GetComponent<SpriteRenderer>().sprite = InvButton.selectedObj.sprite;
        }
    }

    public void ToggleExamineView(bool b)
    {
        examineView.SetActive(b);
    }
}
