using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCohort
{
    class TimeTracker
    {
        public string Name;
        public TimeTrackerData Duration = new TimeTrackerData();
        public TimeTrackerData Remaining = new TimeTrackerData();
        public bool IsSet;

        private int _roundsPassed = 0;

        public void SetTimer()
        {
            Remaining.Copy(Duration);
            IsSet = true;
        }

        public void AdvanceRound()
        {
            _subtractRounds(1);
            ++_roundsPassed;
        }

        public void EndCombat()
        {
            // was going to just subtract the rest of 10 minutes, but decided
            // to tick off a full 10 minutes to rest no matter how long combat
            // was.
            AdvanceTenMinutes();
            _roundsPassed = 0;
        }

        public void AdvanceTenMinutes()
        {
            int roundsInMinute = 10;
            _subtractRounds(10 * roundsInMinute);
        }

        public void AdvanceOneHour()
        {
            int roundsInMinute = 10;
            int roundsInHour = roundsInMinute * 60;
            _subtractRounds(roundsInHour);
        }

        public void AdvanceFourHours()
        {
            int roundsInMinute = 10;
            int roundsInHour = roundsInMinute * 60;
            _subtractRounds(roundsInHour * 4);
        }

        public void AdvanceEightHours()
        {
            int roundsInMinute = 10;
            int roundsInHour = roundsInMinute * 60;
            _subtractRounds(roundsInHour * 8);
        }

        public void SetTorch()
        {
            Name = "Torch";
            Duration.Rounds = 0;
            Duration.Minutes = 0;
            Duration.Hours = 1;
            SetTimer();
        }

        public void setLantern()
        {
            Name = "Lantern";
            Duration.Rounds = 0;
            Duration.Minutes = 0;
            Duration.Hours = 6;
            SetTimer();
        }

        public void setBless()
        {
            Name = "Bless";
            Duration.Rounds = 0;
            Duration.Minutes = 1;
            Duration.Hours = 0;
            SetTimer();
        }

        private void _subtractRounds(int rounds)
        {
            if (!IsSet) { return; }

            for (int i = 0; i < rounds; ++i)
            {
                if (Remaining.Rounds == 0)
                {
                    if (Remaining.Minutes == 0)
                    {
                        if (Remaining.Hours == 0)
                        {
                            //_TimerExpired();
                        }
                        else
                        {
                            --Remaining.Hours;
                            Remaining.Minutes = 59;
                            Remaining.Rounds = 9;
                        }
                    }
                    else
                    {
                        --Remaining.Minutes;
                        Remaining.Rounds = 9;
                    }
                }
                else
                {
                    --Remaining.Rounds;
                }
            }
            if (Remaining.Rounds == 0 && 
                Remaining.Minutes == 0 && 
                Remaining.Hours == 0)
            {
                _TimerExpired();
            }
        }

        private void _TimerExpired()
        {
            System.Windows.Forms.MessageBox.Show(Name + " Timer Has Expired.");
            IsSet = false;
        }
    }
}
