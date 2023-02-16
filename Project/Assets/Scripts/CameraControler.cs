using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    void Update()
    {
        List<Vector3> positions = new List<Vector3>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (var i = 0; i < players.Length; i++) {
            positions.Add(players[i].transform.position);
        }

        Vector3 AverageLocation = MeanVector(positions);

        gameObject.transform.LookAt(AverageLocation, Vector3.up);
        Debug.DrawRay(transform.position, AverageLocation - transform.position, Color.red);
    }

    private Vector3 MeanVector(List<Vector3> positions)
    {
        if(positions.Count == 0) { return Vector3.zero; }

        Vector3 meanVector = Vector3.zero;
        foreach(Vector3 pos in positions)
        {
            meanVector += pos;
        }
        return (meanVector / positions.Count);
    }
}
