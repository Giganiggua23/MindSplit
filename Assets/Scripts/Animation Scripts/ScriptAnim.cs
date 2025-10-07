using UnityEngine;

public class ScriptAnim : MonoBehaviour
{

    [SerializeField] Animator anim;

    bool _aWalk;


    

    public void AWalk(bool active)
    {
        anim.SetBool("IsWalk", active);
        _aWalk = active;
    }

    


  
}
