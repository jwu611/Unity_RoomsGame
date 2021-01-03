using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingBox : MonoBehaviour
{
    interactable _interactable;

    public Puzzle numBox;
    public Sprite boxClosed;
    public Sprite boxOpened;
    GameObject box; //King Box Object
    GameObject numLock; //Number Lock

    //Following are numLock inputs  (only on with Number lock is on)
    public GameObject setLock; //Set Lock button
    public GameObject input; //Text from input field
    public GameObject inputObj; //Input field obj

    private string lockCombination = "2791";
    private string guess;
    // Start is called before the first frame update


    private void Awake()
    {
        
        _interactable = GameObject.FindObjectOfType<interactable>();

        box = GameObject.Find("King Box");
        numLock = GameObject.Find("numberBoxLock");
        
        numBox = new Puzzle(box, boxClosed, boxOpened, numLock, _interactable.king_i);

        if (box == null)
            Debug.Log("Error KingBox not found");
        if (numLock == null)
            Debug.Log("Error numLock not found");
 
        //ResetPuzzle();
        numBox.DeactivatePuzzle();

       
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown() //once numBox box collider is clicked, start puzzle
    {
        ActivatePuzzle();
    }

    /*void ResetPuzzle() //All puzzle components inactive
    {
        box.SetActive(false);
        numLock.SetActive(false);
        setLock.SetActive(false);
        input.SetActive(false);
        inputObj.SetActive(false);
    }*/

    void ActivatePuzzle() //NumLock Puzzle Activated
    {
        numLock.SetActive(true);
        box.SetActive(false);
        setLock.SetActive(true);
        input.SetActive(true);
        inputObj.SetActive(true);
    }

    void DeactivatePuzzle() //Numlock puzzle inactive, kingbox activated
    {
        box.SetActive(true);
        numLock.SetActive(false);
        setLock.SetActive(false);
        input.SetActive(false);
        inputObj.SetActive(false);
    }

    public void CheckPuzzle() //set as setLock button's onclick function 
    {
        guess = input.GetComponent<Text>().text;
        if (string.Equals(guess, lockCombination))
        {
            DeactivatePuzzle();
            numBox.obj.SetActive(true);
            numBox.SetSolved();
        }
    }

}
