using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instruction : MonoBehaviour {

    public BookSpawn bookSpawner;   // Reference for list of shapes and colors from BookSpawn. 
    public GamePlayController gameControl;  // Reference for totalInstructionRepeat from GamePlayController.
    public GameObject menuInstruction;      // Reference for Instruction Menu.
    public GameObject playerViewObj;        // Reference for object in player's camera.
    public Book targetBookRight;    // Target book from Right bin.
    public Book targetBookLeft;     // Target book from Left bin.

    private List<string> _colorsOfBook; // List of book color names.
    private List<Sprite> _shapesOfBook; // List of book shape sprites.

    public AudioSource audioSource;     // A representation of audio sources in 3D. 
    public List<AudioClip> InstructionVoices;   // List of AudioClips for instruction voice.
    public List<AudioClip> VoicesOfColor;       // List of AudioClips for color voice.
    public List<AudioClip> VoicesOfShape;       // List of AudioClips for shape voice.
    public List<AudioClip> VoicesOfTargetLocation;  // List of AudioClips for target location voice.
    public AudioClip voiceOfEnd;        // AudioClips for game end voice.
    public bool completeAudio = false;  // Condition to check if the audio is complete.

    /// <summary>
    /// Fill the target location and book attributes in target bins.
    /// Playing the full intruction audio.
    /// </summary>
    public void Start() {
        _colorsOfBook = bookSpawner.colorsOfBook.ToList();
        _shapesOfBook = bookSpawner.shapesOfBook.ToList();

        targetBookRight = GenerateTarget(_colorsOfBook, _shapesOfBook, "Right");
        targetBookLeft  = GenerateTarget(_colorsOfBook, _shapesOfBook, "Left");
        Validate();

        PrepareInstructionVoices();
        PlayInstructionSequence();
        gameControl.totalInstructionRepeat = 0;
    }

    /// <summary>
    /// Generate randomized book and target location.
    /// </summary>
    /// <param name="colors">List of colors that is used to determined the randomized target book.</param>
    /// <param name="shapes">List of shapes that is used to determined the randomized target book.</param>
    /// <param name="targetLocation">The String that is filled with target location.</param>
    /// <returns></returns>
    public Book GenerateTarget(List<string> colors, List<Sprite> shapes, string targetLocation) {
        int rcolor = Random.Range(0, colors.Count);
        int rshape = Random.Range(0, shapes.Count);
        Book targetBook = new Book(colors[rcolor], shapes[rshape], targetLocation);

        return targetBook;
    }

    /// <summary>
    /// Method to validate atribute similarity at different locations. 
    /// </summary>
    public void Validate() {
        while (targetBookLeft.Color == targetBookRight.Color && targetBookLeft.Shape == targetBookRight.Shape) {
            int r = Random.Range(0, 2);
            if (r == 0) {
                targetBookLeft = GenerateTarget(_colorsOfBook, _shapesOfBook, "Left");
            }
            else {
                targetBookRight = GenerateTarget(_colorsOfBook, _shapesOfBook, "Right");
            }
        }
    }
    
    /// <summary>
    /// Fill the audio based on the target book into the instruction sequences.
    /// </summary>
    public void PrepareInstructionVoices() {
        InstructionVoices[1] = GetClipFromColor(targetBookRight);
        InstructionVoices[3] = GetClipFromShape(targetBookRight);
        InstructionVoices[5] = GetClipFromColor(targetBookLeft);
        InstructionVoices[7] = GetClipFromShape(targetBookLeft);
    }

    /// <summary>
    /// This method will be called to play audio instruction sequences.
    /// </summary>
    public void PlayInstructionSequence() {
        StartCoroutine(PlayAudiosSequentially());
    }

    /// <summary>
    /// This method will play audio in sequence automatically because the audio is divided. 
    /// and will activate the instruction menu in hierarchy after the audio sequences is complete. 
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAudiosSequentially() {
        completeAudio = false;
        for (int i = 0; i < InstructionVoices.Count; i++) {
            audioSource.clip = InstructionVoices[i];
            audioSource.Play();
            while (audioSource.isPlaying) {
                yield return null;
            }
        }

        if (bookSpawner.loadFirstInstruction == false) {
            menuInstruction.SetActive(true);
        }

        completeAudio = true;
    }

    /// <summary>
    /// Method to get associated audio from the target book's color. 
    /// </summary>
    /// <param name="targetBook">The variable to check color from target book</param>
    /// <returns></returns>
    public AudioClip GetClipFromColor(Book targetBook) {
        return VoicesOfColor.Where(x => x.name == targetBook.Color).FirstOrDefault();
    }

    /// <summary>
    /// Method to get associated audio from the target book's shape. 
    /// </summary>
    /// <param name="targetBook">The variable to check shape from target book</param>
    /// <returns></returns>
    public AudioClip GetClipFromShape(Book targetBook) {
        return VoicesOfShape.Where(x => x.name == targetBook.Shape.name).FirstOrDefault();
    }

    /// <summary>
    /// Method to get associated audio from the target book's location.
    /// </summary>
    /// <param name="targetBook">The variable to check location from target book</param>
    /// <returns></returns>
    public AudioClip GetClipFromLocation(Book targetBook) {
        return VoicesOfTargetLocation.Where(x => x.name == targetBook.TargetLocation).FirstOrDefault();
    }

    /// <summary>
    /// Method to repeat the instruction and inactivate the menu instruction.
    /// </summary>
    public void RepeatInstruction() {
        menuInstruction.SetActive(false);
        PlayInstructionSequence();
        gameControl.totalInstructionRepeat++;
    }

    /// <summary>
    /// Method to start playing the game and inactivate the instruction menu.  
    /// </summary>
    public void PlaySortingGame() {
        menuInstruction.SetActive(false);
        playerViewObj.SetActive(true);
        bookSpawner.loadFirstInstruction = true;
    }

    /// <summary>
    /// Method to play game end audio instruction of game over and activate the game over menu. 
    /// </summary>
    public void PlayEnd() {
        audioSource.Stop();
        audioSource.clip = voiceOfEnd;
        audioSource.Play();
    }
    
}

/// <summary>
/// Structure class of book. 
/// </summary>
public class Book {
    public string Color;
    public Sprite Shape;
    public string TargetLocation; 

    public Book(string color, Sprite shape) {
        this.Color = color;
        this.Shape = shape;
    }

    public Book(string color, Sprite shape, string targetLocation) {
        this.Color = color;
        this.Shape = shape;
        this.TargetLocation = targetLocation;
    }
} 