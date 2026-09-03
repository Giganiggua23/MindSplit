using UnityEngine;

public class PlateLogic : MonoBehaviour
{
    [SerializeField] bool _negativePlate;
    [SerializeField] bool _neitralTrapPlate;
    [SerializeField] bool _positivePlate;


    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Material _plateMaterialRed;
    [SerializeField] private Material _plateMaterialYellow;
    [SerializeField] private Material _plateMaterialGreen;

    [SerializeField] private Material _plateMaterialGrey;


    [SerializeField] Animator _anim;


    void Start()
    {
        meshRenderer.material = _plateMaterialGrey;

        _anim.SetBool("_ifNigative", _negativePlate);
        _anim.SetBool("_ifNeitral", _neitralTrapPlate);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_negativePlate)
            {
                NegativePlate();
            }

            if (_neitralTrapPlate)
            {
                NeitralTrapPlate();
            }

            if (_positivePlate)
            {
                PositivePlate();
            }

            else
            {
                Debug.Log("None");
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        
    }


    void NegativePlate() // RED     Fire
    {
        meshRenderer.material = _plateMaterialRed;
        _anim.SetTrigger("Activeted");
    }

    void NeitralTrapPlate() // YELLOW   Pics
    {
        meshRenderer.material = _plateMaterialYellow;

        _anim.SetTrigger("Activeted");

    }

    void PositivePlate() // GREEN
    {
        meshRenderer.material = _plateMaterialGreen;
    }
    
}



// Кинжалы 