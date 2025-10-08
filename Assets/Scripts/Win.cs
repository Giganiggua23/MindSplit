using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject TextToWin;


    void Start()
    {
        TextToWin.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextToWin.SetActive(true);
        }
            
    }
}
