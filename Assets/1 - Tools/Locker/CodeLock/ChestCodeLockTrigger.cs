using UnityEngine;

public class ChestCodeLockTrigger : MonoBehaviour
{
    [SerializeField] CodeLockLogic _codeLockLogic;
    [SerializeField] bool OnTriggerStay;
    [SerializeField] PlayerStateManager _playerStateManager;
    [SerializeField] Animator anim;

    // OBJ
    [SerializeField] Animator _animChest;
    [SerializeField] GameObject _trigTake;

    void Start()
    {
        _trigTake.SetActive(false);
    }

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

    public void OpenChest()
    {
        if (_animChest != null)
            _animChest.SetTrigger("OpenChest");

        if (_trigTake != null)
            _trigTake.SetActive(true);
    }
}
