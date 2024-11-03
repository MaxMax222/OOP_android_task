using System;
namespace OOP_learn
{
	public class Mammal : Animal
	{
		public double Milk { get; set; }
		public double Ten_percent { get; }
		public Mammal(string name, Genders gender, double milk) : base(name, gender, milk*500)
		{
			Milk = milk;
			Ten_percent = milk * .1;
		}

		public void NurseBaby(Mammal baby)
		{
			baby.NurseFrom(this);
		}

		public void NurseFrom(Mammal mom)
		{
			if (mom.Gender == Genders.Female && mom.Milk > 0)
			{
				mom.Milk -= mom.Ten_percent;
				mom.Energy = mom.Milk * 500;
				Energy += Ten_percent * 500;
			}
		}

        public override string ToString()
        {
			string result = $"Name: {Name}, Gender: {Gender}, Energy: {Energy}, ";

			if (Gender == Genders.Female)
				result += $"Milk: {Milk}";
			return result;
        }

    }
}

