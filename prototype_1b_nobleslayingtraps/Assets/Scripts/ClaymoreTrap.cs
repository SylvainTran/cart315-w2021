using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This class inherits from Trap as a
* serialized scriptable object. Values are initialized
* from the inspector for ease.
*/
public class ClaymoreTrap : Trap
{
    /**
    * Default constructor. 
    * Used to get an instance of this trap 
    * in the player inventory mainly.
    */
    public ClaymoreTrap() : base()
    {

    }
}
