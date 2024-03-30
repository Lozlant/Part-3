using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : Entity
{
    public Type type;
    protected override void Start()
    {
        base.Start();
        GameController.setTowerPosition(type, rb.position);
        Debug.Log("Set the" + type +"Tower's position:" + rb.position);
    }
}
