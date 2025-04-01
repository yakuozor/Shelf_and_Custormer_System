using UnityEngine;
using TMPro;

public class InteractionHintManager : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform playerCamera;
    public TMP_Text interactionText;

    void Update()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            GameObject obj = hit.collider.gameObject;

            if (obj.CompareTag("CustomerTrigger"))
            {
                interactionText.text = "M��teri �a��rmak i�in E'ye bas�n�z";
                interactionText.gameObject.SetActive(true);
            }
            else if (obj.CompareTag("Shelf"))
            {
                interactionText.text = "�r�n eklemek i�in E, ��karmak i�in T'ye bas�n�z";
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
