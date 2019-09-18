using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawn : MonoBehaviour {

    public GamePlayController gamePlayControl;

    public GameObject bookTemplate;
    public Sprite[] shapesOfBook;
    public string[] colorsOfBook; 
    public List<GameObject> books;
    private int _numbIdBook;
    public bool loadFirstInstruction = false;

    void Start() {
        books = new List<GameObject>();

        while (books.Count < 4 && loadFirstInstruction == true) {
            RandomizeContentBook();
        }
    }

    void Update() { 
        if ((books.Count >= 0 && books.Count < 4) && loadFirstInstruction == true){
            if (gamePlayControl.totalCorrectlyRight >= 5 && gamePlayControl.totalCorrectlyLeft >= 5) {
                gamePlayControl.DisableGrabbableObject();
            }
            else {
                RandomizeContentBook();
            }
        }
    }

    protected void RandomizeContentBook() {
        int colorNumb = Random.Range(0, colorsOfBook.Length);
        int shapeNumb = Random.Range(0, shapesOfBook.Length);
        
        GameObject tempBook;
        tempBook = Instantiate(bookTemplate, bookTemplate.transform.parent);
        tempBook.SetActive(true);
        tempBook.name = "Book" + (bookTemplate.transform.parent.transform.childCount - 2);
        books.Add(tempBook);

        BookElement element = tempBook.GetComponent<BookElement>();

        element.idBook = _numbIdBook;

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

