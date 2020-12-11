using System;

namespace virtualpets {
    public abstract class Pet {
        public string Name { get; set; }
        public bool Healthy { get; set; }

        double happiness;
        public double Happiness {
            get { return happiness; }
            set {
                if (value >= 100) {
                    happiness = 100;
                } else {
                    happiness = value;
                }
            }
        }
        double hunger;
        public double Hunger {
            get { return hunger; }
            set {
                if (value >= 100) {
                    hunger = 100;
                } else {
                    hunger = value;
                }
            }
        }

        public double IdealTemperature { get; set; }
        public Pet (string name, bool healthy, double happiness, double hunger, double idealTemp) {
            healthy = true;

        }

        public virtual void FeedPet () {
            Hunger += 5;
        }
    }
}