using UnityEngine;

public class CaveAnimTrigScript : MonoBehaviour
{
    public Animator animator;

    int a = 0;
    
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (a == 0 && other.tag == "Player")    
        {
            animator.SetTrigger("IsTrigOn");
            a = 1;
        }

    }
}
