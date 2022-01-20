public interface BaseState
{
    void Enter();

    void Tick();

    void FixedTick();

    void Exit();
}
