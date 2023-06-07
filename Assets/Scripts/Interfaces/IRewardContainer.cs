public interface IRewardContainer
{
    RewardPool PossibleRewards { get; }

    public RewardProbability ChooseReward()
    {
        return RewardSelector.ChooseReward(PossibleRewards);
    }
}
