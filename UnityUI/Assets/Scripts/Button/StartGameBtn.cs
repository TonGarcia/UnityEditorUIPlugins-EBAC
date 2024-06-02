using UnityEngine;

namespace Button
{
    public class StartGameBtn : MonoBehaviour
    {
        public ParticleSystem particleSystem;
        public void OnClick()
        {
            particleSystem.Play();
        }
    }    
}
