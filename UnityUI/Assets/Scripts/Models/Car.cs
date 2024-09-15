using UnityEngine;

namespace Models
{
    public class Car : MonoBehaviour
    {
        public GameObject carPrefab;
        
        public int gearSpeedLimit = 20;
        public int gearAmount = 5;

        public int TotalSpeed
        {
            get { return gearSpeedLimit * gearAmount; }
        }

        public void CreateSpawnCar()
        {
            var car= Instantiate(carPrefab);
            car.transform.position = Vector3.zero;
        }
    }
}
