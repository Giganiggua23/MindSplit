using UnityEngine;
using System.Collections;

public class PlateLogic : MonoBehaviour
{
    [SerializeField] bool _negativePlate;
    [SerializeField] bool _neitralTrapPlate;
    [SerializeField] bool _positivePlate;


    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private Material _plateMaterialRed;
    [SerializeField] private Material _plateMaterialYellow;
    [SerializeField] private Material _plateMaterialGreen;

    private Material _redPlate;

    private Material _yellowPlate;

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
                if (_redPlate == null)
                {
                    _redPlate = new Material(_plateMaterialYellow);
                    meshRenderer.material = _redPlate;

                }
                StartCoroutine(NegativePlate());
            }

            if (_neitralTrapPlate)
            {
                if (_yellowPlate == null)
                {
                    _yellowPlate = new Material(_plateMaterialYellow);
                    meshRenderer.material = _yellowPlate;
                }

                StartCoroutine(NeitralTrapPlate());
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


    IEnumerator NegativePlate() // RED     Fire
    {
        _redPlate.color = new Color(1f, 0.647f, 0f);

        yield return new WaitForSeconds(1);

        _redPlate.color = new Color(1f, 0f, 0f);
        _anim.SetTrigger("Activeted");
    }

    IEnumerator NeitralTrapPlate() // YELLOW   Pics
    {
        _yellowPlate.color = new Color(1f, 1f, 0f);

        yield return new WaitForSeconds(1);

        _yellowPlate.color = new Color(1f, 0.647f, 0f);

        _anim.SetTrigger("Activeted");

    }

    void PositivePlate() // GREEN
    {
        meshRenderer.material = _plateMaterialGreen;
    }
    
}



// Кинжалы 