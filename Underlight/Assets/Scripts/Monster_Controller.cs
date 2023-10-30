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

    void Update()
    {
        // Calculate the distance between AngrySpooder and character
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // If the distance is greater than the safe distance, start following
        if (distanceToPlayer > safeDistance)
        {
            // Determine the direction and move AngrySpooder towards the player
            Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            transform.position += moveDirection * followSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        print("collision");
        SceneManager.LoadScene("GameOver");
    }
}
