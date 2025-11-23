using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField] public InputManager Input {  get; private set; }
    [field: SerializeField] public SceneManager Scene { get; private set; }
    [field: SerializeField] public SoundManager Sound { get; private set; }


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