using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    private List<Transform> itemsContainers = new List<Transform>();
    private bool containersCollected = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
     
    void Start()
    {
        CollectAllContainers();
    }

    // Собираем только контейнеры при старте
    private void CollectAllContainers()
    {
        itemsContainers.Clear();

        // Находим все объекты с именем "Items"
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true);

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Items")
            {
                itemsContainers.Add(obj.transform);
            }
        }

        containersCollected = true;
    }

    // Ищем предмет только когда вызывают метод
    public GameObject FindItem(string itemName)
    {
        if (!containersCollected)
        {
            CollectAllContainers();
        }
        string targetName = itemName;

        foreach (Transform container in itemsContainers)
        {
            if (container != null)
            {
                Transform child = container.Find(targetName);
                if (child != null)
                {
                    return child.gameObject;
                }
            }
        }
        return null;
    }

}
