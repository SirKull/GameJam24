using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public enum HelperState { idle, findBody, findChute, returnHome};
public class Helper : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;
    public LevelManager levelManager;
    public AIPath aiPath;
    public HelperState status;
    public Transform helperBody;

    public Transform startPosition;
    public Transform chute;
    public Transform bodyPosition;
    public bool enemyDead;
    private bool atBody;
    public bool pathInProgress;
    public bool bodyHeld;
    public bool atChute;

    private void OnEnable()
    {
        bodyHeld = false;
        atBody = false;
        pathInProgress = false;
        atChute = false;
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        levelManager = FindObjectOfType<LevelManager>();
        ChangeStatus(HelperState.idle);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RunStatus();
        ChooseStatus();
    }
    void RunStatus()
    {
        switch (status)
        {
            case HelperState.idle:
                break;
            case HelperState.findBody:
                pathInProgress = true;
                if (aiPath.reachedEndOfPath)
                {
                    enemyDead = false;
                    bodyHeld = true;
                }
                break;
            case HelperState.findChute:
                destinationSetter.target = chute;
                if (Vector2.Distance(transform.position, chute.position) < 1)
                {
                    levelManager.chum++;
                    atChute = true;
                    bodyHeld = false;
                }
                break;
            case HelperState.returnHome:
                destinationSetter.target.position = startPosition.transform.position;
                if (Vector2.Distance(transform.position, startPosition.position) < 1)
                {
                    atChute = false;
                    pathInProgress = false;
                    enemyDead = false;
                }
                break;
        }  
    }
    void ChooseStatus()
    {
        if (!aiPath.pathPending && !pathInProgress && !bodyHeld && enemyDead &&  !atChute)
        {
            ChangeStatus(HelperState.findBody);
        }
        if (!aiPath.pathPending && pathInProgress && bodyHeld && !enemyDead && !atChute)
        {
            ChangeStatus(HelperState.findChute);
        }
        if (!aiPath.pathPending && pathInProgress && !bodyHeld && !enemyDead && atChute)
        {
            ChangeStatus(HelperState.returnHome);
        }
        if (!pathInProgress && !bodyHeld &&!enemyDead && !atChute)
        {
            ChangeStatus(HelperState.idle);
        }
    }
    void ChangeStatus(HelperState s)
    {
        if (status == s) { return; }
        Debug.LogError("Status " + s);
        status = s;
        return;
    }
}
