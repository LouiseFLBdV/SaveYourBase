using UnityEngine;

public class BaseController : MonoBehaviour
{
    private float[] originalAlpha;
    public float highlightAlpha = 0.98f; 
    
    private void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        originalAlpha = new float[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalAlpha[i] = renderers[i].material.color.a;
        }
    }
    
    public void AddUnit()
    {
        Debug.Log("Added Unit");
    }

    private void OnMouseDown()
    {
        Debug.Log("Added Unit");
    }
    
    void OnMouseOver()
    {
        SetHighlightColor(); 
    }

    void OnMouseExit()
    {
        ResetOriginalColors(); 
    }
    
    private void SetHighlightColor()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            Color color = renderers[i].material.color;
            color.a = highlightAlpha;
            renderers[i].material.color = color;
        }
    }

    private void ResetOriginalColors()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            Color color = renderers[i].material.color;
            color.a = originalAlpha[i];
            renderers[i].material.color = color;
        }
    }
}
