using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Token : Entity
{
    public Type type;
    public float speed=5f;


    Vector3 destination;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Vector3 mousePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (type == Type.player) transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        else
        {
            Vector3 spawnPosition=Camera.main.ViewportToWorldPoint(new Vector3(1, Random.Range(0.25f, 0.83f), 0));
            transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0);
        }
        destination = GameController.towerposition[1 - (int)type];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 movement=destination-transform.position;
        if (movement.magnitude < 1.5f) speed = 0;
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
}
