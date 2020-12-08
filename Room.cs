using System;

namespace virtualpets {
    public class Room {

        public double CurrentTemp;
        public Pet pet;

        public Room () {
            CurrentTemp = new Random ().Next (15, 30);

        }

        public void IncreaseTemp () {
            CurrentTemp += 1.0;

        }

        public void DecreaseTemp () {
            CurrentTemp -= 1.0;

        }

        public void PetInRoom (Pet pet) {
            this.pet = pet;
        }

        public void UpdateTemp () {
            if (CurrentTemp > pet.IdealTemperature) {
                CurrentTemp += (0.1 / 100);
            } else {
                CurrentTemp -= (0.1 / 100);
            }

        }

        public void CheckTemp () {
            double tooHot = pet.IdealTemperature + 10;
            double tooCold = pet.IdealTemperature - 10;

            if (CurrentTemp > tooHot) {
                Console.SetCursorPosition (2, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ("The room is too hot");
            } else if (CurrentTemp < tooCold) {
                Console.SetCursorPosition (2, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ("The room is too cold");
            } else {

            }

        }

    }
}