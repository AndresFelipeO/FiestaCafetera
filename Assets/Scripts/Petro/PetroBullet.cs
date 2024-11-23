using UnityEngine;

namespace Petro
{
    public class PetroBullet : MonoBehaviour
    {
        public float velocity;
        public int damage;
        public float timeDestroyObjet=5f;
    
        private float _chronometer = 0f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            _chronometer+=1*Time.deltaTime;
            transform.Translate(Time.deltaTime*velocity*Vector2.right);
            if (_chronometer >= timeDestroyObjet)
            {
                Destroy(gameObject);
            }
        }
    }
}
