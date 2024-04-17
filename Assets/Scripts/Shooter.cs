using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Projectile;
    [SerializeField] float ProjectileSpeed = 10.0f;
    [SerializeField] float ProjectileLife = 10.0f;
	[SerializeField] float FiringRate = 0.2f;

    public bool IsFiring;
	Coroutine FiringCoroutine;
	

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

			yield return new WaitForSeconds(FiringRate);
		}
	}
}
