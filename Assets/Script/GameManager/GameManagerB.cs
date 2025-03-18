using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerB : NewMonoBehaviour
{
    [SerializeField] protected ChangeLanguage changeLanguage;
    public ChangeLanguage _changeLanguage => changeLanguage;
    [SerializeField] protected NewGame newGame;
    public NewGame _NewGame => newGame;
    [SerializeField] protected ExitToMenu exitToMenu;
    public ExitToMenu _ExitToMenu => exitToMenu;
    [SerializeField] protected Show_PanelSetting show_PanelSetting;
    public Show_PanelSetting _ShowPanelSetting => show_PanelSetting;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChangeLanguege();
        this.LoadNewGame();
        this.LoadExitToMenu();
        this.LoadShowPanelSetting();
    }
    protected virtual void LoadChangeLanguege()
    {
        if(this.changeLanguage != null) return;
        this.changeLanguage = FindAnyObjectByType<ChangeLanguage>();
    }
    protected virtual void LoadExitToMenu()
    {
        if(this.exitToMenu != null) return;
        this.exitToMenu = gameObject.GetComponentInChildren<ExitToMenu>();
    }
    protected virtual void LoadNewGame()
    {
        if(newGame != null) return;
        this.newGame = gameObject.GetComponentInChildren<NewGame>();
    }
    protected virtual void LoadShowPanelSetting()
    {
        if(this.show_PanelSetting != null) return;
        this.show_PanelSetting = gameObject.GetComponentInChildren<Show_PanelSetting>();
    }
}
