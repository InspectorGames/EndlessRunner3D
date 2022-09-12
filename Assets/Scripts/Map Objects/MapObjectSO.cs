using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Endless Runner/Map Object", fileName = "New Map Object")]
public class MapObjectSO : ScriptableObject
{
    public enum Type
    {
        Obstacle,
        Collectable
    }

    public enum YPosition
    {
        Upper = 5,
        Middle = 3,
        Lower = 0
    }

    [TextArea]
    public string description;
    public GameObject mapObjectPf;
    public Type type;
    public YPosition yPosition = YPosition.Lower;
    public YPosition yPositionCoin;
    [Space]
    [Range(0f, 100f)]
    public float maxProbability;
    [Range(0f, 100f)]
    public float minProbability;
    [Range(0f, 100f)]
    public float startingProbability;
    [Range(0f, 100f)]
    public float probabilityDecrement;
    [Range(0f, 100f)]
    public float probabilityIncrement;
}
