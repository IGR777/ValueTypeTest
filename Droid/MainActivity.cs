using Android.App;
using Android.Widget;
using Android.OS;
using System.Text;
using System;

namespace ValueTypeTest.Droid
{
	[Activity (Label = "ValueTypeTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				Address a1 = new Address()
				{
					StreetName = "Some Street",
					StreetNumber = 1
				};
				Address a2 = new Address()
				{
					StreetName = "Other Street",
					StreetNumber = 2
				};

				AddressWithEquals a3 = new AddressWithEquals()
				{
					StreetName = "Some Street",
					StreetNumber = 1
				};
				AddressWithEquals a4 = new AddressWithEquals()
				{
					StreetName = "Other Street",
					StreetNumber = 2
				};

				var builder = new StringBuilder();
				builder.Append("Iterations,WithoutEquals,WithEquals\n");
				for (int i = 5; i < 10; i++)
				{
					int iterations = (int)Math.Pow(10.0, (double)i);
					bool b;

					DateTime start = DateTime.Now;
					for (int j = 0; j < iterations; j++)
					{
						b = a1.Equals(a2);
					}
					double finish1 = (DateTime.Now - start).TotalMilliseconds;
					start = DateTime.Now;
					for (int j = 0; j < iterations; j++)
					{
						b = a3.Equals(a4);
					}
					double finish2 = (DateTime.Now - start).TotalMilliseconds;

					builder.Append(String.Format("{0},{1},{2}\n", iterations,finish1,finish2));
				}
				Console.WriteLine (builder.ToString());
			};
		}
	}

	struct Address
	{
		public string StreetName { get; set; }
		public int StreetNumber { get; set; }
	}

	struct AddressWithEquals
	{
		public string StreetName { get; set; }
		public int StreetNumber { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (obj.GetType() != this.GetType()) return false;

			AddressWithEquals other = (AddressWithEquals)obj;
			return other.StreetName == this.StreetName &&
				other.StreetNumber == this.StreetNumber;
		}
	}
}


