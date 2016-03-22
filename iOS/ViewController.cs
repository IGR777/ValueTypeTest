using System;
		
using UIKit;
using System.Text;

namespace ValueTypeTest.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate {
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

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
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
