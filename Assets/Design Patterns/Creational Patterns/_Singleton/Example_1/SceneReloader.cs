using UnityEngine;
using UnityEngine.SceneManagement;

namespace DesignPatterns.Singleton
{
    public class SceneReloader : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
