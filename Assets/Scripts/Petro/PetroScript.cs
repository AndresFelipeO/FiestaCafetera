using UnityEngine;

namespace Petro
{
    public class PetroScript : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator _animator;
        private float _chronometer = 0f;
        public Transform controllerShor;
        public GameObject bulletPrefab;
        public float shotWaitTime = 1f;
        public float shootTimer = 0f;
        public bool noShots=false;
        
        
        [Header("Attack Position")]
        public float attackMinPosition = 0f;
        public float attackMaxPosition = 2.5f;
        private bool _hasPlayedSound = false;
        private SoundManagerPetro _soundManager;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _soundManager = FindObjectOfType<SoundManagerPetro>();
        }

        // Update is called once per frame
        void Update()
        {
            Behavior();
        }
        private void Behavior()
        {
            _chronometer+=1*Time.deltaTime;
        
            if (_chronometer >= 5f && !noShots)
            {
                shootTimer += Time.deltaTime;
                _animator.SetBool(Attack, true);
                
                if (!_hasPlayedSound)
                {
                    _soundManager.PlayShootSound();
                    _hasPlayedSound = true; 
                }
                
                
                if (shootTimer >= shotWaitTime)
                {
                    float randomValue = Random.Range(this.attackMinPosition, this.attackMaxPosition);
                    Shoot(randomValue);
                    shootTimer = 0f;
                }
            }

            if (!(_chronometer >= 15f)) return;
            _animator.SetBool(Attack, false);
            _chronometer = 0f;
            shootTimer = 0f;
            _hasPlayedSound = false;
        }
        private void Shoot(float shootingPosition)
        {
           
            Vector3 newPosition = controllerShor.position;
            newPosition.y += shootingPosition;
            Instantiate(bulletPrefab, newPosition, controllerShor.rotation);
        
        }
    
    }
}
