using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour {
    public DataControl dataControl;
    public Instruction voiceInstruction;
    public GameObject UIEndGame;
    public GameObject playerView;

    public float totalTime; 
    public float totalTimeHoldBook;
    public float totalTimeLookDesk;
    public float totalTimeLookNonDesk;
    public int totalCorrectlyRight;
    public int totalCorrectlyLeft;
    public int totalCorrectlyFront;
    public int totalIncorrectBook;
    public int totalInstructionRepeat;
    private bool completeAct = false;
    private float delayTime = 5;
 
    void Update() {
        totalTime += Time.deltaTime;

        if (totalCorrectlyRight >= 5 && totalCorrectlyLeft >= 5 && completeAct == false) {
            if (delayTime <= 0) {
                dataControl.AddDataToDB(totalTime, totalCorrectlyRight, totalCorrectlyLeft, totalCorrectlyFront, totalIncorrectBook, totalTimeHoldBook, totalTimeLookDesk, totalTimeLookNonDesk, totalInstructionRepeat);
                UIEndGame.SetActive(true);
                playerView.SetActive(false);
                voiceInstruction.PlayEnd();
                DisableGrabbableObject();
                completeAct = true;
                Debug.Log("Yossshhhh....");
            } else {
                delayTime -= Time.deltaTime;
            }
        }
    }

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
