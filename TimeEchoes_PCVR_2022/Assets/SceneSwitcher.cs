using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // The tag of the player object
    private string playerTag = "Player";

    // The scene that you want to switch to
    private string nextScene = "House_Inside_3"; // replace "YourNextSceneName" with the actual name of the scene

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag(playerTag))
        {
            // If it does, load the next scene
            SceneManager.LoadScene(nextScene);
        }
    }
}
