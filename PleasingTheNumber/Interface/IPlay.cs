namespace PleasingTheNumber.Interface;

public interface IPlayable : ICompleted, IInitiated, IMakingMove
{
    void Gamble();
}