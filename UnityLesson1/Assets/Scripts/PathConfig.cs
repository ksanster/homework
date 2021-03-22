using System;
using UnityEngine;

[Serializable]
public class PathConfig
{
    [SerializeField]
    private Transform[] waypoints;
        
    public Transform[] Waypoints => waypoints;
}
