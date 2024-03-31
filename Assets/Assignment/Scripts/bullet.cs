using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed=1f;
    Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    public void SetDirection(Entity target,Vector3 movement)
    {
        direction = movement.normalized;
        StartCoroutine(Damage(target,movement.magnitude / speed));
    }
    IEnumerator Damage(Entity target, float time)
    {
        yield return new WaitForSeconds(time-0.1f);
        target.TakeDamage(1);
        Destroy(gameObject);
    }
}
