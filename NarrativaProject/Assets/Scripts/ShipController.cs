using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipController : MonoBehaviour
{
    public enum Stance
    {
        ROAMING = 0,
        BATTLE,
        NONE
    }

    public List<GameObject> points;
    public Stance currentStance;
    public GameObject target;
    public float velocity = 5.0f;
    private bool hasArrived = false;
    private int index = 0;
    private int totalPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentStance = Stance.NONE;
        totalPoints = points.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStance == Stance.BATTLE)
            transform.RotateAround(target.transform.position, Vector3.up, -velocity * Time.deltaTime);
        else if(currentStance == Stance.ROAMING)
        {
            var step = velocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, points[index].gameObject.transform.position, step);
            Vector3 direction = (points[index].transform.position - this.transform.position).normalized;

           
            this.transform.forward = direction;

            if (transform.position == points[index].gameObject.transform.position)
            {
                ++index;
                index = index % totalPoints;
            }
        }
        

    }
}
