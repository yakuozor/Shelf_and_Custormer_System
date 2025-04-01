using UnityEngine;

public class CustomerTrigger : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform playerCamera;
    public CustomerManager customerManager;

    void Update()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    customerManager.CallCustomer();
                }
            }
        }
    }
}
