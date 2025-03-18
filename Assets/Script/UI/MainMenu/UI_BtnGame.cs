using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_BtnGame : NewMonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Button button;
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected String VN_text;
    [SerializeField] protected String EN_text;
    [SerializeField] protected UI_Option_MainMenu uI_Option_MainMenu;
    [SerializeField] protected UI_Option_Setting uI_Option_Setting;
    [SerializeField] protected GameManagerB gameManagerB;
     [SerializeField] protected List<SO_dataSave> sO_DataSaveList;

    [Header("Hover Settings")]
    [SerializeField] protected Color normalColor;
    [SerializeField] protected Color hoverColor;
    
    protected bool isStartGameInitialized = false;
    public bool isCanHover;
    protected bool isCall;

    protected override void Start()
    {
        base.Start();
        this.uI_Option_MainMenu._uIControllerMainMenu._gameManagerB._changeLanguage._sO_UISetting.LoadFromPlayerPrefs();
        this.isStartGameInitialized = false;
        this.isCall = false;
    }

    protected virtual void Update()
    {
        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnGame();
        this.LoadTextGame();
        this.LoadUI_Option_MainMenu();
        this.LoadUI_Option_Setting();
        this.LoadGameManagerB();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.isCanHover = true;
  
    }
    protected virtual void LoadBtnGame()
    {
        if(this.button != null) return;
        this.button = gameObject.GetComponent<Button>();
    }
    protected virtual void LoadTextGame()
    {
        if(this.text != null) return;
        this.text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected virtual void LoadUI_Option_MainMenu()
    {
        if(this.uI_Option_MainMenu != null) return;
        this.uI_Option_MainMenu = gameObject.GetComponentInParent<UI_Option_MainMenu>();
    }
    protected virtual void LoadUI_Option_Setting()
    {
        if(this.uI_Option_Setting != null) return;
        this.uI_Option_Setting = gameObject.GetComponentInParent<UI_Option_Setting>();
    }
    private void LoadGameManagerB()
    {
        if(this.gameManagerB != null) return;
        this.gameManagerB = FindAnyObjectByType<GameManagerB>();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(this.isCanHover)
        {
            text.color = normalColor;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.isCanHover)
        {
            text.color = hoverColor;  
        }
       
    }
}