using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodfightGame : MonoBehaviour
{
	[SerializeField] private Target targetPrefab;
	[SerializeField] private BoxCollider spawnArea;

	// Session 10 
	[SerializeField] private float gameDuration;
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private TMP_Text remainingTime;
	private bool IsGameOver => gameDuration <= 0;
	private int currentScore;

	private void Start()
	{
		// Spawn the first target
		SpawnTarget();

		// Session 10 
		SetRemainingTime(gameDuration);
	}

	public void OnTargetHit()
	{
		// Spawn a target
		SpawnTarget();
	}

	private void SpawnTarget()
	{
		// Spawn a new target
		var newTarget = Instantiate(targetPrefab, GetRandomTargetPosition(), targetPrefab.transform.rotation);

		// Let the new target know about this game object so it can communicate
		newTarget.game = this;
	}

	private Vector3 GetRandomTargetPosition()
	{
		// Return a random position inside the spawn area
		return new Vector3(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
			Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
			Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z));
	}

    // Session 10
    private void Update()
    {
		SetRemainingTime(gameDuration - Time.deltaTime);
    }
    public void SetRemainingTime(float value)
    {
		gameDuration = value;
        if (IsGameOver)
        {
			gameDuration = 0;
			enabled = false;

        }

		remainingTime.text = "Remaining Time: " + gameDuration.ToString("0.0");
    }

	public void AddScore(int value)
    {
		currentScore = value;
		scoreText.text = "Score: " + currentScore;
    }

	public void OnTargetHit(Target target)
	{
		// Spawn a target
		SpawnTarget();

		// add score
		AddScore(target.points);
	}
}
