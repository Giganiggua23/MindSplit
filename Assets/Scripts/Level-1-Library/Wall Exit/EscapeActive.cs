using UnityEngine;

public class EscapeActive : MonoBehaviour
{
    public GameObject Wall;



    void Start()
    {
        Wall.SetActive(true);
    }

    void Update()
    {
        
    }

    public void IsBroken()
    {
        Wall.SetActive(false);
    }
}
