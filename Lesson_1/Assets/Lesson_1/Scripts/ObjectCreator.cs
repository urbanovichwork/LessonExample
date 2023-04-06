using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabsWithCustomComponents;
    [SerializeField] private List<GameObject> _prefabsWithoutCustomComponents;
    [SerializeField] private int _sphereRadiusForCreation = 3;

    private void Update()
    {
        TryCustomCreation();
        TryCleanCreation();
    }

    private void TryCustomCreation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateCustomObject();
        }
    }

    private void CreateCustomObject()
    {
        var randomPrefab = _prefabsWithCustomComponents[Random.Range(0, _prefabsWithCustomComponents.Count)];
        Instantiate(randomPrefab);
    }

    private void TryCleanCreation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CreateCleanObject();
        }
    }

    private void CreateCleanObject()
    {
        var randomPrefab = _prefabsWithoutCustomComponents[Random.Range(0, _prefabsWithoutCustomComponents.Count)];
        var position = Random.insideUnitSphere * _sphereRadiusForCreation;
        var obj = Instantiate(randomPrefab, position, Quaternion.identity);
        var componentCount = Random.Range(1, 3);
        for (int i = 0; i < componentCount; i++)
        {
            var randomComponentNumber = Random.Range(0, 4);
            AddRandomComponent(obj, randomComponentNumber);
        }
    }

    private void AddRandomComponent(GameObject obj, int randomComponentNumber)
    {
        Type component = typeof(ScaleChanger);
        switch (randomComponentNumber)
        {
            case 0:
                component = typeof(ScaleChanger);
                break;
            case 1:
                component = typeof(PositionLoop);
                break;
            case 2:
                component = typeof(Teleportator);
                break;
            case 3:
                component = typeof(Rotator);
                break;
        }

        var addedComponent = obj.AddComponent(component);
        (addedComponent as IRandomizer)?.RandomizeValues();
    }
}