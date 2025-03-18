using UnityEngine;

[CreateAssetMenu(menuName = "Project_SoulDream_FromDreamForge/SO_ObjJump")]
public class SO_ObjJump : ScriptableObject
{
    public float jumpCooldown = 2f;
    public float longJumpForce = 5f; // Lực nhảy xa
    public float TimeJump = 1f;
}