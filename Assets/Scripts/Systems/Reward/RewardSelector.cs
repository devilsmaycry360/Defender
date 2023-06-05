using UnityEngine;

public class RewardSelector : MonoBehaviour
{
    public static RewardType ChooseReward(RewardPool pool)
    {
        float totalWeight = 0;
        float weightCheck = 0;
        RewardType chosenRewardType = RewardType.None;
        
        foreach (RewardProbability reward in pool.PossibleRewards)
            totalWeight += reward.Chance;

        float randomWeight = Random.Range(0, totalWeight);

        foreach (RewardProbability reward in pool.PossibleRewards)
        {
            weightCheck += reward.Chance;
            
            if (randomWeight > weightCheck)
                continue;

            chosenRewardType = reward.Type;
            break;
        }

        return chosenRewardType;
    }
}
