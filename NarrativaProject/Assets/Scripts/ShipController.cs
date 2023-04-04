using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public enum Stance
    {
        ROAMING = 0,
        BATTLE
    }

    public Stance currentStance;
    public GameObject target;
    public float velocity = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentStance = Stance.BATTLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStance == Stance.BATTLE)
            transform.RotateAround(target.transform.position, Vector3.up, -velocity * Time.deltaTime);
    }
}
