using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void PhaseEvent();

public class TurnBaseController : ITurnBaseController
{
    private readonly TurnBaseModel _model;
    private readonly Dictionary<Phase, List<PhaseEvent>> _phaseEvents = new Dictionary<Phase, List<PhaseEvent>>();

    public TurnBaseController()
    {
        _model = new TurnBaseModel(0, Phase.Restor);
    }

    public void RunCycle()
    {
        _model.TurnNumder++;

        foreach (Phase phase in Enum.GetValues(typeof(Phase)))
        {
            _model.CurrentPhase = phase;

            if (!_phaseEvents.TryGetValue(phase, out var phaseEvents))
                continue;

            Debug.Log($"Triggering {phase} phase events...");

            foreach (PhaseEvent phaseEvent in phaseEvents)
                phaseEvent?.Invoke();
        }
    }

    public void Subscribe(Phase phase, PhaseEvent phaseEvent)
    {
        if (!_phaseEvents.ContainsKey(phase))
            _phaseEvents.Add(phase, new List<PhaseEvent>());

        _phaseEvents[phase].Add(phaseEvent);
        Debug.Log($"{phaseEvent.Method.Name} subscribed to {phase} phase event");
    }

    public void Unsubscribe(Phase phase, PhaseEvent phaseEvent)
    {
        if (_phaseEvents.ContainsKey(phase))
            _phaseEvents[phase].Remove(phaseEvent);

        Debug.Log($"{phaseEvent.Method.Name} unsubscribed from {phase} phase event");
    }
}