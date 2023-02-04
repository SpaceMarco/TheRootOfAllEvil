using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField]float duration;
    [SerializeField]AnimationCurve strength_curve;
    [SerializeField] float shake_speed;

    public void shake_camera()
    {
        StartCoroutine(shake());
    }

    IEnumerator shake()
    {
        Vector3 start = transform.position;
        float time_passed = 0f;
        while(time_passed< duration)
        {
            time_passed += Time.deltaTime;
            float strength = strength_curve.Evaluate(time_passed/duration);
            transform.position = start + Random.insideUnitSphere* shake_speed * strength;
            yield return null;
        }

        transform.position = start;
        
    }
}
