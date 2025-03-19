    using System;
    using System.Collections;
    using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputPiano : NewMonoBehaviour
{
        [SerializeField] protected SO_Piano sO_Piano;
        private MusicNote musicNote;
        private Animator animator;
        private string namePiano;
        private Piano piano;
        private static int pressCount = 0; 
        protected PianoController pianoController;
        [SerializeField] protected SO_Dialogue sO_Dialogue;
        public bool isNoice;

        protected void FixedUpdate()
        {
            this.IslisteningMusic();
        }
    protected override void Start()
    {
        base.Start();
        this.isNoice  = false;
    }

    protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadAnimator();
            this.LoadMusicNote();
            this.LoadPiano();
            this.LoadPianoController();
        }


        protected virtual void LoadAnimator()
        {
            if(this.animator != null) return;
            this.animator = transform.parent.GetComponent<Animator>();
            //Debug.Log(transform.name + ": LoadAnimator()", gameObject);
        }

        protected virtual void LoadPianoController()
        {
            if(this.pianoController != null) return;
            this.pianoController = transform.parent.parent.GetComponent<PianoController>();
           // Debug.Log(transform.name + ": LoadPianoController()", gameObject);
        }
        protected virtual void LoadPiano()
        {
            if(this.piano != null) return;
            this.piano = transform.parent.parent.GetComponent<Piano>();
           // Debug.Log(transform.name + ": LoadPiano()", gameObject);
        }
        protected virtual void LoadMusicNote()
        {
            if(this.musicNote != null) return;
            this.musicNote = GetComponentInChildren<MusicNote>();
           // Debug.Log(transform.name + ": LoadMusicNote()", gameObject);
        }
        private void OnMouseDown()
        {
            namePiano = sO_Piano.name;
            pressCount++;
            piano.AddpressedPianoName(namePiano);
            animator.SetTrigger(namePiano);
            this.musicNote.Note_Play();

            Debug.Log("Total Press Count: " + pressCount);
        }

        protected virtual void IslisteningMusic()
        {
            if(pressCount > 8)
            {
                pianoController._notificationPiano.IsNotification = true;
                this.isNoice = true;
                 pressCount = 0;
            }
            
        }
    }
