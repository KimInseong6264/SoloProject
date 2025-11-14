

public abstract class Skill
{
    private string _skillName;
    private int _coinCount;         //스킬의 코인 갯수
    private int _coinValue;         //스킬의 코인값(합의 위력과 데미지를 결정)

    public Skill(string name, int coinCount, int coinValue)
    {
        _skillName = name;
        _coinCount = coinCount;
        _coinValue = coinValue;
    }
}
