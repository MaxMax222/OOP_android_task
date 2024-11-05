using System;
namespace OOP_learn
{
	public class Bird : Animal
	{
        public double Height { get; }
		public Bird(string name, Genders gender, double energy, double height) : base(name, gender, energy) { Height = height; }
        public override string Move() => "I move by flying";
        public override string Talk() => "Tweet Tweet";

        public override string ToString()
        {
            return $"Name: {Name}, Gender: {Gender}, Energy: {Energy}, Height: {Height}";

        }
    }
}

