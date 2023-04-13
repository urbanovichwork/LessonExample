using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
public class ChangeMaterial : MonoBehaviour
{
    private MeshRenderer _mesh;
    private static readonly int Color1 = Shader.PropertyToID("_Color");

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mesh.material.color = Color.Lerp(Color.red, Color.green, Random.Range(0f, 1f));
        }
    }
}
