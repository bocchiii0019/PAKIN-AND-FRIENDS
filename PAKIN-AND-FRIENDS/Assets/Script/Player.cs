using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IInteractable
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    public Inventory inventory;
    // public List<Skill> activeSkills;
    public int senity;
    public int stamina;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 currentMoveInput = context.ReadValue<Vector2>();
        
        animator.SetBool("IsWalking", currentMoveInput.magnitude > 0);

        if (context.canceled)
        {
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = currentMoveInput;
        
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    public void Interact(IInteractable obj){

    }

    public void SaveGame(Vector3 checkpoint)
    {
        
    }
}