using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreTrap : Trap
{
    // Default constructor. This is just to get in an instance of this trap in the inventory
    public ClaymoreTrap()
    {
        
    }
    
    public override bool Equals(System.Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            ClaymoreTrap p = (ClaymoreTrap) obj;
            return (TrapID == p.TrapID);
        }
    }
}
