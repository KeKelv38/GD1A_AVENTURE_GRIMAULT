using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeSpeed = 0.5f; // Vitesse de fondu, plus la valeur est petite, plus le fondu est lent
    private Renderer objectRenderer;
    private Color currentColor;
    private bool isFading = false;


    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        currentColor = objectRenderer.material.color;
    }

    void Update()
    {
        if (isFading)
        {
            // Réduire progressivement l'opacité de l'objet
            currentColor.a -= fadeSpeed * Time.deltaTime;
            objectRenderer.material.color = currentColor;

            // Si l'opacité atteint 0, désactiver l'objet
            if (currentColor.a <= 0f)
            {
                gameObject.SetActive(false);
                // Alternativement, vous pouvez détruire l'objet avec "Destroy(gameObject);" à la place de "gameObject.SetActive(false);"
                isFading = false;
            }
        }
    }

    public void StartFadeOut()
    {
        isFading = true;
    }
}