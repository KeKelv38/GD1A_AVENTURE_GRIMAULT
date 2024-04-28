using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.DefaultInputActions;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public float Movespeed = 10f;


    [SerializeField] Transform checkEnemy;

    public static BasicMovement basicMovement;

    private PlayerInputActions _inputActions;

    private void Awake()
    {
        if (basicMovement != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de BasicMovement dans la scène");
            return;
        }

        basicMovement = this;

        Movespeed = 3f;
    }

    private void OnEnable()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Gameplay.Enable();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * Movespeed;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime;

        if (animator.GetFloat("Horizontal") > 0.01)
        {
            animator.SetFloat("lastMoveX", 1);
            animator.SetFloat("lastMoveY", 0);
        }

        if (animator.GetFloat("Vertical") > 0.01)
        {
            animator.SetFloat("lastMoveY", 1);
            animator.SetFloat("lastMoveX", 0);

        }

        if (animator.GetFloat("Horizontal") < -0.01)
        {
            animator.SetFloat("lastMoveX", -1);
            animator.SetFloat("lastMoveY", 0);
        }

        if (animator.GetFloat("Vertical") < -0.01)
        {
            animator.SetFloat("lastMoveY", -1);
            animator.SetFloat("lastMoveX", 0);
        }
    }
}
