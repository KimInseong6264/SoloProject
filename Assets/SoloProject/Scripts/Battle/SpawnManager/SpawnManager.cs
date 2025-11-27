using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [field: SerializeField] public UnitSpawner[] Spawn {  get; private set; }
    [field: SerializeField] public WaveManager Wave { get; private set; }



    private void Awake()
    {
        Instance = GetComponent<SpawnManager>();
    }

    public void UnitSpawn()
    {
        Spawn[0].UpdateSpawn(UnitType.Player);
        Spawn[1].UpdateSpawn(UnitType.Enemy);

    }
}
