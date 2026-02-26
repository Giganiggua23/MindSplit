using UnityEngine;

public class ChestCodeLockTrigger : MonoBehaviour
{
    [SerializeField] CodeLockLogic _codeLockLogic;
    [SerializeField] bool OnTriggerStay;
    [SerializeField] PlayerStateManager _playerStateManager;
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
        _playerStateManager.PlayerUseObj(!_playerStateManager._IsUse);
        anim.SetBool("IsuseCam", _playerStateManager._IsUse);

        if (_playerStateManager._IsUse == true)
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
