using System;
namespace OOP_learn
{
	public class Fish : Animal
	{
		public Fish(string name, Genders gender, double energy) : base(name, gender, energy) { }
        public override string Move() => "I move by swimming";
        public override string Talk() => "Blu Blu Blu";
    }
}

