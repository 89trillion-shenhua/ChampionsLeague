using Base;

public class SeasonInfo : Singleton<SeasonInfo>
{
    public int SeasonId;
    public const int MINRewardPoints = 4000;
    public const int MAXRewardPoints = 6000;

    public void RefreshSeason()
    {
        SeasonId += 1;
    }
}
