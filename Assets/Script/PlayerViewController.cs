using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class for Player View Checking
/// </summary>
public class PlayerViewController : MonoBehaviour {
    public GamePlayController gameControl; // Reference for total time look at desk and not look at desk.
    public bool lookDesk; // Marker condition of player view direction.

    /// <summary>
    /// First, set up the variable lookDesk into true to assume that player looking at desk. 
    /// </summary>
    void Start() {
        lookDesk = true;
    }

    /// <summary>
    /// Increase the total time look at desk and not look at desk based on player's view direction. 
    /// </summary>
    void Update() {
        if (lookDesk) {
            gameControl.totalTimeLookDesk += Time.deltaTime;
        } else if(lookDesk == false) {
            gameControl.totalTimeLookNonDesk += Time.deltaTime;
        }
    }

    /// <summary>
    /// If this object's collider stay collide with certain colliders, 
    /// it can be assumed that the player is looking at Desk.
    /// </summary>
    /// <param name="other"> The Collider that is being check </param>
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Desk" || other.gameObject.tag == "Bin" || other.gameObject.tag == "Book" ||
                other.gameObject.tag == "BinDataCheckFront" || other.gameObject.tag == "BinDataCheckRight" || 
                    other.gameObject.tag == "BinDataCheckLeft") {
            lookDesk = true;
        }
    }

    /// <summary>
    /// If this object's collider exit collision with certain colliders, 
    /// it can be assumed that the player is not looking at Desk.
    /// </summary>
    /// <param name="other"> The Collider that is being check </param>
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Desk" || other.gameObject.tag == "Bin" || other.gameObject.tag == "Book" ||
                other.gameObject.tag == "BinDataCheckFront" || other.gameObject.tag == "BinDataCheckRight" ||
                    other.gameObject.tag == "BinDataCheckLeft") {
            lookDesk = false;
        }
    }
}
