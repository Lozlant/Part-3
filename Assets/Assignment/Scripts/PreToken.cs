using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreToken : MonoBehaviour
{
    public GameObject Tokenprefab;
    public int price=100;
    void Update()
    {
        transform.position =Input.mousePosition;
        if(Input.GetMouseButtonDown(0) && Camera.main.ScreenToViewportPoint(Input.mousePosition).x<=0.5)
        {
            if (price <= GameController.money)
            {
                GameController.setSpawnToken(Tokenprefab);
                GameController.setMoney(GameController.money - price);
            }
            Destroy(gameObject);
        }
    }
}
