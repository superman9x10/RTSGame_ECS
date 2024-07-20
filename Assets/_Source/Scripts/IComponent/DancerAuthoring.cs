using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class DancerAuthoring : MonoBehaviour
{
    public float speed = 1f;
    public class Baker : Baker<DancerAuthoring>
    {
        public override void Bake(DancerAuthoring authoring)
        {
            Dancer data = new Dancer { speed = authoring.speed };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}
public struct Dancer : IComponentData
{
    public float speed;

    public static Dancer Random(uint seed)
     => new Dancer() { speed = new Random(seed).NextFloat(1, 8) };
}
