using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "ScriptAbleObject/CutScenes")]
public class SO_CutScenes : ScriptableObject
{
    [SerializeField] protected VideoClip CutScenesVideoClip;


    public VideoClip GetVideoClip()
    {
        return CutScenesVideoClip;
    }
}