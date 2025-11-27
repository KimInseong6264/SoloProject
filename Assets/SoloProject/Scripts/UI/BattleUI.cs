using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private List<Button> _playerButton;
    [SerializeField] private List<Text> _skillSlotText;
    public Button StartButton;

    private Stack<Skill> _skillUI;
    private List<Skill> _ShuffleList;
    private Skill _skillSlot1;
    private Skill _skillSlot2;

    private void Awake()
    {
        _skillUI = new Stack<Skill>();
        _ShuffleList = new List<Skill>();
    }

    private void OnEnable()
    {
        _playerButton[0].onClick.AddListener(() => SetBattleSkill(0));
        _playerButton[1].onClick.AddListener(() => SetBattleSkill(1));
        BattleManager.Instance.Damage.OnEndDamageStep += SetSkillSlot;

        BattleManager.Instance.OnSeleted += SetSkillSlot;
    }

    public void SetSkillSlot()
    // 스폰 시작 시에 연결해야 함
    {
        _skillSlot1 = GetSkill();
        _skillSlotText[0].text = _skillSlot1.SkillName;
        _skillSlot2 = GetSkill();
        _skillSlotText[1].text = _skillSlot2.SkillName;
    }

    public void SetBattleSkill(int i)
    {
        if (i == 0)
            BattleManager.Instance.SetBattle(UnitType.Player, _skillSlot1);

        if (i == 1)
        {
            Skill temp = GetSkill();
            BattleManager.Instance.SetBattle(UnitType.Player, _skillSlot2);
            _skillUI.Push(temp);
        }
    }


    public Skill GetSkill()
    {
        Skill output;
        switch (_skillUI.Count)
        {
            case 0:
                Shuffle(0);
                foreach(var skill in _ShuffleList)
                    _skillUI.Push(skill);
                output = _skillUI.Pop();
                break;

            case 2:
                Shuffle(0);
                output = _skillUI.Pop();
                Skill temp = _skillUI.Pop();
                foreach (var skill in _ShuffleList)
                    _skillUI.Push(skill);
                temp = _skillUI.Pop();
                break;

            default:
                output = _skillUI.Pop();
                break;
        }
        return output;
    }


    private void Shuffle(int playerIndex)
    {
        Unit player = BattleManager.Instance.SelectedPlayer[playerIndex];
        for (int i = 0; i < 6; i++)
        {
            _ShuffleList.Add(player.SkillList[i / 4]);
        }

        for (int i = _ShuffleList.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            Skill temp = _ShuffleList[i];
            _ShuffleList[i] = _ShuffleList[j];
            _ShuffleList[j] = temp;
        }
    }

    

}
