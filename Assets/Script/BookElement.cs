using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BookElement : MonoBehaviour {
    public string color;    // Color of book.
    public string shape;    // Shape of book.
    public bool inRecord;   // Identify this book is recorded to database or not.
    public bool inArea;     // Identify this book is in area of desk or not.

    public BookSpawn spawnController; // Reference for removing gameObject from list books.

    /// <summary>
    /// Check if the collided book is either being the floor or ObjectOutOfArea.
    /// The book will be removed from the list of books and will be destroyed from hierarchy after five second.
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter(Collision col) { 
        if((col.gameObject.tag == "Floor" || col.gameObject.tag == "ObjectOutOfArea") && this.inArea == true && this.inRecord == false) {
            this.inArea = false;
            spawnController.books.Remove(this.gameObject);
            Destroy(gameObject, 5);
        } else if ((col.gameObject.tag == "Floor" || col.gameObject.tag == "ObjectOutOfArea") && this.inArea == true && this.inRecord == true) {
            this.inArea = false;
            Destroy(gameObject, 5);
        }
    }

}
