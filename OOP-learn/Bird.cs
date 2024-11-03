using System;
namespace OOP_learn
{
	public class Bird : Animal
	{
		public Bird(string name, Genders gender, double energy) : base(name, gender, energy) { }
        public override string Move() => "I move by flying";
        public override string Talk() => "Tweet Tweet";
    }
}

