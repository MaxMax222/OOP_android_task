
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
using static Java.Util.Jar.Attributes;

namespace OOP_learn
{
	[Activity (Label = "BirdActivity")]			
	public class BirdActivity : Activity
	{
        Bird bird;
        Button ret, talk, walk;
        TextView name;
        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Bird);
            Init();
            AddClicks();
        }

        private void AddClicks()
        {
            ret.Click += Ret_Click;
            talk.Click += Talk_Click;
            walk.Click += Walk_Click;
        }

        private void Walk_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, bird.Move(), ToastLength.Short).Show();
        }

        private void Talk_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, bird.Talk(), ToastLength.Short).Show();
        }

        private void Ret_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Init()
        {
            bird = new Bird("Sigma Crow", Animal.Genders.Male, 1000);

            ret = FindViewById<Button>(Resource.Id.ret);
            talk = FindViewById<Button>(Resource.Id.talkBtn);
            walk = FindViewById<Button>(Resource.Id.moveBtn);
            name = FindViewById<TextView>(Resource.Id.nameTxt);

            name.Text += bird.Name;
        }
    }
}

