using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // ΩÃ±€≈Ê ∆–≈œ
    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<GameManager>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}