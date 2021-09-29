using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeamProperty : ScriptableObject
{
    public abstract void ExecuteBeamEffect(Vector3 location);
}
