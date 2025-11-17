using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // ΩÃ±€≈Ê ∆–≈œ
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<GameManager>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}