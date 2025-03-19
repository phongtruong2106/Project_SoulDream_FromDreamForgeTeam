using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : NewMonoBehaviour
{
    [SerializeField] private List<string> pressedPianoNames = new List<string>();
    [SerializeField] private List<string> defaultPianoNames = new List<string>();
    private bool isPressed = false;
    public bool IsPressed => isPressed;

    protected override void Start()
    {
        base.Start();
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("F");
        defaultPianoNames.Add("G");
        defaultPianoNames.Add("G");
        defaultPianoNames.Add("F");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("D");
        defaultPianoNames.Add("C");
        defaultPianoNames.Add("C");
        defaultPianoNames.Add("D");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("D");
        defaultPianoNames.Add("D");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("F");
        defaultPianoNames.Add("G");
        defaultPianoNames.Add("G");
        defaultPianoNames.Add("F");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("D");
        defaultPianoNames.Add("C");
        defaultPianoNames.Add("C");
        defaultPianoNames.Add("D");
        defaultPianoNames.Add("E");
        defaultPianoNames.Add("D");
        defaultPianoNames.Add("C");
    }
    private void Update()
    {
        this.CheckPianoNamesMatch();
    }
    public void AddpressedPianoName(string name)
    {
        pressedPianoNames.Add(name);
    }

     private void CheckPianoNamesMatch()
    {
        string pressedSequence = string.Join(", ", pressedPianoNames);
        string defaultSequence = string.Join(", ", defaultPianoNames);

        if (pressedSequence.Contains(defaultSequence))
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
    }
}
