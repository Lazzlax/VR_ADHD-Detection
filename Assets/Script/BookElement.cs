using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BookElement : MonoBehaviour {
    public int idBook;
    public string color;
    public string shape;
    public bool inRecord;
    public bool inArea;
    
    public BookSpawn spawnController;

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
