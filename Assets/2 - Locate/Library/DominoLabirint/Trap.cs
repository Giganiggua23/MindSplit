using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] PlayerHealthPoint _playerHealthPoint;

    //SFX
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerHealthPoint = player.GetComponent<PlayerHealthPoint>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play(); 
            animator.SetBool("ExitTrap", false);
            animator.SetTrigger("InTrap");
            _playerHealthPoint.MinesHp(1);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("ExitTrap", true);
        }
    }
}
