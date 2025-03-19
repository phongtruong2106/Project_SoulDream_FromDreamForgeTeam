using System.IO;
using UnityEngine;

public class ClearData : FilePath
{
    public void ClearDataSave()
    {
        ClearFile(positionFilePath);
        ClearFile(sceneFilePath);
        ClearFile(puzzelFilePath);
        ClearFile(DoorFilePath);
        ClearFile(CutScenesFilePath);
        ClearFile(DialogueFilePath);
    }

    private void ClearFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath, string.Empty);  // Clears the file content
        }
        else
        {
            Debug.LogWarning($"File {filePath} does not exist and cannot be cleared.");
        }
    }
}