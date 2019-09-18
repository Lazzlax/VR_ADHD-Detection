using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour {
    public GamePlayController gameControl;
    public bool lookDesk;

    void Start() {
        lookDesk = true;
    }

    void Update() {
        if (lookDesk) {
            gameControl.totalTimeLookDesk += Time.deltaTime;
        } else if(lookDesk == false) {
            gameControl.totalTimeLookNonDesk += Time.deltaTime;
        }
    }
    
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Desk" || other.gameObject.tag == "Trash" || other.gameObject.tag == "Book" ||
                other.gameObject.tag == "TrashDataCheckFront" || other.gameObject.tag == "TrashDataCheckRight" || 
                    other.gameObject.tag == "TrashDataCheckLeft") {
            lookDesk = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Desk" || other.gameObject.tag == "Trash" || other.gameObject.tag == "Book" ||
                other.gameObject.tag == "TrashDataCheckFront" || other.gameObject.tag == "TrashDataCheckRight" ||
                    other.gameObject.tag == "TrashDataCheckLeft") {
            lookDesk = false;
        }
    }
}
