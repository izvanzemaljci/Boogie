using System;
using System.Collections.Generic;
using UnityEngine;

public class ReactionManager : MonoBehaviour
{
    [SerializeField]
    private List<Hit> hits;

    public static ReactionManager I;

    public event Action<bool> OnNewHitAdded;

    private void Awake()
    {
        I = this;

        hits.Clear();
    }

    public void AddHit(Hit newHit)
    {
        foreach (Hit hit in hits)
        {
            if (hit.timeStamp != newHit.timeStamp)
            {
                return;
            }

            if (hit.timeStamp == newHit.timeStamp && hit.unitID == newHit.unitID && hit.result == newHit.result)
            {
                return;
            }
        }

        hits.Add(newHit);

        OnNewHitAdded?.Invoke(newHit.result);
    }
}
