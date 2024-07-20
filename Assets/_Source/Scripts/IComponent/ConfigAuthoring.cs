using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ConfigAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRadius = 1;
    public int spawnCount = 10;
    public uint randomSeed = 100;

    public class Baker : Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            Config config = new Config
            {
                Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
                SpawnRadius = authoring.spawnRadius,
                SpawnCount = authoring.spawnCount,
                RandomSeed = authoring.randomSeed
            };

            AddComponent(GetEntity(TransformUsageFlags.None), config);
        }
    }
}

public struct Config : IComponentData
{
    public Entity Prefab;
    public float SpawnRadius;
    public int SpawnCount;
    public uint RandomSeed;
}
