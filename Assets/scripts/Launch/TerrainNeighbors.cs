using UnityEngine;
using System.Collections;

public class TerrainNeighbors : MonoBehaviour {

	public Terrain _0;
	public Terrain _1;
	public Terrain _2;
	public Terrain _3;

	// Use this for initialization
	void Start () {
		_0.SetNeighbors (null, null, _1, null);
		_1.SetNeighbors (_0, null, _2, null);
		_2.SetNeighbors (_1, null, _3, null);
		_3.SetNeighbors (_2, null, null, null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
