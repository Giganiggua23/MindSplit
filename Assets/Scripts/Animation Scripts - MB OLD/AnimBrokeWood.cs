using UnityEngine;

public class AnimBrokeWood : MonoBehaviour
{
    [SerializeField] Animator anim;
     bool _exit;
    [SerializeField] GameObject obj;
    bool Use;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Use = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Use = false;
        }
    }


    void Update ()
    {
        if (Use && Input.GetKey(KeyCode.E) && !_exit)
        {
            anim.SetTrigger("Broke");
            _exit = true;
        }

        if (_exit && !Use)
        {
            obj.SetActive(false);
        }
    }
}
