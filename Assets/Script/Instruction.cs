using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instruction : MonoBehaviour {

    public BookSpawn bookSpawner;
    public GamePlayController gameControl;
    public GameObject menuInstruction;
    public GameObject playerViewObj;
    public Book targetBookRight;
    public Book targetBookLeft;

    private List<string> _colorsOfBook;
    private List<Sprite> _shapesOfBook;

    public AudioSource audioSource;
    public List<AudioClip> InstructionVoices;
    public List<AudioClip> VoicesOfColor;
    public List<AudioClip> VoicesOfShape;
    public List<AudioClip> VoicesOfTargetLocation;
    public AudioClip voiceOfEnd;
    public bool completeAudio = false;

    public void Start() {
        _colorsOfBook = bookSpawner.colorsOfBook.ToList();
        _shapesOfBook = bookSpawner.shapesOfBook.ToList();

        targetBookRight = GenerateTarget(_colorsOfBook, _shapesOfBook, "Right");
        targetBookLeft = GenerateTarget(_colorsOfBook, _shapesOfBook, "Left");
        Validate();

        PrepareInstructionVoices();
        PlayInstructionSequence();
        gameControl.totalInstructionRepeat = 0;
    }

    public Book GenerateTarget(List<string> colors, List<Sprite> shapes, string targetLocation) {
        int rcolor = Random.Range(0, colors.Count);
        int rshape = Random.Range(0, shapes.Count);
        Book targetBook = new Book(colors[rcolor], shapes[rshape], targetLocation);

        return targetBook;
    }

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

    public void PrepareInstructionVoices() {
        InstructionVoices[1] = GetClipFromColor(targetBookRight);
        InstructionVoices[3] = GetClipFromShape(targetBookRight);
        InstructionVoices[5] = GetClipFromColor(targetBookLeft);
        InstructionVoices[7] = GetClipFromShape(targetBookLeft);
    }

    public void PlayInstructionSequence() {
        StartCoroutine(PlayAudiosSequentially());
    }
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

    public AudioClip GetClipFromColor(Book targetBook) {
        return VoicesOfColor.Where(x => x.name == targetBook.Color).FirstOrDefault();
    }
    public AudioClip GetClipFromShape(Book targetBook) {
        return VoicesOfShape.Where(x => x.name == targetBook.Shape.name).FirstOrDefault();
    }
    public AudioClip GetClipFromLocation(Book targetBook) {
        return VoicesOfTargetLocation.Where(x => x.name == targetBook.TargetLocation).FirstOrDefault();
    }

    public void RepeatInstruction() {
        menuInstruction.SetActive(false);
        PlayInstructionSequence();
        gameControl.totalInstructionRepeat++;
    }

    public void PlaySortingGame() {
        menuInstruction.SetActive(false);
        playerViewObj.SetActive(true);
        bookSpawner.loadFirstInstruction = true;
    }

    public void PlayEnd() {
        audioSource.Stop();
        audioSource.clip = voiceOfEnd;
        audioSource.Play();
    }
    
}

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