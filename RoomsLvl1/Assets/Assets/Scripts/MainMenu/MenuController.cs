using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject controlsHelp;
    bool controlsHelpState = false;
    // Start is called before the first frame update
    void Start()
    {
        controlsHelp.SetActive(controlsHelpState);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));
    }

    public void ExitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }

    public void ToggleControlsHelp()
    {
        controlsHelpState = !controlsHelpState;
        controlsHelp.SetActive(controlsHelpState);
    }
    


}
