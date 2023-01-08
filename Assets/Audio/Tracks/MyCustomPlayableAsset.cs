using UnityEngine;
using UnityEngine.Playables;

public class MyCustomPlayableAsset : PlayableAsset
{
    public GameObject prefab;
    public Vector3 position;
    public Quaternion rotation;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<MyCustomPlayableBehaviour>.Create(graph);
        var behaviour = playable.GetBehaviour();
        behaviour.prefab = prefab;
        behaviour.position = position;
        behaviour.rotation = rotation;
        return playable;
    }
}

public class MyCustomPlayableBehaviour : PlayableBehaviour
{
    public GameObject prefab;
    public GameObject prefabParent;
    public Vector3 position;
    public Quaternion rotation;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //prefabParent.Instantiate(prefab, position, rotation);
        Debug.Log("HI");
    }
}

