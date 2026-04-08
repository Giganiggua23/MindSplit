using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public PlayerStateManager _playerStateManager;
    public ItemManager _itemManager;


    public Action OnButtonActive;

    public int ItemID;

    // OBJ - Canvas Keys

    [SerializeField] GameObject ButtonE;
    [SerializeField] GameObject ButtonLMB;
    // [SerializeField] GameObject ButtonM; // When Canvas obj is Show

    
   

    // OBJ - obj in scene
    [SerializeField] GameObject BookOBJ;



    public GameObject OBJToDrop;
    [SerializeField] Transform PositionOut;
    private Rigidbody objRigidbody;

    public GameObject OBJToCancel;


    // Keys ===

    public KeyCode MapKey = KeyCode.M;
    public KeyCode DropItemKey = KeyCode.Q;
    public KeyCode UseItemKey = KeyCode.E;


    // SO ===
    public Item ItemNow;

    public Item Note;
   
    


    void Start()
    {
        
        BookOBJ.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(DropItemKey) && OBJToDrop != null && ItemNow.ItemHave == false)
        {
            OBJToCancel.SetActive(false);
            MoveToOutPoint();
            _playerStateManager.ItemUse(false);
            ItemID = 0;
            ItemNow = null;
        }
        else if (Input.GetKeyDown(DropItemKey) && ItemNow.ItemHave == true && ItemNow != null)
        {
            ActiveItem(false);
        }



        if (Input.GetKeyDown(UseItemKey) && ItemNow == null && !_playerStateManager._IsUse) // беру объекты с земли
        {
            if (OnButtonActive != null) //?.Invoke()
            {
                OnButtonActive();
                ItemID = ItemNow.ID;
                _playerStateManager.ItemUse(true);
            }
           
        }



        if (Input.GetKeyDown(MapKey) && Note != null && ItemNow == null && !_playerStateManager._IsUse)
        {
            ItemNow = Note;
           // _itemManager.FindItem(ItemNow.ItemGOName);
            BookOBJ.SetActive(true);
            ActiveItem(true);

            ItemID = Note.ID;
                return; 
        }
        else if (Input.GetKeyDown(MapKey) && ItemNow != null && ItemNow.ID == Note.ID)
        {
            BookOBJ.SetActive(false);
            ActiveItem(false);
            ItemID = 0;
            ItemNow = null;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button_E"))
        {
            ButtonE.SetActive(true);
        }

        if (other.CompareTag("Button_LMB"))
        {
            ButtonLMB.SetActive(true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (ButtonE != null)
        {
            ButtonE.SetActive(false);
        }

        if (ButtonLMB != null)
        {
            ButtonLMB.SetActive(false);
        }

    }


    void MoveToOutPoint()
    {
        if (OBJToDrop == null || PositionOut == null) return;

        objRigidbody = OBJToDrop.GetComponent<Rigidbody>();
        OBJToDrop.transform.position = PositionOut.position;
        OBJToDrop.SetActive(true);
        
        if (objRigidbody != null)
        {
            objRigidbody.linearVelocity = Vector3.zero;
            objRigidbody.angularVelocity = Vector3.zero;

             objRigidbody.AddForce(PositionOut.forward * 5f, ForceMode.Impulse);

            OBJToDrop = null;
        }
    }

    void ActiveItem(bool active)
    {
        
        _playerStateManager.ItemUse(active);
        ItemNow.ItemUse = active;
    }

    //targetObject.SetActive(!targetObject.activeSelf);    - Re active
}
