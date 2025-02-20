using TMPro;
using UnityEngine;

public class ChangeTextOnClick : MonoBehaviour
{ 
    private TextMeshPro sourceText; // Texto de origem
    private MeshRenderer textBounds; // Limites do texto para detecção do mouse

    public TextMeshPro targetText; // Texto de destino

    void Start()
    {
        // Obtém o MeshRenderer do objeto para verificar os limites do texto
        textBounds = GetComponent<MeshRenderer>();

        // Obtém o componente TextMeshPro para acessar o texto
        sourceText = GetComponent<TextMeshPro>();

        // Verifica se os componentes foram atribuídos corretamente
        if (textBounds == null)
        {
            Debug.LogWarning("MeshRenderer não encontrado no objeto " + gameObject.name);
        }
        if (sourceText == null)
        {
            Debug.LogWarning("TextMeshPro não encontrado no objeto " + gameObject.name);
        }
    }
    
    /// <summary>
    /// Verifica se o cursor do mouse está sobre o objeto baseado nos limites do MeshRenderer.
    /// </summary>
    /// <returns>Retorna verdadeiro se o cursor estiver dentro dos limites do objeto.</returns>
    private bool IsMouseOver()
    {
        if (textBounds == null) return false; // Evita erro se o MeshRenderer não estiver presente
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return textBounds.bounds.Contains(mousePos);
    }

    void Update()
    {
        if (IsMouseOver() && Input.GetMouseButtonDown(0))
        {
            if (targetText != null && sourceText != null)
            {
                targetText.text = sourceText.text;
            }
        } 
    }
}
