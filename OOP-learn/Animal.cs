using System;
namespace OOP_learn
{ 
	public abstract class Animal
	{
		public enum Genders
		{
			Male, Female
		}

		public string Name { get; }
		public Genders Gender { get; }
		public double Energy { get; set; }
		public Animal(string name, Genders gender, double energy) {
			Name = name;
			Gender = gender;
			Energy = energy;
		}

		public virtual string Move() => "I Move by moving";
		public virtual string Talk() => "Making a sound";
        public override string ToString()
        {
			return $"Name: {Name}, Gender: {Gender}, Energy: {Energy}";
        }
    }
}

