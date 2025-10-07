using UnityEngine;

public class ChestCodeLockTrigger : MonoBehaviour
{
    [SerializeField] CodeLockLogic _codeLockLogic;
    [SerializeField] bool OnTriggerStay;
    [SerializeField] Movement _movement;
    [SerializeField] Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && OnTriggerStay)
        {
            ActiveCodeLock();
        }
            
    }

    void OnTriggerCodeLock(bool active)
    {
        OnTriggerStay = active;
    }


    void ActiveCodeLock()
    {
        _codeLockLogic.isUseCodeLock = !_codeLockLogic.isUseCodeLock;
        _movement.IsUse_Movement = !_movement.IsUse_Movement;
        anim.SetBool("IsuseCam", _movement.IsUse_Movement);

        if (_movement.IsUse_Movement == true)
        {
            anim.SetTrigger("Use");
        }
        
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTriggerCodeLock(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTriggerCodeLock(false);
        }
    }
}
