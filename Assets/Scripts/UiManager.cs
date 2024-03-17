using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject Player;
    public Image popupImage;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set the z-coordinate first

        Player.transform.position = mousePosition; // Assign the position to the player

        // Get the bounds of the player's collider
        Bounds playerBounds = Player.GetComponent<BoxCollider2D>().bounds;

        // Calculate the size of the overlap box based on the collider's bounds
        Vector2 overlapBoxSize = new Vector2(playerBounds.size.x, playerBounds.size.y);

        Collider2D[] colliders = Physics2D.OverlapBoxAll(Player.transform.position, overlapBoxSize, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Border"))
            {
                SceneManager.LoadScene(0);
                return;
            }
            else if (collider.CompareTag("End"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
        }

        
    }
}