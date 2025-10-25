using UnityEngine;

public class SpecificMaterialChanger : MonoBehaviour
{
    [Header("Target Material")]
    [SerializeField] private Material targetMaterial;
    [SerializeField] private string sizePropertyName = "_Size";

    [Header("Size Settings")]
    [SerializeField] private float sizeValue = 0f;

    void Start()
    {
        ApplySize();
    }

    public void ApplySize()
    {
        if (targetMaterial != null && targetMaterial.HasProperty(sizePropertyName))
        {
            targetMaterial.SetFloat(sizePropertyName, sizeValue);
            Debug.Log($"Size changed to: {sizeValue} on material: {targetMaterial.name}");
        }
    }


    public void SetSize(float newSize) //Для других скриптов
    {
        sizeValue = newSize;
        ApplySize();
    }
}