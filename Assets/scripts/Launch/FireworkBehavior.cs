using UnityEngine;
using System.Collections;

public class FireworkBehavior : RocketBehavior{

	//The firework rocket is lit on a fuse which is conveniently the time it takes for fuel to run out.
    //It can not stop its gas, so it is always accelerating.
    //It is possible that it will blow up in the sky.
    //It is also possible that this idea will be scrapped. :)
    //Possible benefits?
    //Explosion that hurts others?
    //Possible unlockable, joke rocket?
    //Maybe gets a boost at the start. Who fucking knows.
    
    public override void position()
    {
    
    }
    
    public override void accelerate()
    {
    
    }
    
    public override void shootMissle()
    {
    
    }
    
    void onCollisionEnter(Collision coll)
    {
    
    }
}
