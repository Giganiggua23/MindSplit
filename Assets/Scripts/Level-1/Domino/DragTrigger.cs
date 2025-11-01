using UnityEngine;

public class DragTrigger : MonoBehaviour
{
    public DraggableItem _draggableItem;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _draggableItem.DragTrigUse = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _draggableItem.DragTrigUse = false;
        }
    }
}
