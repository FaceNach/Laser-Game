using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int Health = 50;
	[SerializeField] ParticleSystem HitEffect;

	[SerializeField] bool ApplyCameraShake;
	CameraShake CameraShake;

    private void Awake()
    {
        CameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		DamageDealer DamageDealer = collision.GetComponent<DamageDealer>();

		if(DamageDealer != null)
		{
			TakeDamage(DamageDealer.GetDamage());
			PlayHitEffect();
			ShakeCamera();
			DamageDealer.Hit();
		}
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;

		if(Health <= 0)
		{
			Destroy(gameObject);
		}
	}

	void PlayHitEffect()
	{
		if(HitEffect != null)
		{
			ParticleSystem instance = Instantiate(HitEffect, transform.position, Quaternion.identity);
			Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
		}
	}

	void ShakeCamera()
	{
		if(CameraShake != null && ApplyCameraShake)
		{
			CameraShake.Play();
		}
	}
}
