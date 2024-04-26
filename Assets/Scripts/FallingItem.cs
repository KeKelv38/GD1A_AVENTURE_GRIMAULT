using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public float bobbingSpeed = 2f; // Vitesse de l'oscillation
    public float bobbingHeight = 0.5f; // Hauteur de l'oscillation

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculer la position verticale oscillante
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;

        // Mettre à jour la position de l'objet
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

}