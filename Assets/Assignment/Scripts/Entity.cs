using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Type { enemy, player}
public class Entity : MonoBehaviour
{
    public Slider slider;

    float health;
    public float maxhealth=10;
    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;
    public float shootingInterval = 1f;
    public AnimationCurve dyingCurve;

    protected Rigidbody2D rb;
    Coroutine dying;
    public bool isDying = false;
    Coroutine attacking;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = slider.maxValue = maxhealth;
        slider.value = health;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        slider.value = health;
        if (health <= 0 && dying==null)
        {
            dying = StartCoroutine(Dead());
        }
    }
    protected virtual IEnumerator Dead()
    {
        yield return null;
        isDying = true;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attacking == null && !collision.CompareTag("Bullet") && !collision.CompareTag("GameController"))
        {
            Vector3 movement = collision.gameObject.transform.position - BulletSpawnPoint.position;
            attacking = StartCoroutine(Attack(collision.gameObject, movement));
        }
    }
    protected virtual IEnumerator Attack(GameObject target, Vector3 movement)
    {
        if (target.TryGetComponent<Entity>(out Entity entity))
        {
            while (!entity.isDying)
            {
                GameObject bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
                bullet.GetComponent<bullet>().SetDirection(entity, movement);
                yield return new WaitForSeconds(shootingInterval);
            }
        }
        attacking = null;
    }
}
