using UnityEngine;

public class ClosetManager : MonoBehaviour
{
    /*
     * Создать зону при входе  вкоторую уменьшается сфера захвата Item  +
     * 
     * При наведении и нажатии на лкм ящик проиграет анимку выдвижения и активирует или 
     * диактивирует предмет который находиться ниже по иархии, но активация триггера открытия через 2й скрипт, каждого ящика
     * 
     * Как только предмет достаётся, он вытаскивается из под иэрархии шкафчика, но это будет если обновить скрипт по захвату объектов 
     * 
     * 
     * 
     */


    // === Drawer State ===

    public bool stateDrawer1; // true - Isopen false - Iscose
    public bool stateDrawer2;
    public bool stateDrawer3;
    public bool stateDrawer4;

    // ________________

    public Animator animator;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        
    }
}
