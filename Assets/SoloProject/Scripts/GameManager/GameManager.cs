using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField] public InputManager Input {  get; private set; }
    [field: SerializeField] public SceneManager Scene { get; private set; }
    [field: SerializeField] public SoundManager Sound { get; private set; }
    [field: SerializeField] public UnitDataBase DataBase { get; private set; }

    public List<UnitDataSO> SelectedPlayer { get; private set; }

    // 싱글톤 패턴
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
        SelectedPlayer = new List<UnitDataSO>();
    }

    public void Start()
    {
        SelectedPlayer.Add(DataBase.GetUnitDat(Player.Faust));
    }

    // 캐릭터 선택 창에서 전투 출전 유닛을 선택,취소하는 메서드
    public void SetSelected(int index) => SelectedPlayer.Add(DataBase.GetUnitDat((Player)index));
    public void RemoveSelected(int index) => SelectedPlayer.Remove(DataBase.GetUnitDat((Player)index));
    public UnitDataSO GetSelected(int index) => SelectedPlayer[index];

}