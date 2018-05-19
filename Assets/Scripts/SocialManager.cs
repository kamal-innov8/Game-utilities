using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;


public class SocialManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameUtilEvents.OnUpdateAchievement += UpdateAchievement;
        GameUtilEvents.OnDisplayAchievements += DisplayAchievements;
    }

    private void OnDisable()
    {
        GameUtilEvents.OnUpdateAchievement -= UpdateAchievement;
        GameUtilEvents.OnDisplayAchievements -= DisplayAchievements;
    }

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();
        }
        Login();
    }

    void Login()
    {
        Social.Active.Authenticate(Social.localUser, response =>
         {
             if (response)
             {
                 GameUtilEvents.SocialLoginSuccess();
                 GameUtilEvents.UpdateAchievement(GPGSIds.achievement_welcome, 100);
             }
         });
    }

    private void UpdateAchievement(string id, int value)
    {
        if (Application.platform == RuntimePlatform.Android && value != 100)
        {
            PlayGamesPlatform.Instance.IncrementAchievement(id, value, (bool success) =>
            {
                if (success)
                {
                    DebugText.instance.Print(id + " has incremented successfully!");
                }
                else
                {
                    DebugText.instance.Print(id + " has failed to increment!");
                }
            });
        }
        else
        {
            Social.ReportProgress(id, double.Parse(value.ToString()), success =>
            {
                if (success)
                {
                    DebugText.instance.Print(id + " has progressed successfully!");
                }
                else
                {
                    DebugText.instance.Print(id + " has failed to progress!");
                }
            });
        }
    }

    private void DisplayAchievements()
    {
        Social.ShowAchievementsUI();
    }
}
