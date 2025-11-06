using UnityEngine;

public class HelmDelyvery : MonoBehaviour
{
    [SerializeField] GameObject Loot;
    [SerializeField] GameObject Halm;
    [SerializeField] Branch branchComponent;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HalmActive"))
        {
            Activization();
        }
    }


    void Activization()
    {
        
        Halm.SetActive(true);
        branchComponent.enabled = true;
        Loot.SetActive(false);
    }
}
