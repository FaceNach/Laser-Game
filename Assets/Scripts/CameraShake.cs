using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float ShakeDuration = 1f;
    [SerializeField] float ShakeMagnitud = 0.5f;

    Vector3 InitialPosition;

    void Start()
    {
        InitialPosition = transform.position; 
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float ElapsedTime = 0;
        while(ElapsedTime < ShakeDuration)
        {
            transform.position = InitialPosition + (Vector3)Random.insideUnitCircle * ShakeMagnitud;
            ElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = InitialPosition;
    }
}
