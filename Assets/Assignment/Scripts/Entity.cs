using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
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
    protected Coroutine attacking;

    List<GameObject> targets= new List<GameObject>();

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
        if(!collision.CompareTag("Bullet") && !collision.CompareTag("GameController"))
        {
            //Debug.Log(gameObject.name+" add " + collision.gameObject);
            targets.Add(collision.gameObject);
            if (attacking == null)
            {
                Vector3 movement = targets[0].transform.position - BulletSpawnPoint.position;
                attacking = StartCoroutine(Attack(targets[0], movement));
            }
        }
    }
    protected virtual IEnumerator Attack(GameObject target, Vector3 movement)
    {
        if (target.TryGetComponent<Entity>(out Entity entity))
        {
            while (entity != null && !entity.isDying)
            {
                GameObject bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
                bullet.GetComponent<bullet>().SetDirection(entity, movement);
                yield return new WaitForSeconds(shootingInterval);
            }
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i]==null || targets[i].GetComponent<Entity>().isDying)
                {
                    targets.Remove(target);
                    i--;
                }
            }
            if (targets.Count>0)
            {
                movement = targets[0].transform.position - BulletSpawnPoint.position;
               StartCoroutine(Attack(targets[0], movement));
            }
        }
        attacking = null;
    }

}
