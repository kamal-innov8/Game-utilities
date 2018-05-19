public class GameUtilEvents
{
    public static ParameterlessDelegate OnSocialLoginSuccess;
    public static ParameterlessDelegate OnDisplayAchievements;
    public static AchievementDelegate OnUpdateAchievement;
    public static ChallengeDelegate OnStartChallenge;

    public static void SocialLoginSuccess()
    {
        if (OnSocialLoginSuccess != null)
        {
            OnSocialLoginSuccess();
        }
    }

    public static void DisplayAchievements()
    {
        if (OnDisplayAchievements != null)
        {
            OnDisplayAchievements();
        }
    }

    public static void UpdateAchievement(string id, int value)
    {
        if (OnUpdateAchievement != null)
        {
            OnUpdateAchievement(id, value);
        }
    }

    public static void StartChallenge(Challenge challenge)
    {
        if (OnStartChallenge != null)
        {
            OnStartChallenge(challenge);
        }
    }
}
