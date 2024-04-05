using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMotion : ProjectileMotionBase
{
    // TODO

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }

    public new void SetInfo(int dataTemplateID, Vector3 startPosition, Vector3 targetPosition, Action endCallback)
    {
        base.SetInfo(dataTemplateID, startPosition, targetPosition, endCallback);
    }

    protected override IEnumerator CoLaunchProjectile()
	{
        float journeyLength = Vector3.Distance(StartPosition, TargetPosition);
        float totalTime = journeyLength / ProjectileData.ProjSpeed;
        float elapsedTime = 0;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;

            float normalizedTime = elapsedTime / totalTime;
            transform.position = Vector3.Lerp(StartPosition, TargetPosition, normalizedTime);

            if (LookAtTarget)
                LookAt2D(TargetPosition - transform.position);

            yield return null;
        }

        transform.position = TargetPosition;
        EndCallback?.Invoke();
    }
}
