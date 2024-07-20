using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class WalkerAuthoring : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float angularSpeed = 1f;
    public class Baker : Baker<WalkerAuthoring>
    {
        public override void Bake(WalkerAuthoring authoring)
        {
            Walker data = new Walker 
            {
                ForwardSpeed = authoring.forwardSpeed,
                AngularSpeed = authoring.angularSpeed
            };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}
public struct Walker : IComponentData
{
    public float ForwardSpeed;
    public float AngularSpeed;

    public static Walker Random(uint seed)
    {
        var random = new Random(seed);
        return new Walker()
        {
            ForwardSpeed = random.NextFloat(0.1f, 0.8f),
            AngularSpeed = random.NextFloat(0.5f, 4)
        };
    }
}
