using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public void GoToScene(int index) {
        SceneManager.LoadScene(index);
    }

    public void CloseUIMenu(GameObject menuUI) {
        menuUI.SetActive(false);
    }
    
}
