using System.Collections.Generic;

public interface IBatte
{
    public List<CoinType> ClashList { get; }

    public void ClashListReset();
}
