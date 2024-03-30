using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { enemy, player}
public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
