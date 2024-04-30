using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
	[Header("General")]
    [SerializeField] GameObject Projectile;
    [SerializeField] float ProjectileSpeed = 10.0f;
    [SerializeField] float ProjectileLife = 10.0f;
	[SerializeField] float BaseFiringRate = 0.2f;

	[Header("IA")]
	[SerializeField] float FiringRateVariance = 0f;
	[SerializeField] float MinimumFiringRate = 0.1f;
	[SerializeField] bool useAI;

    [HideInInspector] public bool IsFiring;
	Coroutine FiringCoroutine;

    void Start()
    {
        if(useAI)
		{
			IsFiring = true;
		}
    }

    private void Update()
	{
		Fire();
	}

	void Fire()
	{
		if(IsFiring && FiringCoroutine == null)
		{
			FiringCoroutine = StartCoroutine(FireContinuously());
		}
		else if(!IsFiring && FiringCoroutine != null)
		{
			StopCoroutine(FiringCoroutine);
			FiringCoroutine = null;
		}
	}

	IEnumerator FireContinuously()
	{
		while(true)
		{
			GameObject Instance = Instantiate(Projectile, transform.position, Quaternion.identity);

			Rigidbody2D RB = Instance.GetComponent<Rigidbody2D>();
			
			if(RB != null)
			{
				RB.velocity = transform.up * ProjectileSpeed;
			}

			Destroy(Instance, ProjectileLife);

			float TimeToNextProyectile = Random.Range(BaseFiringRate - FiringRateVariance, BaseFiringRate + FiringRateVariance);

			TimeToNextProyectile = Mathf.Clamp(TimeToNextProyectile, MinimumFiringRate, float.MaxValue);

			if (useAI)
			{
                yield return new WaitForSeconds(TimeToNextProyectile);
            }
			else
			{
				yield return new WaitForSeconds(BaseFiringRate);
            }
		}
	}
}
