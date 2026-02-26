using UnityEngine;

public class ActivatorTrigger : MonoBehaviour
{
    public string NameQuest = "Name";
    public Quest QuestTrig;

    public TutorialManager tutorialManager;

    void Start()
    {
        NameQuest = QuestTrig.QuestName;
        GameObject tutorialManagerObject = GameObject.Find("Items");
        if (tutorialManagerObject != null)
        {
            tutorialManager = tutorialManagerObject.GetComponent<TutorialManager>();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestTrig.IsQuestActive = true;
            tutorialManager.QuestNameActive = QuestTrig.QuestName;

            tutorialManager.DisplayActiveQuests();
        }
        
    }

    public void OnTriggerExit()
    {
        
    }
}
