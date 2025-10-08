using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject Tasks;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Tasks.SetActive(true);
        }
    }
}
