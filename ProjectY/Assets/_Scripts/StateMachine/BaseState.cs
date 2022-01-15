public interface BaseState
{
    ///<summary>automatically gets called in the State machine. Allows you to delay flow if desired</summary>
    void Enter();

    ///<summary>allows simulate of Update() method without a MonoBehaviour attached</summary>
    void Tick();

    ///<summary>allows simulate FixedUpdate() method without a MonoBehaviour attached</summary>
    void FixedTick();

    ///<summary>automatically gets called in the State machine. Allows you to delay flow if desired</summary>
    void Exit();
}
