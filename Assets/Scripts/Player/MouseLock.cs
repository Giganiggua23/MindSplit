using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField] private float mouseSebsitivity = 200f;

    [SerializeField] private Transform playerBody;


    public bool _isUse_Camera = false;

    private float xRotation = 0f;

    [SerializeField] GameObject EscapeMenu;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSebsitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSebsitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        if (!_isUse_Camera)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }

    public void LookAtObj(GameObject targetOBJ)  
    {
        if (targetOBJ == null) return;

        
        Vector3 direction = targetOBJ.transform.position - transform.position; // Вычисляем направление к объекту

        // Получаем вращение, смотрящее на объект
        Quaternion targetLookRotation = Quaternion.LookRotation(direction);
        Vector3 eulerAngles = targetLookRotation.eulerAngles;

        // Для оси X
        float targetXRotation = eulerAngles.x;
        if (targetXRotation > 180)
            targetXRotation -= 360;
        targetXRotation = Mathf.Clamp(targetXRotation, -90f, 90f);

        // Плавная интерполяция для камеры (Lerp для углов)
        xRotation = Mathf.LerpAngle(xRotation, targetXRotation, Time.deltaTime * 5f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Для оси Y 
        float targetYRotation = eulerAngles.y;
        if (targetYRotation > 180)
            targetYRotation -= 360;

        // Плавное вращение
        Quaternion targetBodyRotation = Quaternion.Euler(0f, targetYRotation, 0f);
        playerBody.rotation = Quaternion.Slerp(playerBody.rotation, targetBodyRotation,
                                              Time.deltaTime * 5f);
    }


    public void AltLookAround()
    {

    }
    
}
