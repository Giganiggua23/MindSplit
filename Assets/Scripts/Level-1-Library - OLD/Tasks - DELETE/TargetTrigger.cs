using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject Tasks;
    [SerializeField] GameObject Tasks2;


    [SerializeField] bool ItTast2;

    void Start()
    {
        Tasks.SetActive(false);
        if (ItTast2)
        {
            Tasks2.SetActive(false);
        }
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Tasks.SetActive(true);
        }
        if (other.CompareTag("Player") && ItTast2)
        {
            Tasks.SetActive(false);
            Tasks2.SetActive(true);
        }
    }
}


