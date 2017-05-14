using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<NavMeshBuildMarkup> markups = new List<NavMeshBuildMarkup>();
        List<NavMeshBuildSource> builds = new List<NavMeshBuildSource>();
        NavMeshBuilder.CollectSources(transform, LayerMask.NameToLayer("Default"), NavMeshCollectGeometry.RenderMeshes, 0, markups, builds);
        NavMeshBuildSettings buildSettings = new NavMeshBuildSettings();
        Bounds localBounds = new Bounds();
        localBounds.size = new Vector3(100f, 100f, 100f);

        NavMeshBuilder.BuildNavMeshData(buildSettings, builds, localBounds, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
