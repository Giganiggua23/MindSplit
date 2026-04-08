using UnityEngine;

public class FakeHammer : MonoBehaviour
{
    public GameObject _onePart;
    public GameObject _theePart;

    public GameObject HammerItem;
    public GameObject HammerOnPlayer;

    public ButtonManager _buttonManager;
    public PlayerStateManager _playerStateManager;


    public Item HammerSO;

    bool a = false;


    bool _onArea;   //  tester
    void Start()
    {

    }

    void Update()
    {
        if (_onePart.activeSelf && _theePart.activeSelf && !a)
        {
            OnTrig();
            a = true;
        }
    }

    void OnTriggerEnter()
    {
        OnTrig();
    }
    void OnTriggerExit()
    {
        if (_buttonManager.OnButtonActive == HammerPickUp)
        {
            _buttonManager.OnButtonActive = null;
            _onArea = false;
        }
    }

    void HammerPickUp()
    {
        HammerOnPlayer.SetActive(true);
        _buttonManager.OBJToDrop = HammerItem;
        _buttonManager.OBJToCancel = HammerOnPlayer;
        _buttonManager.ItemNow = HammerSO;
        HammerItem.SetActive(false);
    }

    void OnTrig()
    {
        if (_buttonManager.OnButtonActive == null && _onePart.activeSelf && _theePart.activeSelf)
        {
            _buttonManager.OnButtonActive = HammerPickUp;
            _onArea = true;
        }
    }


}
