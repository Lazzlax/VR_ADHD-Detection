using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDataControl : MonoBehaviour {
    public Book TargetBook;
    public string locationTrash;
    
    public Instruction instructor;
    public BookElement elmtBook;
    public BookSpawn spawnControl;
    public GamePlayController dataControl;

    private void OnTriggerEnter(Collider col) {

        string tagObj = col.gameObject.tag;

        if (tagObj == "Book") {

            TargetBook = locationTrash == "Right" ? instructor.targetBookRight : instructor.targetBookLeft;

            bool used = col.gameObject.GetComponent<BookElement>().inRecord;
            string color = col.gameObject.GetComponent<BookElement>().color;
            string shape = col.gameObject.GetComponent<BookElement>().shape;
            
            if (spawnControl.books.Count > 0 && used == false) {
                if (color == TargetBook.Color && shape == TargetBook.Shape.name) {
                    if (locationTrash == "Right") {
                        dataControl.totalCorrectlyRight++;
                    } else if (locationTrash == "Left") {
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