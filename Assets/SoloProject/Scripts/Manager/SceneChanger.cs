using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Load(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
