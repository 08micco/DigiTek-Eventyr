using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WolfFriendly : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform playerObj;

    private Animator wolfAnimator;

    private Transform startPoint;

    private void Awake()
    {
        wolfAnimator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        startPoint = gameObject.transform;
    }

    public void GoToPlayer()
    {
        wolfAnimator.SetBool("isIdle", false);
        agent.SetDestination(playerObj.position);
        StartCoroutine(WalkWait());
    }

    private IEnumerator WalkWait()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        StandStill();
    }
    
    private void StandStill()
    {
        wolfAnimator.SetBool("isIdle", true);
    }
    public void WalkBack()
    {
        wolfAnimator.SetBool("isIdle", false);
        gameObject.transform.position -= new Vector3(0, -0.5f, 0);
        agent.SetDestination(startPoint.position);
        Destroy(gameObject);
    }
    
    private IEnumerator WalkWait2()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        
    }
    
}
