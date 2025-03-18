using UnityEngine;

public class ExitToMenu : LoadScenes
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.nameScene = "MainMenu";
    }
}