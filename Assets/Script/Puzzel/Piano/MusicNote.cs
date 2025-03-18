using UnityEngine;

public class MusicNote : NewMonoBehaviour
{
    [SerializeField] protected AudioSource note;
    public AudioSource Note => note;

    public void Note_Play()
    {
        note.Play();
    }
}