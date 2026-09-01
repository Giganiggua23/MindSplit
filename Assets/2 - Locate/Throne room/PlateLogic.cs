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



    void Start()
    {
        meshRenderer.material = _plateMaterialGrey;
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


    void NegativePlate() // RED
    {
        meshRenderer.material = _plateMaterialRed;
    }

    void NeitralTrapPlate() // YELLOW
    {
        meshRenderer.material = _plateMaterialYellow;

    }

    void PositivePlate() // GREEN
    {
        meshRenderer.material = _plateMaterialGreen;
    }
    
}








// Кинжалы 