
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

namespace OOP_learn
{
	[Activity (Label = "DogActivity")]			
	public class DogActivity : Activity
	{
		ProgressBar pupEnergy, momEnergy;
        Dog mom, pup;
        Button ret, talk, walk, momBtn, pupBtn;
        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Dog);
			Init();
            AddClicks();
		}

        private void AddClicks()
        {
            ret.Click += Ret_Click;
            talk.Click += Talk_Click;
            walk.Click += Walk_Click;
            momBtn.Click += MomBtn_Click;
            pupBtn.Click += PupBtn_Click;
        }

        private void PupBtn_Click(object sender, EventArgs e)
        {
            pup.NurseFrom(mom);
            Updatebars();
        }

        private void MomBtn_Click(object sender, EventArgs e)
        {
            mom.NurseBaby(pup);
            Updatebars();
        }

        private void Updatebars()
        {
            pupEnergy.Progress = (int)pup.Energy;
            momEnergy.Progress = (int)mom.Energy;
        }

        private void Walk_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, pup.Move(), ToastLength.Short).Show();
        }

        private void Talk_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, pup.Talk(), ToastLength.Short).Show();
        }

        private void Ret_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Init()
        {
            ret = FindViewById<Button>(Resource.Id.ret);
            talk = FindViewById<Button>(Resource.Id.talkBtn);
            walk = FindViewById<Button>(Resource.Id.moveBtn);
            momBtn = FindViewById<Button>(Resource.Id.nurseFromMom);
            pupBtn = FindViewById<Button>(Resource.Id.nursePup);

            mom = new Dog("Mama dog", Animal.Genders.Female, 1000);
            pup = new Dog("Baby dog", Animal.Genders.Male);

            pupEnergy = FindViewById<ProgressBar>(Resource.Id.pupProgBar);
            momEnergy = FindViewById<ProgressBar>(Resource.Id.momProgBar);

            pupEnergy.Min = 0;
            momEnergy.Min = 0;

            momEnergy.Max = (int)mom.Energy;
            pupEnergy.Max = momEnergy.Max;

            momEnergy.Progress = momEnergy.Max;
        }
    }
}

