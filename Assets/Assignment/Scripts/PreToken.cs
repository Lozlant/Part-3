using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreToken : MonoBehaviour
{
    public GameObject Tokenprefab;
    void Update()
    {
        transform.position =Input.mousePosition;
        if(Input.GetMouseButtonDown(0) && Camera.main.ScreenToViewportPoint(Input.mousePosition).x<=0.5)
        {
            GameController.setSpawnToken(Tokenprefab);
            Destroy(gameObject);
        }
    }
}
