using UnityEngine;

namespace Models
{
    public class Car : MonoBehaviour
    {
        public int gearSpeedLimit = 20;
        public int gearAmount = 5;

        public int MaxSpeed
        {
            get { return gearSpeedLimit * gearAmount; }
        }
    }
}
