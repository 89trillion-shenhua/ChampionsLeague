using Base;

public class PlayerInfo : Singleton<PlayerInfo>
{
    public int Points;
    public int curSeasonId; // 用于判断玩家数据的赛季ID，是否需要刷新数据

    public void AddPoints(int addPoints)
    {
        Points += addPoints;
    }

    public void OnSeasonChanged(int newSeasonId)
    {
        int dif = newSeasonId - curSeasonId;
        
        if (Points >= 4000)
        {
            for (int i = 0; i < dif; i++)
            {
                Points = 4000 + (Points - 4000) / 2;
            }
        }
        else
        {
            return;
        }

        curSeasonId = newSeasonId;
    }
}