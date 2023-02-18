using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsButton : MonoBehaviour
{
   public void GoToStats(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
