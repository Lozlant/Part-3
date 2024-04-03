using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Token : Entity
{
    public Type type;
    public float speed=5f;

    float currentspeed;
    Vector3 destination;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentspeed = speed;
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
        //if (movement.magnitude < 1.5f) currentspeed = 0;
        rb.MovePosition(rb.position + movement.normalized * currentspeed * Time.deltaTime);
    }

    protected override IEnumerator Attack(GameObject target,Vector3 movement)
    {
        currentspeed = 0;
        yield return base.Attack(target,movement);
        currentspeed=speed;
        attacking = null;
    }

    protected override IEnumerator Dead()
    {
        isDying = true;
        if (attacking != null) StopCoroutine(attacking);
        currentspeed = 0;
        float timer = 0;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            float interpolation = dyingCurve.Evaluate(timer);
            transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0f, 0f, 90f), interpolation);
            yield return null;
        }
        if (type == Type.enemy) GameController.setMoney(GameController.money + 100);
        Destroy(gameObject);
    }
}
