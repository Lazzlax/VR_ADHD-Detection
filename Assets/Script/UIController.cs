using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class used to control any event in UI.
/// </summary>
public class UIController : MonoBehaviour {

    /// <summary>
    /// This method used to move to other scene.
    /// </summary>
    /// <param name="index">Used to identify number of scene index in build setting</param>
    public void GoToScene(int index) {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// This method used to close any canvas UI.
    /// </summary>
    /// <param name="menuUI">To identify which the GameObject that is being Off in hierarchy</param>
    public void CloseUIMenu(GameObject menuUI) {
        menuUI.SetActive(false);
    }
    
}
