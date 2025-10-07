using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject TextToWin;


    void Start()
    {
        TextToWin.SetActive(false);
    }

    void OnTriggerEnter()
    {
        TextToWin.SetActive(true);
    }
}
