using UnityEngine;

public class PlayerLootTriggerSettings : MonoBehaviour
{
    public Transform triggerPoint;



    void Start()
    {
        DefaultholdPoint();
    }

    public void UPholdPoint()
    {
        triggerPoint.localScale = new Vector3(1f, 1f, 1f);
    }

    public void DefaultholdPoint()
    {
        triggerPoint.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void DownholdPoint()
    {
        triggerPoint.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Closet_Area"))
        {
            DownholdPoint();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Closet_Area"))
        {
            DefaultholdPoint();
        }
    }
}






// ƒобавить настройки отдалени€ приближени€ если упираетс€ во что то , к примеру если луч упираетс€ во что то то точко отьезжает пока не будет касатьс€, 
// но игнорировать игрока и только до определЄнной точки, как и отдал€тьс€   к примеру путь будет записан от 0 локальной позиции до 1 локальной позиции