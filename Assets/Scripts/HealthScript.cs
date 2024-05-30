using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
	[SerializeField] private bool isPlayer;
	[SerializeField] private int Health = 50;
	[SerializeField] int Score = 50;
	[SerializeField] ParticleSystem HitEffect;
	
	

	[SerializeField] bool ApplyCameraShake;
	CameraShake CameraShake;
	
	private AudioPlayer OnDamageTakenSound;
	private ScoreKeeper ScoreKeeper;

    private void Awake()
    {
        CameraShake = Camera.main.GetComponent<CameraShake>();
        OnDamageTakenSound = FindObjectOfType<AudioPlayer>();
        ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		DamageDealer DamageDealer = collision.GetComponent<DamageDealer>();

		if(DamageDealer != null)
		{
			TakeDamage(DamageDealer.GetDamage());
			PlayHitEffect();
			OnDamageTakenSound.PlayClipOnDamageTaken();
			ShakeCamera();
			DamageDealer.Hit();
		}
	}

	public int GetHealth()
	{
		return Health;
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;

		if(Health <= 0)
		{
			Die();
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

	private void Die()
	{
		if (!isPlayer)
		{
			ScoreKeeper.ModifyScore(Score);
		}
		Destroy(gameObject);
	}
}
