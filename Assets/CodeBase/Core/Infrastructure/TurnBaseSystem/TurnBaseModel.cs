using System;
using System.Linq;

[Serializable]
public class TurnBaseModel
{
    public int TurnNumder;
    public Phase CurrentPhase;

    public TurnBaseModel(int turnNumder, Phase currentPhase)
    {
        TurnNumder = turnNumder;
        CurrentPhase = currentPhase;
    }
}