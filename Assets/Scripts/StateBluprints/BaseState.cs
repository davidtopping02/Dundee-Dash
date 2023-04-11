// BaseState is a base class for all of the player's states. It provides
// access to the player's components and implements empty versions of the 
// state's methods so that we don't have to implement them in every state.
// States only need to implement the methods that they need.
using UnityEngine;

public abstract class BaseState : MonoBehaviour, State
{


    public BaseState()
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual State OnUpdate()
    {
        return this;
    }

    public virtual State OnFixedUpdate()
    {
        return this;
    }
}