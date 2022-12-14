using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navAgent;
    public Transform target { get; protected set; }
    public Vector3 waypoint;

    [SerializeField] protected BTNode tree;
    [SerializeField] protected Blackboard globalBlackboard;
    
    private Animator animator;
    [SerializeField] private TMP_Text stateText;
    [SerializeReference] private Equipment equipment;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private AiEvents aiEvents;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        tree.InitializeValues(this, globalBlackboard, stateText);
    }

    private void Start()
    {
    }

    private void Update()
    {
        tree?.Tick();

        stateText.transform.rotation = Quaternion.LookRotation(playerCamera.forward);
    }

    public void SetCurrentTarget(Transform _target)
    {
        target = _target;
    }

    public Equipment GetCurrentEquipment()
    {
        return equipment;
    }

    public void SetCurrentEquipment(Equipment _equipment)
    {
        equipment = _equipment;
    }

    public void ChangeAnimation(string _animationName, float _fadeTime)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(_animationName) && !animator.IsInTransition(0))
        {
            animator.CrossFade(_animationName, _fadeTime);
        }
    }

    public void PlayAnimationOnece(string _animationName)
    {
            animator.Play(_animationName);

    }
}
