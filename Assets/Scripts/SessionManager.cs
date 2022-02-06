using System;
using UnityEngine;

public enum Phase
{
    Phase1,
    Phase2,
    Phase3
}

public class SessionManager : MonoBehaviour
{
    public static SessionManager I;

    public Phase Phase;

    public static event Action<Phase> OnPhaseChanged;

    private void Awake() 
    {
        I = this;    
    }

    public void SetPhase(Phase newPhase)
    {
        Phase = newPhase;

        switch (newPhase)
        {
            case Phase.Phase1:
                HandlePhase();
                break;
            case Phase.Phase2:
                HandlePhase();
                break;
            case Phase.Phase3:
                HandlePhase();
                break;
            default:
                Debug.Log("No game state provided.");
                break;
        }

        OnPhaseChanged?.Invoke(newPhase);
    }

    private void HandlePhase()
    {

    }
}
