using UnityEngine;

public class PlayerStateManager : MonoBehaviour  // Состояния персонажа и его анимации
{

    [SerializeField] Animator anim;



    //===== - Состояния

    protected bool _aWalk;
    protected bool _isRunning;

    public bool _IsUse; 

    //=====

    void Start()
    {
        
    }
    void Update()
    {
        
    }





    public void PlayerUseObj(bool active)
    {
        _IsUse = active;
        _aWalk = !active;   
    }

    public void AWalk(bool active)
    {
        if (!_IsUse)
        {
            anim.SetBool("IsWalk", active);
            _aWalk = active;
        }
        
    }
}
