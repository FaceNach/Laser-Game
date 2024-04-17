using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
	[SerializeField] Transform PathPrefab;
	[SerializeField] float MovementSpeed = 5.0f;
	[SerializeField] List<GameObject> EnemyPrefabs;
	[SerializeField] float TimeBetweenEnemySpawns = 1.0f;
	[SerializeField] float SpawnTimeVariance;
	[SerializeField] float MinimunSpawnTime = 0.2f;

	public Transform GetStartingWavePoint()
	{
		return PathPrefab.GetChild(0);
	}

	public List<Transform> GetWavePoints()
	{
		List<Transform> WayPoints = new List<Transform>();
		foreach (Transform child in PathPrefab)
		{
			WayPoints.Add(child);
		}

		return WayPoints;
	}
	public float GetMovementSpeed()
	{
		return MovementSpeed;
	}

	public int GetEnemyCount()
	{
		return EnemyPrefabs.Count;
	}

	public GameObject GetEnemyPrefab(int index)
	{
		return EnemyPrefabs[index];
	}

	public float GetRandomSpawnTime()
	{
		float SpawnTime = Random.Range(TimeBetweenEnemySpawns - SpawnTimeVariance,
									   TimeBetweenEnemySpawns + SpawnTimeVariance);

		return Mathf.Clamp(SpawnTime, MinimunSpawnTime, float.MaxValue);
	}
}

	
