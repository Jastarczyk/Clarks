using UnityEngine;
using System.Collections;
using Assets._Scripts.Global;
using Assets._Scripts.AttachedToObjects;
using System;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(Animator))]
public class DoorOpenManager : MonoBehaviour
{
    public bool IsOpenable = true;
    public AudioClip OpeningDoorsSound;

    [SerializeField] private bool ShowHint;
    [SerializeField] private DoorSidesKind DoorSide;

    private TextMesh objectHintText;
    private BoxCollider openAreaTriggerCollider;
    private AudioSource localAudioSource;

    private Animator doorAnimator;

    private void Awake()
    {
        objectHintText = GetComponentInChildren<TextMesh>();
        openAreaTriggerCollider = GetComponent<BoxCollider>();
        doorAnimator = GetComponent<Animator>();
        localAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        objectHintText.text = string.Empty; //display nothin on start (Default stage)
        localAudioSource.clip = OpeningDoorsSound;
    }

    private void OnTriggerStay(Collider hitCollider)
    {
        if (hitCollider.CompareTag("Player") && IsOpenable)
        {
            objectHintText.text = ShowHint ? TranslationManager.GetLocalizationDictionary()["DoorHintMeshTextLabel"] : string.Empty;

            if (Input.GetKey("f"))
            {
                OpenDoor(DoorSide);
            }
        }
    }

    private void OnTriggerExit(Collider doorsCol)
    {
        if (doorsCol.CompareTag("Player"))
        {
            objectHintText.text = string.Empty;
        }
    }

    //TODO need to find out how to implement universal way to open door (from any possition)
    private void OpenDoor(DoorSidesKind side)
    {
        AnimateTheDoor(side);
        openAreaTriggerCollider.enabled = false;
        objectHintText.text = string.Empty;
        localAudioSource.Play();
    }

    private void AnimateTheDoor(DoorSidesKind side)
    {
        doorAnimator.Play(side == DoorSidesKind.RightSided ? "RightSidedOpen" : "LeftSidedOpen");
    }
}
