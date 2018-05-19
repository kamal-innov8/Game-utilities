public interface IChallenge
{
    event ChallengeComplete Complete;
}

public delegate void ChallengeComplete();