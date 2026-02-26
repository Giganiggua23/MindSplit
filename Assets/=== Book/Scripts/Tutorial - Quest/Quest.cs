using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Quest", menuName = "Tutorial/Quest")]

public class Quest : ScriptableObject
{
#pragma warning disable 0414
    // ====

    [Header("      === Настройки квеста ===")]
    [Tooltip("Название квеста")]
    public string QuestName = "Название";

    [Tooltip("Описание (в книгу)")]
    [Multiline(10)]
    public string QuestText = "Описание";

    [Tooltip("Подсказка которая напишется через время")]
    [SerializeField] private string QuestHelp = "Подсказка";

    [Tooltip("ВКЛ если требуется кол-во, собранных предметов")]
    public bool IsQuestAmount = false;
    public int QuestAmountDrop = 0;

    [Header("      === Программные переменные ===")]
    public bool IsQuestActive = false;
    public bool IsQuestReady = false;
    public bool IsQuestHelp = false;
    public int QuestHowAmountDrop;

    //Хранение заводских настроек
    private bool _defaultIsQuestActive;
    private bool _defaultIsQuestReady;
    private bool _defaultIsQuestHelp;
    private int _defaultQuestHowAmountDrop;

    // Путь для сохранения
    private string SavePath => Application.persistentDataPath + $"/Quest_{name}.json";

#pragma warning restore 0414

    private void OnEnable()
    {
        SaveDefaultValues();
    }

    // Метод сохранения программных переменных
    public void SaveQuestData()
    {
        try
        {
            QuestSaveData saveData = new QuestSaveData
            {
                isQuestActive = this.IsQuestActive,
                isQuestReady = this.IsQuestReady,
                IsQuestHelp = this.IsQuestHelp,
                questHowAmountDrop = this.QuestHowAmountDrop
            };

            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(SavePath, json);

           
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving quest data: {e.Message}");
        }
    }

    // Метод загрузки программных переменных
    public void LoadQuestData()
    {
        try
        {
            if (File.Exists(SavePath))
            {
                string json = File.ReadAllText(SavePath);
                QuestSaveData saveData = JsonUtility.FromJson<QuestSaveData>(json);

                this.IsQuestActive = saveData.isQuestActive;
                this.IsQuestReady = saveData.isQuestReady;
                this.IsQuestHelp = saveData.IsQuestHelp;
                this.QuestHowAmountDrop = saveData.questHowAmountDrop;
            }
            else
            {
                Debug.Log($"No save file found for {name}, using default values");
                ResetToDefault();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error loading quest data: {e.Message}");
            ResetToDefault();
        }
    }

    // Метод сброса до заводских настроек
    public void ResetToDefault()
    {
        this.IsQuestActive = _defaultIsQuestActive;
        this.IsQuestReady = _defaultIsQuestReady;
        this.IsQuestHelp = _defaultIsQuestHelp;
        this.QuestHowAmountDrop = _defaultQuestHowAmountDrop;
    }

    // Сохранение заводских настроек
    private void SaveDefaultValues()
    {
        _defaultIsQuestActive = this.IsQuestActive;
        _defaultIsQuestReady = this.IsQuestReady;
        _defaultIsQuestHelp = this.IsQuestHelp;
        _defaultQuestHowAmountDrop = this.QuestHowAmountDrop;
    }

    // Удаление сохранения (если нужно)
    public void DeleteSaveFile()
    {
        try
        {
            if (File.Exists(SavePath))
            {
                File.Delete(SavePath);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error deleting save file: {e.Message}");
        }
    }
}

// Класс для сериализации данных
[System.Serializable]
public class QuestSaveData
{
    public bool isQuestActive;
    public bool isQuestReady;
    public bool IsQuestHelp;
    public int questHowAmountDrop;
}