using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PathManager : MonoBehaviour {

    public List<Paths> paths;

	// Use this for initialization
	void Start () {
        paths = FindObjectsOfType<Paths>().ToList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
