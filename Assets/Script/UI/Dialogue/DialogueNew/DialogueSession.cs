using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueSession
{
    public Story Story { get; private set; }
    public GameObject Panel { get; private set; }
    public TextMeshProUGUI Text { get; private set; }
    public TextMeshProUGUI NameText { get; private set; }

    public DialogueSession(Story story, GameObject panel, TextMeshProUGUI text, TextMeshProUGUI nameText)
    {
        Story = story;
        Panel = panel;
        Text = text;
        NameText = nameText;
    }
}