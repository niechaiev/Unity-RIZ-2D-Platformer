using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CheckRange : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float MinDistance;
    private Transform enemy;

    private Component component;
    void Start()
    {
        enemy = GetComponent<Transform>();

        component = GetComponent("AIPath");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, enemy.position) < MinDistance)
        {
            (component as MonoBehaviour).enabled = true;
        }
        else if (Vector2.Distance(target.position, enemy.position) >= MinDistance)
        {
            (component as MonoBehaviour).enabled = false;
        }
    }
}
