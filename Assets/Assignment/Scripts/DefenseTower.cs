using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefenseTower : Entity
{
    public Type type;
    SpriteRenderer sr;
    protected override void Start()
    {
        base.Start();
        GameController.setTowerPosition(type, rb.position);
        Debug.Log("Set the" + type +"Tower's position:" + rb.position);
        sr=GetComponent<SpriteRenderer>();
    }

    protected override IEnumerator Dead()
    {
        isDying = true;
        if (attacking != null) StopCoroutine(attacking);
        float timer = 0;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            float interpolation = dyingCurve.Evaluate(timer);
            sr.color = Color.Lerp(Color.white, Color.black, interpolation);
            yield return null;
        }
        GameController.setWinner(1 - type);
        SceneManager.LoadScene("End");
    }
}
