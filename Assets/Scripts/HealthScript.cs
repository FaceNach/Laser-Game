using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int Health = 50;
	DamageDealer DamageDealer;

	void OnTriggerEnter2D(Collider2D collision)
	{
		DamageDealer DamageDealer = collision.GetComponent<DamageDealer>();

		if(DamageDealer != null)
		{
			TakeDamage(DamageDealer.GetDamage());
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
}
