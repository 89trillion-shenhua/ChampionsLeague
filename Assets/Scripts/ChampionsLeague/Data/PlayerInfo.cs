using System.Collections.Generic;
using Base;
using UnityEngine;

namespace ChampionsLeague.Data
{
    public class PlayerInfo : Singleton<PlayerInfo>
    {
        private int _points;
        private readonly HashSet<int> _rewardClaimed = new HashSet<int>();

        public void ClaimedStatusChanged(int point)
        {
            _rewardClaimed.Add(point);
        }

        public bool RewardAlreadyClaimed(int point)
        {
            if (_rewardClaimed.Contains(point))
            {
                return true;
            }
        
            return false;
        }
    

        public void AddPoints(int addPoints)
        {
            _points = _points + addPoints > 6000 ? 6000 : _points + addPoints;
            PlayerPrefs.SetInt("playerPoints", _points);
        }

        public void OnSeasonChanged()
        {
            if (_points >= 4000)
            {
                _points = 4000 + (_points - 4000) / 2;
                PlayerPrefs.SetInt("playerPoints", _points);
            }
            _rewardClaimed.Clear();
        }

        public void InitPoints()
        {
            _points = PlayerPrefs.GetInt("playerPoints", 0);
        }

        public int GetPoints()
        {
            return _points;
        }

        public void ShowPoints()
        {
            Debug.LogError(_points);
        }
    }
}