using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField] Animator _animChest;
    [SerializeField] GameObject _trigTake;


    void Start()
    {
        _trigTake.SetActive(false);
    }

    public void OpenChest()
    {
        _animChest.SetTrigger("OpenChest");
        _trigTake.SetActive(true);
    }
}
