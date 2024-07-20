using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct WalkerSystem : ISystem
{
    //[BurstCompile]
    //public void OnUpdate(ref SystemState state)
    //{
    //    var dt = SystemAPI.Time.DeltaTime;

    //    foreach(var (walker, xform) in SystemAPI.Query<RefRO<Walker>, RefRW<LocalTransform>>())
    //    {
    //        var rot = quaternion.RotateY(walker.ValueRO.AngularSpeed * dt);
    //        var fwd = math.mul(rot, xform.ValueRO.Forward());

    //        xform.ValueRW.Position += fwd * walker.ValueRO.ForwardSpeed * dt;
    //        xform.ValueRW.Rotation = quaternion.LookRotation(fwd, xform.ValueRO.Up());
    //    }
    //}
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var job = new WalkerSystemJob
        {
            dt = SystemAPI.Time.DeltaTime
        };

        job.ScheduleParallel();
    }
}

[BurstCompile]
partial struct WalkerSystemJob : IJobEntity
{
    public float dt;

    void Execute(in Walker walker, ref LocalTransform xform)
    {
        var rot = quaternion.RotateY(walker.AngularSpeed * dt);
        var fwd = math.mul(rot, xform.Forward());

        xform.Position += fwd * walker.ForwardSpeed * dt;
        xform.Rotation = quaternion.LookRotation(fwd, xform.Up());
    }
}
