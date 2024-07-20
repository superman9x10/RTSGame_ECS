using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct DancerSystem : ISystem
{
    //[BurstCompile]
    //public void OnUpdate(ref SystemState state)
    //{
    //    float elapsed = (float) SystemAPI.Time.ElapsedTime;

    //    foreach(var (dancer, xForm) in SystemAPI.Query<RefRO<Dancer>, RefRW<LocalTransform>>())
    //    {
    //        var t = dancer.ValueRO.speed * elapsed;
    //        var y = math.abs(math.sin(t)) * 0.1f;
    //        var bank = math.cos(t) * 0.5f;

    //        var fwd = xForm.ValueRO.Forward();
    //        var rot = quaternion.AxisAngle(fwd, bank);
    //        var up = math.mul(rot, math.float3(0, 1, 0));

    //        xForm.ValueRW.Position.y = y;
    //        xForm.ValueRW.Rotation = quaternion.LookRotation(fwd, up);
    //    }
    //}

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var job = new DancerUpdateJob()
        {
            elapsed = (float)SystemAPI.Time.ElapsedTime
        };

        job.ScheduleParallel();
    }
}

[BurstCompile]
partial struct DancerUpdateJob : IJobEntity
{
    public float elapsed;

    void Execute(in Dancer dancer, ref LocalTransform xform)
    {
        var t = dancer.speed * elapsed;
        var y = math.abs(math.sin(t)) * 0.1f;
        var bank = math.cos(t) * 0.5f;

        var fwd = xform.Forward();
        var rot = quaternion.AxisAngle(fwd, bank);
        var up = math.mul(rot, math.float3(0, 1, 0));

        xform.Position.y = y;
        xform.Rotation = quaternion.LookRotation(fwd, up);
    }
}


