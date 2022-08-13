namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Models.FormulaOneCars;
    using Repositories;
    using Utilities;
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this.pilotRepository.Models.FirstOrDefault(x => x.FullName == pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else
            {
                var car = this.carRepository.Models.FirstOrDefault(x => x.Model == carModel);
                if (car == null)
                {
                    throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
                }
                else
                {
                    pilot.AddCar(car);
                    return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, car.Model);
                }
            }
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = this.raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else
            {
                var pilot = this.pilotRepository.Models.FirstOrDefault(x => x.FullName == pilotFullName);
                IPilot isPilotInRace = null;
                if (pilot!=null)
                {
                    isPilotInRace = race.Pilots.FirstOrDefault(x=>x.FullName == pilot.FullName);

                }
                if (pilot == null || pilot.CanRace == false || isPilotInRace!=null)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
                }
                else
                {
                    race.Pilots.Add(pilot);
                    return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
                }
            }
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type == "Ferrari")
            {
                var car = this.carRepository.Models.FirstOrDefault(x => x.Model == model);
                if (car != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                this.carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }
            else if (type == "Williams")
            {
                var car = this.carRepository.Models.FirstOrDefault(x => x.Model == model);
                if (car != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                this.carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }
            else
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
        }

        public string CreatePilot(string fullName)
        {
            var pilot = pilotRepository.Models.FirstOrDefault(x => x.FullName == fullName);
            if (pilot == null)
            {
                pilotRepository.Add(new Pilot(fullName));
                return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            }
            else
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));

        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName);
            if (race != null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));

            this.raceRepository.Add(new Race(raceName, numberOfLaps));
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            List<IPilot> pilots = this.pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            return String.Join(Environment.NewLine, pilots);
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var pilot in this.raceRepository.Models.Where(x=>x.TookPlace == true))
            {
                sb.AppendLine(pilot.RaceInfo());
            }
            return sb.ToString().Trim();

        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else
            {
                if (race.Pilots.Count < 3)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
                }
                else if (race.TookPlace)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
                }
                else
                {
                    race.TookPlace = true;
                    List<IPilot> top3Pilots = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
                    top3Pilots[0].WinRace();
                    return String.Format(OutputMessages.PilotFirstPlace, top3Pilots[0].FullName, raceName) + Environment.NewLine + String.Format(OutputMessages.PilotSecondPlace, top3Pilots[1].FullName, raceName) + Environment.NewLine + String.Format(OutputMessages.PilotThirdPlace, top3Pilots[2].FullName, raceName);
                }

            }
        }
    }
}
