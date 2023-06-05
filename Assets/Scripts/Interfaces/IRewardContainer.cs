public interface IRewardContainer
{
    RewardPool PossibleRewards { get; }

    public RewardType ChooseReward()
    {
        return RewardSelector.ChooseReward(PossibleRewards);
    }
}
