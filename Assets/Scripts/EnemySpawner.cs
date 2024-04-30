using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] List<WaveConfigSO> WaveConfigs;
	[SerializeField] float TimeBetweenWaves = 0.0f;
    WaveConfigSO CurrentWave;
	[SerializeField] bool IsLooping;


	void Start()
	{
		StartCoroutine(SpawnEnemiesWaves());
	}

	public WaveConfigSO GetCurrentWave()
	{
		return CurrentWave;
	}

	IEnumerator SpawnEnemiesWaves()
	{
		do
		{
			foreach (WaveConfigSO wave in WaveConfigs)
			{
				CurrentWave = wave;
				for (int j = 0; j < CurrentWave.GetEnemyCount(); j++)
				{
					Instantiate(CurrentWave.GetEnemyPrefab(j), CurrentWave.GetStartingWavePoint().position,
								Quaternion.Euler(0,0, 180), transform);
					yield return new WaitForSeconds(CurrentWave.GetRandomSpawnTime());
				}
				yield return new WaitForSeconds(TimeBetweenWaves);
			}
		} while (IsLooping);
		
	}
}
