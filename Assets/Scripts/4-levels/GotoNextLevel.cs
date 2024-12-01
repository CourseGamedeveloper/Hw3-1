using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    [SerializeField] private string triggeringTag;
    [SerializeField][Tooltip("Name of scene to move to when triggering the given tag")] private string sceneName;

    private Health health;

    private void Start()
    {
        // Dynamically find the Health component
        health = FindAnyObjectByType<Health>();

        // Check if health was assigned
        if (health == null)
        {
            Debug.LogError("Health component not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            other.transform.position = Vector3.zero;
            GameOver();

        }

    }
    private void GameOver()
    {
        if (health != null && health.current_PlayerHealth <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

   
}
