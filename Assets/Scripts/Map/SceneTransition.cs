using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Map
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        [SerializeField] private GameObject interactionPrompt;
        [SerializeField] private bool isPlayerInRange=false;
        void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            isPlayerInRange = true;
            if(interactionPrompt != null)
                interactionPrompt.SetActive(true);
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            isPlayerInRange = false;
            if(interactionPrompt != null)
                interactionPrompt.SetActive(false);
        }
    }
}
