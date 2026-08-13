using UnityEngine;

public class DrawerUse : MonoBehaviour
{
    private int drawerIndex;

    //[SerializeField] private Animator DrawerAnim;

    [SerializeField] ClosetManager _closetManager;
    [SerializeField] ButtonManager _buttonManager;      // для отображения и валидации

    private bool _state;
    private string _animtgigOpen;
    private string _animtgigClose;

    private bool _onCollider;

    [SerializeField]  private GameObject OutLine;

    void Start()
    {
        drawerIndex = GetNumberDrawer();
        if (_state == null)
        {
            _state = GetDrawerBool(drawerIndex, _state);
        }
        if (_animtgigOpen == null)
        {
            GetDrawerAnim(drawerIndex);
        }

        if (OutLine != null)
            OutLine.SetActive(false);


        _animtgigClose = "C" + _animtgigOpen;
    }

    void Update()
    {
        if (Input.GetKeyDown(_buttonManager.UseItemKey) && _onCollider && !_state)
        {
            _closetManager.animator.SetTrigger(_animtgigOpen);
            SetDrawerBool(drawerIndex, true);
            _state = true;

        }
        else if (Input.GetKeyDown(_buttonManager.UseItemKey) && _onCollider && _state)
        {
            _closetManager.animator.SetTrigger(_animtgigClose);
            SetDrawerBool(drawerIndex, false);
            _state = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onCollider = true;
            OutLine.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onCollider = false;
            OutLine.SetActive(false);
        }
    }



    int GetNumberDrawer()
    {
        return int.Parse(gameObject.name[^1].ToString());
    }

  
    bool GetDrawerBool(int index, bool state)
    {
        switch (index)
        {
            case 1:
                state = _closetManager.stateDrawer1;
                
                break;

            case 2:
                state = _closetManager.stateDrawer2;
                
                break;

            case 3:
                state = _closetManager.stateDrawer3;
                
                break;

            case 4:
                state = _closetManager.stateDrawer4;
                
                break;
        }
        return state;
    }

    void SetDrawerBool(int index, bool state)
    {
        switch (index)
        {
            case 1:
                _closetManager.stateDrawer1 = state;
                break;

            case 2:
                _closetManager.stateDrawer2 = state;
                break;

            case 3:
                _closetManager.stateDrawer3 = state;
                break;

            case 4:
                _closetManager.stateDrawer4 = state;
                break;
        }
    }
    void GetDrawerAnim(int index)
    {
        switch (index)
        {
            case 1:
                _animtgigOpen = "dr1";

                break;

            case 2:
                _animtgigOpen = "dr2";
                break;

            case 3:
                _animtgigOpen = "dr3";
                break;

            case 4:
                _animtgigOpen = "dr4";
                break;
        }
        
    }
}

    

