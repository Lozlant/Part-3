using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform[] modules=new Transform[20];
    float interpolation;
    float timer=0;
    public AnimationCurve building;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < modules.Length; i++) modules[i].localScale = Vector3.zero;
        StartCoroutine(Build());
    }
    private void Update()
    {
        timer += 2f*Time.deltaTime;
    }
    IEnumerator Build()
    {
        for(int i = 0; i < modules.Length; i++) {
            Transform module = modules[i];
            while (module.localScale.x < 1) {
                interpolation = building.Evaluate(timer);
                module.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolation);
                yield return null;
            }
            timer = 0;
        }
    }
}
