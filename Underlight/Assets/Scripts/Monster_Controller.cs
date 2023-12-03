using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float followSpeed = 2.0f;
    public float safeDistance = 2.0f;

    // Variables for AI progression
    private int itemsCollectedByPlayer = 0;
    private bool usePathfinding = false;
    private bool useHiddenPaths = false;

    void Update()
    {
        // Update AI behavior based on items collected
        UpdateAIBehavior();

        // Calculate the distance between monster and player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > safeDistance)
        {
            if (usePathfinding)
            {
                // Use pathfinding to move towards the player
                MoveUsingPathfinding();
            }
            else
            {
                // Directly move towards the player
                Vector3 moveDirection = (player.transform.position - transform.position).normalized;
                transform.position += moveDirection * followSpeed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("collision");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateAIBehavior()
    {
        // Adjust AI behavior based on items collected
        // Placeholder for item collection check
        itemsCollectedByPlayer = 0/* Get collected items count */;

        // Increase speed based on collected items
        followSpeed = 2.0f + itemsCollectedByPlayer * 0.1f;

        // Enable pathfinding after a certain number of items collected
        if (itemsCollectedByPlayer > 10)
        {
            usePathfinding = true;
        }

        // Enable use of hidden paths at later stages
        if (itemsCollectedByPlayer > 20)
        {
            useHiddenPaths = true;
        }
    }

    private void MoveUsingPathfinding()
    {
        // Implement pathfinding logic here
    }

    private void UseHiddenPaths()
    {
        // Implement logic for using hidden pathways
    }
}
