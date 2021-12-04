using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FindPlayerForConstraint : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        {

        }
        //make a reference to the position constraint component
        PositionConstraint constraint = this.GetComponent<PositionConstraint>();
        //find the player
        Transform player = GameObject.Find("Player").transform;
        // make the player an animation source
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = player;
        source.weight = 1;
        // add the player to the position constraint sources
        constraint.AddSource(source);
        //activate the position constraint
        
    }
}
