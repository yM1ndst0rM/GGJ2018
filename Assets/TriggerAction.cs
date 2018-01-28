using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour
{
    public UnityEvent OnTriggered;

    public void TriggerEvent()
    {
        OnTriggered.Invoke();
    }
}
