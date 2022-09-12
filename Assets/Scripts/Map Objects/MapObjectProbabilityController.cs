using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectProbabilityController
{
    public MapObjectSO mapObjectData;
    public float actualProbability;

    public MapObjectProbabilityController(MapObjectSO mapObject)
    {
        mapObjectData = mapObject;
        actualProbability = mapObject.startingProbability;
    }

    public void RemoveProbability()
    {
        if(actualProbability - mapObjectData.probabilityDecrement >= mapObjectData.minProbability)
        {
            actualProbability -= mapObjectData.probabilityDecrement;
        }
    }

    public void AddProbability()
    {
        if(actualProbability + mapObjectData.probabilityIncrement <= mapObjectData.maxProbability)
        {
            actualProbability += mapObjectData.probabilityIncrement;
        }
    }
}
