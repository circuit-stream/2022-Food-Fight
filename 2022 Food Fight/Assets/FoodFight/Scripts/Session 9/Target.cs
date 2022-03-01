using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveAmount;

    private float startingXPosition;
    public FoodfightGame game;

    // Session 10
    public int points;

    private void Awake()
    {
        startingXPosition = transform.position.x;
    }

    void Update()
    {
        // Move the target back and forth
        var newPosition = transform.position;
        newPosition.x = startingXPosition + Mathf.Sin(Time.time * moveSpeed) * moveAmount;
        transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        // If the target was hit by a foodstuff
        var foodstuff = other.gameObject.GetComponent<XRGrabInteractable>();
        if (foodstuff != null)
        {
            Debug.Log("hit");

            // respawn food
            var respawnableObject = other.gameObject.GetComponent<RespawnableObject>();
            if(respawnableObject != null)
            {
                respawnableObject.Respawn();
            }

            // Destroy the foodstuff and the target
            Destroy(foodstuff.gameObject);
            Destroy(gameObject);

            // Let the game know a target was hit
            game.OnTargetHit();

            // Session 10
            game.OnTargetHit(this);
        }
    }
}
