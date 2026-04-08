using UnityEngine;

public class DragTrigger : MonoBehaviour
{
    public ClosetDomino _closetDomino;
    

    void Start()
    {
        _closetDomino = GetComponentInParent<ClosetDomino>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _closetDomino.DragTrigUse = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _closetDomino.DragTrigUse = false;
        }
    }
}
