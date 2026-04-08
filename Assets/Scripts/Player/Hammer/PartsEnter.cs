using UnityEngine;

public class PartsEnter : MonoBehaviour
{
    [SerializeField] private FakeHammer _fakeHammer;
    [SerializeField] private int IdPart = 0;

    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("В триггере");

        if (other.gameObject.name == "HammerItem")
        {
            Debug.Log("Нашел HammerItem");
            if (IdPart == 1)
            {
                _fakeHammer._onePart.SetActive(true);
            }
            if (IdPart == 3)
            {
                _fakeHammer._theePart.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }

    // идея в том чтобы добавлять этот объект у родителю, но не нужно было писать 2 скрипта

}
