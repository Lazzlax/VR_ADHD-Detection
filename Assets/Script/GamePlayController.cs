using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour {
    public DataControl dataControl;         // Reference for using method from DataControl.
    public Instruction voiceInstruction;    // Reference for playing the last audio of game ending.
    public GameObject UIEndGame;            // UI Menu shown when game is over.
    public GameObject playerView;           // Player view GameObject on camera which will be turned off.

    [Header("Maximum Correct Book")]
    public int maxCorrectRight; // maximum correct book right bin.
    public int maxCorrectLeft;  // maximum correct book left bin.

    [Header("Data")]
    public float totalTime;             // Variabel to collect total time when user is playing this stage. 
    public float totalTimeHoldBook;     // Variabel to collect total time when user is holding each book. 
    public float totalTimeLookDesk;     // Variabel to collect total time when user is looking at desk.
    public float totalTimeLookNonDesk;  // Variabel to collect total time when user is looking not at desk. 
    public int totalCorrectlyRight;     // Variabel to collect total correct books in the right bin on this stage. 
    public int totalCorrectlyLeft;      // Variabel to collect total correct books in the left bin on this stage. 
    public int totalCorrectlyFront;     // Variabel to collect total correct books in the front bin on this stage. 
    public int totalIncorrectBook;      // Variabel to collect total incorrect books in each bin on this stage. 
    public int totalInstructionRepeat;  // Variabel to collect total instruction repeats on this stage. 
    private bool completeAct = false;   // Marker action when game over
    private float delayTime = 5;        // Delay UI pop out when game over

    /// <summary>
    /// Total time when playing this game will be increased until the condition is fulfilled.
    /// If the correct book on right and left bin are equal or more than 5, the game is over after 5 seconds. 
    /// </summary>
    void Update() {
        totalTime += Time.deltaTime;

        if (totalCorrectlyRight >= maxCorrectRight && totalCorrectlyLeft >= maxCorrectLeft && completeAct == false) {
            if (delayTime <= 0) {
                dataControl.AddDataToDB(totalTime, totalCorrectlyRight, totalCorrectlyLeft, totalCorrectlyFront, totalIncorrectBook, totalTimeHoldBook, totalTimeLookDesk, totalTimeLookNonDesk, totalInstructionRepeat);
                UIEndGame.SetActive(true);
                playerView.SetActive(false);
                voiceInstruction.PlayEnd();
                DisableGrabbableObject();
                completeAct = true;
            } else {
                delayTime -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// This method is used to disable grabbing function in every book. 
    /// </summary>
    public void DisableGrabbableObject() {
        var foundObjects = FindObjectsOfType<VRTK.VRTK_InteractableObject>();
        int i = 0;
        while (i < foundObjects.Length) {
            foundObjects[i].isGrabbable = false;
            foundObjects[i].enabled = false;
            i++;
        }
    }

}
