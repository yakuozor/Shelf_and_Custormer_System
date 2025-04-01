using UnityEngine;

public class ProductBox : MonoBehaviour
{
    public string color;
    public CustomerManager customerManager;

    void OnMouseDown()
    {
        customerManager.TryDeliver(color);
    }
}
