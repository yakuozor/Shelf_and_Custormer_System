using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform spawnPoint;
    public TMP_Text requestText;

    public string[] possibleColors = { "Kýrmýzý", "Yeþil", "Mavi" };
    private string requestedColor;
    private GameObject currentCustomer;
    private IEnumerator ClearRequestTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        requestText.text = "";
    }

    public void CallCustomer()
    {
        if (currentCustomer != null) return;

        requestedColor = possibleColors[Random.Range(0, possibleColors.Length)];
        requestText.text = requestedColor + " istiyorum!";
        currentCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.Euler(0, -90, 0));
    }

    public void TryDeliver(string color)
    {
        if (currentCustomer == null) return;

        if (color == requestedColor)
        {
            Destroy(currentCustomer);
            currentCustomer = null;

            requestText.text = "Teþekkürler!";
            StartCoroutine(ClearRequestTextAfterDelay(2f));
        }
        else
        {
            requestText.text = "Bu doðru deðil!";
            StartCoroutine(ClearRequestTextAfterDelay(1.5f));
        }
    }

}
