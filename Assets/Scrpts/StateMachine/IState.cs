//状态接口
public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}