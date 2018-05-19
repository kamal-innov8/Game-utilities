using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {
        GameUtilEvents.OnSocialLoginSuccess += SocialLoginSuccess;
        GameUtilEvents.OnDisplayAchievements += FacebookLoginSuccess;
    }

    private void FacebookLoginSuccess()
    {
        DebugText.instance.Print("facebook has logged in.");
    }

    private void SocialLoginSuccess()
    {
        DebugText.instance.Print(Social.localUser.userName + " has logged in.");
    }

    public void WinAGame()
    {
        GameUtilEvents.UpdateAchievement(GPGSIds.achievement_win_10_games, 1);
    }

    public void DisplayAchievements()
    {
        GameUtilEvents.DisplayAchievements();
    }
}