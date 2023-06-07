using UnityEngine;

public class RewardSelector : MonoBehaviour
{
    public static RewardProbability ChooseReward(RewardPool pool)
    {
        float totalWeight = 0;
        float weightCheck = 0;
        RewardProbability chosenReward = new RewardProbability();
        
        foreach (RewardProbability reward in pool.PossibleRewards)
            totalWeight += reward.Chance;

        float randomWeight = Random.Range(0, totalWeight);

        foreach (RewardProbability reward in pool.PossibleRewards)
        {
            weightCheck += reward.Chance;
            
            if (randomWeight > weightCheck)
                continue;

            chosenReward = reward;
            break;
        }

        return chosenReward;
    }
}
