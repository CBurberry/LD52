using UnityEngine;
using UnityEngine.Playables;
using System;


public class EventTriggerAsset4 : PlayableAsset
{
    public ExposedReference<ButtonSpawner> eventHandler;
    public bool triggerOnPlay;
    public bool triggerOnStop;

    public GameObject prefab;
    public Vector3 position;
    public Quaternion rotation;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EventTriggerBehaviour4>.Create(graph);
        var behaviour = playable.GetBehaviour();

        behaviour.eventHandler = eventHandler.Resolve(graph.GetResolver());
        behaviour.triggerOnPlay = triggerOnPlay;
        behaviour.triggerOnStop = triggerOnStop;
        behaviour.prefab = prefab;
        behaviour.position = position;
        behaviour.rotation = rotation;

        return playable;
    }
}


public class EventTriggerBehaviour4 : PlayableBehaviour
{
    public ButtonSpawner eventHandler;
    public bool triggerOnPlay;
    public bool triggerOnStop;
    public GameObject prefab;
    public GameObject prefabParent;
    public Vector3 position;
    public Quaternion rotation;

    public override void OnPlayableCreate(Playable playable)
    {
        if (triggerOnPlay)
        {
            eventHandler.InstantiateThePrefab();
        }
    }

    public override void OnPlayableDestroy(Playable playable)
    {
        if (triggerOnStop)
        {
            eventHandler.InstantiateThePrefab();
        }
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //prefabParent.Instantiate(prefab, position, rotation);
        eventHandler.Instantiate3();
    }
}
