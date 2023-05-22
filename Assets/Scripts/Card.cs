using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private Animator _animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        _animator.Play("Shown");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
