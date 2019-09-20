using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinFrontControl : MonoBehaviour {
    private Book _TargetBookRight; // Target book for right bin
    private Book _TargetBookLeft;  // Target book for left bin

    public BookSpawn spawnControl;  // Reference for script BookSpawn 
    public Instruction instructorr; // Reference for script Instruction
    public GamePlayController dataCtrl; // Reference for script GamePlayController

    /// <summary>
    /// Check if the collided book is either being the target on right bin and left bin, or not. 
    /// Increase the dataCtrl.totalCorrectBook if the book is not a target from both bins, 
    /// either way increase the dataCtrl.totalIncorrectBook. 
    /// </summary>
    /// <param name="col"> The Collider that is being check </param>
    private void OnTriggerEnter(Collider col) {
        
        if (col.gameObject.tag == "Book") {

            _TargetBookRight    = instructorr.targetBookRight;
            _TargetBookLeft     = instructorr.targetBookLeft;

            bool used   = col.gameObject.GetComponent<BookElement>().inRecord;
            string color = col.gameObject.GetComponent<BookElement>().color;
            string shape = col.gameObject.GetComponent<BookElement>().shape;

            //spawnControl.books.Count > 0 &&
            if (used == false) {

                if ((color == _TargetBookRight.Color && shape == _TargetBookRight.Shape.name) ||
                        (color == _TargetBookLeft.Color && shape == _TargetBookLeft.Shape.name)) {
                    dataCtrl.totalIncorrectBook++;
                } else {
                    dataCtrl.totalCorrectlyFront++;
                }
                used = true;
                col.gameObject.GetComponent<BookElement>().inRecord = used;
                col.gameObject.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
                col.gameObject.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
                spawnControl.books.Remove(col.gameObject);
            }
        }
    }

}
