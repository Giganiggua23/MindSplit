using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]
public class Item : ScriptableObject
{
    [Header("       === Настройки Предмета ===")]
    [Tooltip("Название предмета")]
    public string ItemName = "Название";

    [Tooltip("ID")]
    public int ID = 0;

    [Tooltip("Используется ли предмет")]
    public bool ItemUse = false;

    [Tooltip("Есть ли предмет в инвентаре")]
    public bool ItemHave = false;

    [Tooltip("Название игрового объекта = CTRL C+V")]
    public string ItemGOName;

    // === Default values (хранятся в памяти, не в файле)
    private string _defaultItemName;
    private int _defaultID;
    private bool _defaultItemUse;
    private bool _defaultItemHave;
    private string _defaultItemGOName;

    // Флаг первого запуска
    private const string FirstLaunchKey = "Item_FirstLaunch_";
    private string FirstLaunchFlag => FirstLaunchKey + name;

    // Пути для сохранения
    private string SavePath => Application.persistentDataPath + $"/ItemsSave/Item_{name}.json";
    private string DefaultValuesPath => Application.persistentDataPath + $"/ItemsSave/Item_{name}_default.json";

    void OnEnable()
    {
        CheckFirstLaunch();
    }

    private void CheckFirstLaunch()
    {
        if (!PlayerPrefs.HasKey(FirstLaunchFlag))
        {
            // Первый запуск - сохраняем текущие значения как дефолтные
            SaveDefaultValuesToMemory();
            SaveDefaultValuesToFile();

            PlayerPrefs.SetInt(FirstLaunchFlag, 1);
            PlayerPrefs.Save();

        }
        else
        {
            // Не первый запуск - загружаем дефолтные значения из файла
            LoadDefaultValuesFromFile();
        }
    }

    // Сохранение дефолтных значений в память
    private void SaveDefaultValuesToMemory()
    {
        _defaultItemName = this.ItemName;
        _defaultID = this.ID;
        _defaultItemUse = this.ItemUse;
        _defaultItemHave = this.ItemHave;
        _defaultItemGOName = this.ItemGOName;
    }

    // Сохранение дефолтных значений в файл
    private void SaveDefaultValuesToFile()
    {
        try
        {
            string directory = Path.GetDirectoryName(DefaultValuesPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            DefaultValuesData defaultData = new DefaultValuesData
            {
                defaultItemName = this.ItemName,
                defaultID = this.ID,
                defaultItemUse = this.ItemUse,
                defaultItemHave = this.ItemHave,
                defaultItemGOName = this.ItemGOName
            };

            string json = JsonUtility.ToJson(defaultData, true);
            File.WriteAllText(DefaultValuesPath, json);

        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving {name}: {e.Message}");
        }
    }

    // Загрузка дефолтных значений из файла
    private void LoadDefaultValuesFromFile()
    {
        try
        {
            if (File.Exists(DefaultValuesPath))
            {
                string json = File.ReadAllText(DefaultValuesPath);
                DefaultValuesData defaultData = JsonUtility.FromJson<DefaultValuesData>(json);

                if (defaultData != null)
                {
                    _defaultItemName = defaultData.defaultItemName;
                    _defaultID = defaultData.defaultID;
                    _defaultItemUse = defaultData.defaultItemUse;
                    _defaultItemHave = defaultData.defaultItemHave;
                    _defaultItemGOName = defaultData.defaultItemGOName;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error loading {name}: {e.Message}");
        }
    }

    public void SaveItemData()
    {
        try
        {
            string directory = Path.GetDirectoryName(SavePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            ItemSaveData saveData = new ItemSaveData
            {
                ItemName = this.ItemName,
                ID = this.ID,
                ItemUse = this.ItemUse,
                ItemHave = this.ItemHave,
                ItemGOName = this.ItemGOName
            };

            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(SavePath, json);

        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving item data {name}: {e.Message}");
        }
    }

    public void LoadItemData()
    {
        try
        {
            if (File.Exists(SavePath))
            {
                string json = File.ReadAllText(SavePath);
                ItemSaveData saveData = JsonUtility.FromJson<ItemSaveData>(json);

                if (saveData != null)
                {
                    this.ItemName = saveData.ItemName;
                    this.ID = saveData.ID;
                    this.ItemUse = saveData.ItemUse;
                    this.ItemHave = saveData.ItemHave;
                    this.ItemGOName = saveData.ItemGOName;

                }
                else
                {
                    ResetToDefault();
                }
            }
            else
            {
                ResetToDefault();
            }
        }
        catch
        {
            ResetToDefault();
        }
    }


    public void ResetToDefault()
    {
        this.ItemName = _defaultItemName;
        this.ID = _defaultID;
        this.ItemUse = _defaultItemUse;
        this.ItemHave = _defaultItemHave;
        this.ItemGOName = _defaultItemGOName;

    }

}

// Класс для сохранения данных предмета
[System.Serializable]
public class ItemSaveData
{
    public string ItemName;
    public int ID;
    public bool ItemUse;
    public bool ItemHave;
    public string ItemGOName;
}

// Класс для сохранения дефолтных значений
[System.Serializable]
public class DefaultValuesData
{
    public string defaultItemName;
    public int defaultID;
    public bool defaultItemUse;
    public bool defaultItemHave;
    public string defaultItemGOName;
}