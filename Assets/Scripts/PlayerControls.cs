using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 1f;
    public float gravity = -10f;
    public float mouseSensitivity = 2f;
    public Transform playerCamera;

    public float interactDistance = 10f;
    public LayerMask shelfLayerMask;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float verticalRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        Move();
        Jump();
        ApplyGravity();
        Look();
        CheckShelfInteraction();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void CheckShelfInteraction()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;
        
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        if (Physics.Raycast(ray, out hit, interactDistance, shelfLayerMask))
        {
            ShelfRow shelf = hit.collider.GetComponent<ShelfRow>();
            
            if (shelf != null)
            {
                Debug.Log("Rafa bakýlýyor, etkileþim yapýlabilir.");
                if (Input.GetKeyDown(KeyCode.E))
                    shelf.AddItem();
                else if (Input.GetKeyDown(KeyCode.T))
                    shelf.RemoveItem();
            }
        }
    }
}
