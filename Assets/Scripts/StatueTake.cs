using UnityEngine;

public class StatueTake : MonoBehaviour
{
    private bool isMouseHeld = false;
    private float holdTimer = 0f;
    public float requiredHoldTime = 2f; 

    bool Stay = false;

    [SerializeField] GameObject Usearchthis;
    [SerializeField] GameObject Statue;


    void Update()
    {
        if (Input.GetMouseButton(0) && Stay)
        {
            holdTimer += Time.deltaTime;

           
            if (holdTimer >= requiredHoldTime && !isMouseHeld)
            {
                isMouseHeld = true;
                StatueSearch();
            }
        }
        else
        {
            if (holdTimer > 0f)
            {
                holdTimer = 0f;
                if (isMouseHeld)
                {
                    isMouseHeld = false;
                }
            }
        }
    }

    void OnTriggerStay()
    {
        Stay = true;
    }
    void OnTriggerExit()
    {
        Stay = false;
    }


    void StatueSearch()
    {

        Usearchthis.SetActive(true);
        Statue.SetActive(false);
    }
}
