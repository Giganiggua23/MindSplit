using UnityEngine;

public class ShelfTrigTrap : MonoBehaviour
{
    [SerializeField] GameObject Trap;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trap.SetActive(true);
        }
    }
}
