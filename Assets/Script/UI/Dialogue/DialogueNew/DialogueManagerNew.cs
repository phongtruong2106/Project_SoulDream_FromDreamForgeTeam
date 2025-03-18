using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;

public class DialogueManagerNew : NewMonoBehaviour
{    
    
    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueNameText;
    public bool isCheckEndTalk;
    private const string SPEAKER_TAG = "speaker";
    protected Story currentStory;
    protected bool dialogueIsPlaying;
    public static DialogueManagerNew Instance;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void Awake()
    {
        base.Awake();
        if (Instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        Instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.isCheckEndTalk = false;
        if (dialoguePanel != null)
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
        }
    }
    //Enter Mode
    public void EnterDialogueMode(TextAsset inkJson)
    {
        this.isCheckEndTalk = false;
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        StartCoroutine(ContinueStoryCoroutine());
    }
    public virtual void ExitDialogueMode()
    {
        this.isCheckEndTalk = true;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
    public void InterruptDialogue(TextAsset newInkJson)
    {   
        this.dialogueIsPlaying = true;
        if (dialogueIsPlaying)
        {
            ExitDialogueMode();
        }
        EnterDialogueMode(newInkJson);
    }
    //End
    //Continue Mode
    protected IEnumerator ContinueStoryCoroutine()
    {
        while (currentStory.canContinue)
        {
            string dialogueLine = currentStory.Continue();
            dialogueText.text = dialogueLine; 
            HandleTags(currentStory.currentTags);
            yield return new WaitForSeconds(5f); // Adjust this delay as needed
        }

        ExitDialogueMode(); 
    }
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    dialogueNameText.text = tagValue;
                    break;
                default:
                    Debug.LogWarning("tag came in but is not currently being handle: " + tag);
                    break;
            }
        }
    }
}
