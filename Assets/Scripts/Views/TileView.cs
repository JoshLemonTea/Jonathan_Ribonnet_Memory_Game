using Memory.Data;
using Memory.Models;
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
            Model.MemoryBoard.State.AddPreview(Model);
            Debug.Log(Model.MemoryCardId);
           
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.State)))
            {
                StartAnimation();
            }
            else if (e.PropertyName.Equals(nameof(Model.MemoryCardId)))
                LoadFront();
        }

        private void LoadFront()
        {
            ImageRepository.Instance.GetProcessTexture(Model.MemoryCardId, LoadFront);
        }

        private void LoadFront(Texture2D texture)
        {
            gameObject.transform.Find("Front").GetComponent<Renderer>().material.mainTexture = texture;
        }

        private void StartAnimation()
        {
            if (Model.State.State == Models.States.TileStates.Hidden)
            {
                _animator.Play("Hide");
            }
            else
            {
                _animator.Play("Shown");            }

        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            AddEvents();
        }

        private void AddEvents()
        {
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
            //Debug.Log($"{name} animation start.");
        }
        public void AnimationCompleteHandler(string name)
        {
            //Debug.Log($"{name} animation complete.");
            Model.MemoryBoard.State.TileAnimationEnd(Model);
        }
    }

}
