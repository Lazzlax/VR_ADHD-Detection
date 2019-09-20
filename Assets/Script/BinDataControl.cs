using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinDataControl : MonoBehaviour {
    public Book TargetBook;         // Target book for this Bin. 
    public string locationBin;    // Bin location.

    public Instruction instructor;  // Reference for target book from right and left bin. 
    public BookSpawn spawnControl;  // Reference for BookSpawn.
    public GamePlayController dataControl;  // Reference for GamePlayController.  

    /// <summary>
    /// Check if the collided book is either being the target on right bin and left bin. 
    /// Increase the dataCtrl.totalCorrectlyRight if the book is a target from right bin, 
    /// Increase the dataCtrl.totalCorrectlyLeft if the book is a target from left bin, 
    /// either way increase the dataCtrl.totalIncorrectBook. 
    /// </summary>
    /// <param name="col"> This parameter is an object collided with the Bin</param>
    private void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "Book") {

            TargetBook = locationBin == "Right" ? instructor.targetBookRight : instructor.targetBookLeft;

            bool used = col.gameObject.GetComponent<BookElement>().inRecord;
            string color = col.gameObject.GetComponent<BookElement>().color;
            string shape = col.gameObject.GetComponent<BookElement>().shape;

            //spawnControl.books.Count > 0 && 
            if (used == false) {
                if (color == TargetBook.Color && shape == TargetBook.Shape.name) {
                    if (locationBin == "Right") {
                        dataControl.totalCorrectlyRight++;
                    } else if (locationBin == "Left") {
                        dataControl.totalCorrectlyLeft++;
                    }
                }
                else if (color != TargetBook.Color || shape != TargetBook.Shape.name) {
                    dataControl.totalIncorrectBook++;
                }

                used = true;
                col.gameObject.GetComponent<BookElement>().inRecord = used;
                col.gameObject.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
                col.gameObject.GetComponent<VRTK.VRTK_InteractableObject>().enabled     = false;
                spawnControl.books.Remove(col.gameObject);
            }
        }
    }
}