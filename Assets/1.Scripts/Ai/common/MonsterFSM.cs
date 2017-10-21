﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Transition
{
    None = 0,
    ReachAttackTime,
    Skill1,
    Skill2,
    NoHealth,
    LookEnemy,
    hitted,
    Escape

}

public enum FSMStateID  // 
{
    None = 0,
    Chasing,
    Attacking,
    Dead,
    Skill1,
    Skill2,
    hitted,
    Escape

}



public class MonsterFSM : AI
{
    private List<FSMState> fsmStates;

    //The fsmStates are not changing directly but updated by using transitions
    public FSMStateID currentStateID;
    public FSMStateID CurrentStateID { get { return currentStateID; } }

    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    public MonsterFSM()
    {
        fsmStates = new List<FSMState>();
    }

    /// <summary>
    /// Add New State into the list
    /// </summary>
    public void AddFSMState(FSMState fsmState)
    {
        // Check for Null reference before deleting
        if (fsmState == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
        }

        // First State inserted is also the Initial state
        //   the state the machine is in when the simulation begins
        if (fsmStates.Count == 0)
        {
            fsmStates.Add(fsmState);
            currentState = fsmState;
            currentStateID = fsmState.ID;
            return;
        }

        // Add the state to the List if it큦 not inside it
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == fsmState.ID)
            {
                Debug.LogError("FSM ERROR: Trying to add a state that was already inside the list");
                return;
            }
        }

        //If no state in the current then add the state to the list
        fsmStates.Add(fsmState);
    }

    /// <summary>
    /// This method delete a state from the FSM List if it exists, 
    ///   or prints an ERROR message if the state was not on the List.
    /// </summary>
    public void DeleteState(FSMStateID fsmState)
    {
        // Check for NullState before deleting
        if (fsmState == FSMStateID.None)
        {
            Debug.LogError("FSM ERROR: bull id is not allowed");
            return;
        }

        // Search the List and delete the state if it큦 inside it
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == fsmState)
            {
                fsmStates.Remove(state);
                return;
            }
        }
        Debug.LogError("FSM ERROR: The state passed was not on the list. Impossible to delete it");
    }

    /// <summary>
    /// This method tries to change the state the FSM is in based on
    /// the current state and the transition passed. If current state
    ///  doesn큧 have a target state for the transition passed, 
    /// an ERROR message is printed.
    /// </summary>
    public void PerformTransition(Transition trans)
    {
        IschageState = false;

        // Check for NullTransition before changing the current state
        if (trans == Transition.None)
        {
            Debug.LogError("FSM ERROR: Null transition is not allowed");
            return;
        }

        // Check if the currentState has the transition passed as argument
        FSMStateID id = currentState.GetOutputState(trans);
        if (id == FSMStateID.None)
        {
            Debug.LogError("FSM ERROR: Current State does not have a target state for this transition");
            return;
        }

        // Update the currentStateID and currentState		
        currentStateID = id;
        foreach (FSMState state in fsmStates)
        {
            if (state.ID == currentStateID)
            {
                currentState = state;
                break;
            }
        }
    }


}
