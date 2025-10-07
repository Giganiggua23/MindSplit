using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthPoint : MonoBehaviour
{
    [SerializeField] int HealthPlayer;

    void Start()
    {
        
    }



    public void MinesHp(int point)
    {
        HealthPlayer = HealthPlayer - point;
    }

    void Update()
    {
        if (HealthPlayer <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Time.timeScale = 0;

        //SceneManager.LoadScene(2);
    }





    

}
