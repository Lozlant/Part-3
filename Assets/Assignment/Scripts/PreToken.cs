using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreToken : MonoBehaviour
{
    public GameObject Tokenprefab;
    void Update()
    {
        transform.position =Input.mousePosition;
        if(Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
        {
            GameController.setSpawnToken(Tokenprefab);
            Destroy(gameObject);
        }
    }
}
