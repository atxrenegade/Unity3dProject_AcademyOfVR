using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    Renderer[] renderers;
    public Material unselected;
    public Material selected;
    Transform player;


	// Use this for initialization
	void Start () {
        player = Camera.main.transform.parent;
        renderers = GetComponentsInChildren<Renderer>();
        UnselectWaypoint();
	}

    public void TeleportPlayer()
    {
       player.position = transform.position;
    }
    public void SelectWaypoint()
    {
        foreach (var rend in renderers)
        {
            rend.material = selected;
        }

    }

    public void UnselectWaypoint()
    {
        foreach (var rend in renderers)
        {
            rend.material = unselected;

        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
