using UnityEngine;
using UnityEngine.SceneManagement;

public class Glass : MonoBehaviour
{
    public int targetWater = 15;
    private int currentWater = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            currentWater++;
            Destroy(collision.gameObject);

            if (currentWater >= targetWater)
            {
                Win();
            }
        }
    }

    void Win()
    {
        Debug.Log("YOU WIN!");
        Invoke(nameof(NextLevel), 1.5f);
    }

    void NextLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
