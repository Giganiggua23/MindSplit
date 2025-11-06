using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] private SpecificMaterialChanger _VXMaterial;
    [SerializeField] Movement _movement;

    [SerializeField] LampAnimation _lampAnimation;


    public Transform targetObject;
    public float rotationSpeed = 30f; // градусов в секунду

    private bool OnTrig;
    
    


    void Start()
    {

    }


    void Update()
    {
        if (OnTrig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _movement.PlayerUseObj(!_movement._IsUse);
                _lampAnimation.OnActive = !_lampAnimation.OnActive;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            targetObject.Rotate(0, 0,rotationSpeed * Time.deltaTime, Space.Self);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            targetObject.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTrig = true;
            _VXMaterial.SetOutLine(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _VXMaterial.SetOutLine(false);
            OnTrig = false;
        }
    }
}
