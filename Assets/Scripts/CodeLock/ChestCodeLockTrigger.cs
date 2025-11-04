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
        _movement.PlayerUseObj(!_movement._IsUse);
        anim.SetBool("IsuseCam", _movement._IsUse);

        if (_movement._IsUse == true)
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
