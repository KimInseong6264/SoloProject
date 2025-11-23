using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void Load(int SceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneNumber);
    }
}
