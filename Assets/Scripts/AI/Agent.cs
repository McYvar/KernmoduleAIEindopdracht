using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navAgent;
    public Vector3 waypoint;

    [SerializeField] protected BTNode tree;
    [SerializeField] protected Blackboard globalBlackboard;
    [SerializeField] TMP_Text stateText;
    protected Animator animator;
    protected Transform enemy;

    [SerializeField] private Transform playerCamera;

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

    public void SetCurrentEnemy(Transform _enemy)
    {
        enemy = _enemy;
    }

    public void ChangeAnimation(string animationName, float fadeTime)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && !animator.IsInTransition(0))
        {
            animator.CrossFade(animationName, fadeTime);
        }
    }
}
