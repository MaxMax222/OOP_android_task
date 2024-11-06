
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace OOP_learn
{
	[Activity (Label = "CreateAnimals")]			
	public class CreateAnimals : Activity
	{
		Button dog, fish, bird, submit;
		LinearLayout main;
		EditText edit_milk, edit_name, edit_gender, edit_energy, edit_special;
		int type;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.CreateAnimals);
			Init();
			AddClicks();
		}

        private void AddClicks()
        {
            dog.Click += Dog_Click;
            fish.Click += Fish_Click;
            bird.Click += Bird_Click;
        }

        private void Bird_Click(object sender, EventArgs e)
        {
			type = 1;
			GenerateForm(type);
        }

        private void Fish_Click(object sender, EventArgs e)
        {
			type = 2;
			GenerateForm(type);
        }

        private void Dog_Click(object sender, EventArgs e)
        {
			type = 3;
			GenerateForm(type);
        }
		private void GenerateForm(int type)
		{
			main.RemoveAllViews();

			string name;
            switch (type)
            {
                case 1:
					name = "bird";
                    break;
				case 2:
					name = "fish";
					break;
				case 3:
					name = "dog";
					break;

                default:
					name = "";
                    break;
            }

			var size_of_edit = new LinearLayout.LayoutParams(-1, 150);

            edit_name = new EditText(this);
			edit_name.LayoutParameters = size_of_edit;
			edit_name.Hint = $"Enter name of {name}";
			main.AddView(edit_name);

			edit_gender = new EditText(this);
			edit_gender.LayoutParameters = size_of_edit;
			edit_gender.Hint = "Enter gender (1 - male / 2 - female)";
            edit_gender.InputType = Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
            main.AddView(edit_gender);

			if (type != 3)
			{
				edit_energy = new EditText(this);
				edit_energy.LayoutParameters = size_of_edit;
				edit_energy.Hint = "Enter energy amount";
				edit_energy.InputType = Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
				main.AddView(edit_energy);

				edit_special = new EditText(this);
				edit_special.LayoutParameters = size_of_edit;
                edit_special.InputType = Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
				switch (type)
				{
					case 1:
						edit_special.Hint = "Enter the height of the bird";
						break;
					case 2:
                        edit_special.Hint = "Enter the depth of the fish";
                        break;
				}
				main.AddView(edit_special);
            }
			else
			{
				edit_milk = new EditText(this);
                edit_milk.LayoutParameters = size_of_edit;
                edit_milk.Hint = "Enter milk amount";
                edit_milk.InputType = Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
                main.AddView(edit_milk);
            }

            submit = new Button(this);
			submit.LayoutParameters = new LinearLayout.LayoutParams(-2,-2);
			submit.Text = "Submit";
			submit.TextSize = 20;
            submit.Click += Submit_Click;
			main.AddView(submit);
		}

        private void Submit_Click(object sender, EventArgs e)
        {
			if (ValidateForm(type))
			{ 
				var intent = new Intent();
				intent.PutExtra("type", type);
                intent.PutExtra("name", edit_name.Text);
                intent.PutExtra("Gender", edit_gender.Text);
                if (type < 3)
				{
					intent.PutExtra("Energy", edit_energy.Text);
					intent.PutExtra("Special", edit_special.Text);
                }
				else
				{
					intent.PutExtra("Milk", edit_milk.Text);
				}
                SetResult(Result.Ok, intent);
				Finish();
			}
        }

        private bool ValidateForm(int type)
        {
			bool result = edit_gender.Text == "1" || edit_gender.Text == "2";
			if (type != 3)
			{
				result = result && edit_energy.Text != "" && edit_special.Text != "";
			}
			else
			{
				result = result && edit_milk.Text != "";
			}

			return result;
        }

        private void Init()
		{
			dog = FindViewById<Button>(Resource.Id.Dog);
			fish = FindViewById<Button>(Resource.Id.Fish);
			bird = FindViewById<Button>(Resource.Id.Bird);
			main = FindViewById<LinearLayout>(Resource.Id.main);
		}

	}
}

