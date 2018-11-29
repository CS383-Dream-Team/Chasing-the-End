//Used as parent for inheritence for different directions with traps
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Set Speed of projectile from trap
    //Use of static binding to keep all trap speeds the same at the moment of compilation.
    public static float speed = 8f;

}
