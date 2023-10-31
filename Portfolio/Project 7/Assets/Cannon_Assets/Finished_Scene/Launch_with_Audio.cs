using System;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

namespace Cannon_Assets.Finished_Scene
{
    public class LaunchWithAudio : MonoBehaviour
    {
        public GameObject projectile;
        public AudioClip shootSound;

        public float launchVelocity = 700f;
        public float lowVolumeRange = .5f;
        public float highVolumeRange = 1.0f;

        private AudioSource source;
        private MeshRenderer sphereRenderer;
        private XRSimpleInteractable interactable;
        
        private bool inPlayerRay;
        private bool selected;
        private bool alreadyShot;

        private void SetInPlayerRay(bool inRay)
        {
            if (alreadyShot)
            {
                Debug.Log("LaunchWithAudio: already shot, nothing more to do");
                return;
            }

            Debug.Log("LaunchWithAudio: Set in player ray = " + inRay);
            inPlayerRay = inRay;
            sphereRenderer.enabled = inRay;
        }

        private void SetSelected(bool select)
        {
            selected = select;
            Debug.Log("LaunchWithAudio: set selected = " + select);
        }

        private void Start()
        {
            inPlayerRay = false;
            alreadyShot = false;
            source = GetComponent<AudioSource>();

            var sphere = (from Transform child in transform
                where
                    child.gameObject.name.Equals("Sphere")
                select child.gameObject).FirstOrDefault();
            if (sphere == null)
            {
                throw new Exception("LaunchWithAudio: No sphere found");
            }

            Debug.Log("LaunchWithAudio: fetched on start the sphere = " + sphere);

            sphereRenderer = sphere.GetComponent<MeshRenderer>();
            interactable = sphere.GetComponent<XRSimpleInteractable>();
            interactable.hoverEntered.AddListener(_ => SetInPlayerRay(true));
            interactable.hoverExited.AddListener(_ => SetInPlayerRay(false));
            interactable.selectEntered.AddListener(_ => SetSelected(true));
            interactable.selectExited.AddListener(_ => SetSelected(false));
            Debug.Log("LaunchWithAudio: added listeners to interactable = " + interactable);

            SetInPlayerRay(false);
        }

        private void Update()
        {
            if (alreadyShot || !inPlayerRay || !selected) return;

            var vol = Random.Range(lowVolumeRange, highVolumeRange);
            source.PlayOneShot(shootSound, vol);

            var launchThis = Instantiate(projectile, transform.position, transform.rotation);
            launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));

            alreadyShot = true;
            sphereRenderer.material.color = Color.red;
        }
    }
}