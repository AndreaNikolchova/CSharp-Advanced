
namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Map : IMap
    {
        private const double racingBehaviorMultiplierStrict = 1.2;
        private const double racingBehaviorMultiplierAggresive = 1.1;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            double chanceOfWinningOfRacerOne = 0;
            double chanceOfWinningOfRacerTwo = 0;
            if (racerOne.IsAvailable()&&racerTwo.IsAvailable())
            {
                if (racerOne.RacingBehavior == "strict")
                   chanceOfWinningOfRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierStrict;
                else
                    chanceOfWinningOfRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierAggresive;


                if (racerTwo.RacingBehavior == "strict")
                    chanceOfWinningOfRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierStrict;
                else
                    chanceOfWinningOfRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierAggresive;


                if (chanceOfWinningOfRacerOne > chanceOfWinningOfRacerTwo)
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                else
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable()&&!racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if(racerOne.IsAvailable()&& !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

        }
    }
}
