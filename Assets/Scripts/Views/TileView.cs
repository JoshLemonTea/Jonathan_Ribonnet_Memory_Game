using Memory.Data; // Import the Memory.Data namespace
using Memory.Models; // Import the Memory.Models namespace
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Memory.Views
{
    public class TileView : ViewBaseClass<Tile>, IPointerDownHandler
    {
        public TileView()
        {
        }

        private Animator _animator;

        public void OnPointerDown(PointerEventData eventData)
        {
            // When the tile is clicked, add it to the preview and log the MemoryCardId

            Model.MemoryBoard.State.AddPreview(Model);
            Debug.Log(Model.MemoryCardId);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Handle property changes in the tile model

            if (e.PropertyName.Equals(nameof(Model.State)))
            {
                // If the State property changes, start the animation

                StartAnimation();
            }
            else if (e.PropertyName.Equals(nameof(Model.MemoryCardId)))
            {
                // If the MemoryCardId property changes, load the front texture

                LoadFront();
            }
        }

        private void LoadFront()
        {
            // Load the front texture for the tile's MemoryCardId using the ImageRepository

            ImageRepository.Instance.GetProcessTexture(Model.MemoryCardId, LoadFront);
        }

        private void LoadFront(Texture2D texture)
        {
            // Set the front texture of the tile's GameObject

            gameObject.transform.Find("Front").GetComponent<Renderer>().material.mainTexture = texture;
        }

        private void StartAnimation()
        {
            // Start the appropriate animation based on the tile's state

            if (Model.State.State == Models.States.TileStates.Hidden)
            {
                _animator.Play("Hide");
            }
            else
            {
                _animator.Play("Shown");
            }
        }

        private void Start()
        {
            // Initialize the animator component and add events

            _animator = GetComponent<Animator>();
            AddEvents();
        }

        private void AddEvents()
        {
            // Add events to the animation clips of the animator

            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];

                AnimationEvent animationStartEvent = new AnimationEvent();
                animationStartEvent.time = 0;
                animationStartEvent.functionName = "AnimationStartHandler";
                animationStartEvent.stringParameter = clip.name;

                AnimationEvent animationEndEvent = new AnimationEvent();
                animationEndEvent.time = clip.length;
                animationEndEvent.functionName = "AnimationCompleteHandler";
                animationEndEvent.stringParameter = clip.name;

                clip.AddEvent(animationStartEvent);
                clip.AddEvent(animationEndEvent);
            }
        }

        public void AnimationStartHandler(string name)
        {
            // Handle animation start events (optional)
            //Debug.Log($"{name} animation start.");
        }

        public void AnimationCompleteHandler(string name)
        {
            // Handle animation complete events (optional)
            //Debug.Log($"{name} animation complete.");
            Model.MemoryBoard.State.TileAnimationEnd(Model);
        }
    }
}
