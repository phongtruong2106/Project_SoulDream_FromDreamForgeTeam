using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Project_SoulDream_FromDreamForge/SO_UISetting")]
public class SO_UISetting : ScriptableObject
{
    [SerializeField] private bool isEN = true; // Default is English
    [SerializeField] private bool isVN = false;
    [SerializeField] private int selectedLanguageIndex = 0;

    private const string LanguageKey = "SelectedLanguageIndex";

    public int SelectedLanguageIndex
    {
        get => selectedLanguageIndex;
        set
        {
            selectedLanguageIndex = value;
            UpdateLanguageState();
            SaveToPlayerPrefs();
        }
    }

    public bool IsEN => isEN;
    public bool IsVN => isVN;

    private void UpdateLanguageState()
    {
        isEN = selectedLanguageIndex == 0; // English
        isVN = selectedLanguageIndex == 1; // Vietnamese
    }

    public void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetInt(LanguageKey, selectedLanguageIndex);
        PlayerPrefs.Save();
    }

    public void LoadFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(LanguageKey))
        {
            selectedLanguageIndex = PlayerPrefs.GetInt(LanguageKey);
        }
        else
        {
            selectedLanguageIndex = 0;
        }
        UpdateLanguageState();
    }

    public bool IsLanguage(int languageIndex)
    {
        return selectedLanguageIndex == languageIndex;
    }
}