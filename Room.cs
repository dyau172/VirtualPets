using System;

namespace virtualpets {
    public class Room {

        public double CurrentTemp;
        public Pet pet;

        public Room () {
            CurrentTemp = new Random ().Next (5, 30);

        }

        public void IncreaseTemp () {
            CurrentTemp += 0.5;

        }

        public void DecreaseTemp () {
            CurrentTemp -= 0.5;

        }

        public void PetInRoom (Pet pet) {
            this.pet = pet;
        }

        public void UpdateTemp () {
            if (CurrentTemp > pet.IdealTemperature) {
                IncreaseTemp ();
            } else {
                DecreaseTemp ();
            }
        }

    }

}