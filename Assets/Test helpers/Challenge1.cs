using UnityEngine.EventSystems;

public class Challenge1 : Challenge
{
    int count;
    int targetCount = 10;
    public override event ChallengeDelegate Complete;

    public override void OnPointerClick(PointerEventData eventData)
    {
        count = 0;
        Test.challenge1Complete += OnEvent;
        GameUtilEvents.StartChallenge(this);
    }

    private void OnEvent()
    {
        count++;
        if (count == targetCount)
        {
            Test.challenge1Complete -= OnEvent;
            Complete(this);
        }
    }
}
