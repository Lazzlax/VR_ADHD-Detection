using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawn : MonoBehaviour {

    public GamePlayController gamePlayControl; // Reference for total number of correct books. 

    [Header("Book Attribute")]
    public GameObject bookTemplate; // Book template which will be spawned.
    public Sprite[] shapesOfBook;   // List of shape sprites to implement when a book is spawned.
    public string[] colorsOfBook;   // List of color name to implement when a book is spawned.
    public List<GameObject> books;  // List for spawned book. 
    public bool loadFirstInstruction = false; // Define if first instruction finished playing.

    [Header("Maximum Book")]
    public int maxBookRespawn; // Define maximum book allowed every spawn. 

    /// <summary>
    /// Start method sets up 4 initial books.
    /// </summary>
    void Start() {
        books = new List<GameObject>();

        while (books.Count < maxBookRespawn && loadFirstInstruction == true) {
            RandomizeContentBook();
        }
    }

    /// <summary>
    /// The method will spawn books after the first instruction is finished playing and when the game has 0 to less than 4 books. 
    /// If the total number of correct books on both bins are equal or greater than 5, disable the grab of all books. 
    /// </summary>
    void Update() { 
        if ((books.Count >= 0 && books.Count < maxBookRespawn) && loadFirstInstruction == true){
            if (gamePlayControl.totalCorrectlyRight >= gamePlayControl.maxCorrectRight && gamePlayControl.totalCorrectlyLeft >= gamePlayControl.maxCorrectLeft) {
                gamePlayControl.DisableGrabbableObject();
            }
            else {
                RandomizeContentBook();
            }
        }
    }

    /// <summary>
    /// Method to spawn a book with randomized color and shape based on bookTemplate.
    /// Spawned books are randomly positioned based on the parent and added to the spawned books list. 
    /// </summary>
    protected void RandomizeContentBook() {
        int colorNumb = Random.Range(0, colorsOfBook.Length);
        int shapeNumb = Random.Range(0, shapesOfBook.Length);
        
        GameObject tempBook;
        tempBook = Instantiate(bookTemplate, bookTemplate.transform.parent);
        tempBook.SetActive(true);
        tempBook.name = "Book" + (bookTemplate.transform.parent.transform.childCount - 2);
        books.Add(tempBook);

        BookElement element = tempBook.GetComponent<BookElement>();

        Color r = Color.black;
        if (colorNumb == 0) {
            r = Color.red;
            element.color = "Merah";
        } else if (colorNumb == 1) {
            r = Color.green;
            element.color = "Hijau";
        } else if (colorNumb == 2) {
            r = Color.blue;
            element.color = "Biru";
        }

        int i = 0;
        while (i < shapesOfBook.Length) {
            if (i == shapeNumb) {
                element.shape = shapesOfBook[shapeNumb].name;
            }
            i++;
        }

        element.inRecord = false;
        element.inArea  = true;
        
        tempBook.transform.GetComponent<MeshRenderer>().materials[0].color      = r;
        tempBook.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite    = shapesOfBook[shapeNumb];
        float ex = tempBook.transform.position.x;
        float ez = tempBook.transform.position.z;
        tempBook.transform.position = new Vector3(ex + Random.Range(-0.09f, 0.07f), 
                                                    bookTemplate.transform.position.y, 
                                                    ez + Random.Range(-0.195f, 0.195f));
    }
}

