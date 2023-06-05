using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeight : MonoBehaviour
{
    private SkinnedMeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    private void Start()
    {
        Debug.Log(meshRenderer.bounds.size);
    }
}