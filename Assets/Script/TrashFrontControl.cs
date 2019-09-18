using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFrontControl : MonoBehaviour {
    private Book _TargetBookRightt;
    private Book _TargetBookLeftt;

    public BookSpawn spawnControl;
    public Instruction instructorr;
    public GamePlayController dataCtrl;

    private void OnTriggerEnter(Collider col) {

        string tagObj = col.gameObject.tag;

        if (tagObj == "Book") {

            _TargetBookRightt = instructorr.targetBookRight;
            _TargetBookLeftt = instructorr.targetBookLeft;

            bool used = col.gameObject.GetComponent<BookElement>().inRecord;
            string color = col.gameObject.GetComponent<BookElement>().color;
            string shape = col.gameObject.GetComponent<BookElement>().shape;

            if (spawnControl.books.Count > 0 && used == false) {

                if ((color == _TargetBookRightt.Color && shape == _TargetBookRightt.Shape.name) ||
                        (color == _TargetBookLeftt.Color && shape == _TargetBookLeftt.Shape.name)) {
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
