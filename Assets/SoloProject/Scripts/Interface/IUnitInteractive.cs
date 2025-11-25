using System;
using System.Collections.Generic;
using UnityEngine;

// 런타임 중 변화되는 값으로 사용
public interface IUnitInteractive
{
    public Unit UnitModel { get; }
}
