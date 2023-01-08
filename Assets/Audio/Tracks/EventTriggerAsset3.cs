using UnityEngine;
using UnityEngine.Playables;
using System;


public class EventTriggerAsset3 : PlayableAsset
{
    public ExposedReference<ButtonSpawner> eventHandler;
    public bool triggerOnPlay;
    public bool triggerOnStop;

    public GameObject prefab;
    public Vector3 position;
    public Quaternion rotation;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EventTriggerBehaviour3>.Create(graph);
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


public class EventTriggerBehaviour3 : PlayableBehaviour
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
            //eventHandler.Instantiate2();
        }
    }

    public override void OnPlayableDestroy(Playable playable)
    {
        if (triggerOnStop)
        {
            eventHandler.Instantiate2();
        }
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //prefabParent.Instantiate(prefab, position, rotation);
        eventHandler.Instantiate2();
    }
}
