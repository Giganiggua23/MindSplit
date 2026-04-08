using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class TutorialManager : MonoBehaviour
{
    /*
        - Создавать квесты из инспектора 
        - квесты могут вызываться и эргономично вставать друг за дружкой 
        - под квестами могут быть суб квесты
        - либо квест идёт за квестом либо у них есть последовательность которой придерживаются 
        - вычёркивать то что сделано 

        - думать наперёд, книга будет содержать карту, квесты, записи или истории

        - карта, показывает просто начертание локации (тоже нужно составить тз)
        - 
    
        + сделать цепь


        ДОПКА НАДО СДЕЛАТЬ СРОЧНО 
        
        + Позвонить инструктору по вождению
        - 

    */
    

    public List<Quest> items = new List<Quest>();
    public string QuestNameActive;

    public TextMeshProUGUI questText;

    [SerializeField] bool IsGame;

    void Start()
    {
        if (IsGame)
        {
            LoadAllQuest();
            DisplayActiveQuests();
        }
    }
    
    void OnApplicationQuit()        //при выходе - alt f4
    {
        if (IsGame)
        {
            SaveAllQuests();
        }
    }


    void Update()
    {
        if (IsGame)
        {
            /*
            Debug.Log("1 " + QuestNameActive);
            Debug.Log("2 " + FindQuestByName(QuestNameActive));
            */
        }
    }


    Quest FindQuestByName(string questName)
    {
        foreach (Quest quest in items)
        {
            if (quest.QuestName == questName)
            {
                return quest;
            }
        }
        return null;
    }

    public void DisplayActiveQuests()
    {
        questText.text = "Активные квесты:\n";

        foreach (Quest quest in items)
        {
            if (quest.IsQuestActive)
            {
                questText.text += $"• {quest.QuestText}\n";
                
            }
        }
    }

    public void LoadAllQuest()      //Загрузка всех квестов
    {
        foreach (Quest quest in items)
        {
            if (quest != null)
            {
                quest.LoadQuestData();
            }
        }
    }

    public void SaveAllQuests()
    {
        foreach (Quest quest in items)
        {
            if (quest != null)
            {
                quest.SaveQuestData();
            }
        }
    }

    public void ResetAllQuests()
    {
        foreach (Quest quest in items)
        {
            if (quest != null)
            {
                quest.ResetToDefault();
            }
        }
    }

}
