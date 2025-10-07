using UnityEngine;
using TMPro;

public class CodeLockLogic : MonoBehaviour
{
    private int[] Code = {0, 0, 0};

    private int CodeKey = 1;

    [SerializeField] Transform CodeOneCount;
    [SerializeField] Transform CodeTwoCount;
    [SerializeField] Transform CodeTreeCount;



    [SerializeField] private float rotationSpeed = 90f;
    private float[] targetRotations = { 0f, 0f, 0f };
    private bool isRotating = false;   
    public bool isUseCodeLock = false;

    [SerializeField] ChestOpen _chestOpen;
    int a;
    int b;
    int c;

    bool ready;

    [SerializeField] TMP_Text _a;
    [SerializeField] TMP_Text _b;
    [SerializeField] TMP_Text _c;

    void Start()
    {
        a = Random.Range(0, 9);
        b = Random.Range(0, 9);
        c = Random.Range(0, 9);

        _a.text = a.ToString();
        _b.text = b.ToString();
        _c.text = c.ToString();
    }



    void Update()
    {
        if (isUseCodeLock)
        {
            // Прокрут 
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating)
            {
                Code[CodeKey] -= 1;
                targetRotations[CodeKey] -= 36f;
                isRotating = true;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
            {
                Code[CodeKey] += 1;
                targetRotations[CodeKey] += 36f;
                isRotating = true;
            }

            //Вверх Вниз
            if (Input.GetKeyDown(KeyCode.UpArrow) && CodeKey != 0)
            {
                CodeKey -= 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && CodeKey != 2)
            {
                CodeKey += 1;
            }
        }

        if (Code[CodeKey] <= -1)
        {
            Code[CodeKey] = 9;
        }
        if (Code[CodeKey] >= 10)
        {
            Code[CodeKey] = 0;
        }

        switch (CodeKey)
        {
            case 0:
                RotateManager(CodeOneCount,0);
                break;
            case 1:
                RotateManager(CodeTwoCount,1);
                break;
            case 2:
                RotateManager(CodeTreeCount,2);
                break;

        }

        void RotateManager(Transform obj, int index)
        {
            if (obj == null) return;

            float currentAngle = obj.localEulerAngles.y; 
            float targetRotation = targetRotations[index];

            if (isRotating && index == CodeKey)
            {
                float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetRotation, rotationSpeed * Time.deltaTime);
                obj.localEulerAngles = new Vector3(0, newAngle, 0); 

                if (Mathf.Abs(Mathf.DeltaAngle(newAngle, targetRotation)) < 0.1f)
                {
                    isRotating = false;
                }
            }
            else
            {
                obj.localEulerAngles = new Vector3(0, targetRotation, 0);
            }
        }


        if (a == Code[0] && b == Code[1] && c == Code[2] && !ready)
        {
            _chestOpen.OpenChest();
            ready = true;
        }
        

        // -+ 36
        
    }

}
