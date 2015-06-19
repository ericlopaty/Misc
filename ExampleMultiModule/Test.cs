namespace Programming_CSharp
{
	using System;
	
	public class Test
	{
		// main will not load the shared assembly
		static void Main( )
		{
			Test t = new Test( );
			t.UseCS( );
			t.UseFraction( );
		}
		
		// calling this loads the myCalc assembly
		// and the mySharedAssembly assembly as well
		public void UseCS( )
		{
			ProgCS.myCalc calc = new ProgCS.myCalc( );
			Console.WriteLine("3+5 = {0}\n3*5 = {1}",
			calc.Add(3,5), calc.Mult(3,5));
		}
		
		// calling this adds the Fraction assembly
		public void UseFraction( )
		{
			ProgCS.Fraction frac1 = new ProgCS.Fraction(3,5);
			ProgCS.Fraction frac2 = new ProgCS.Fraction(1,5);
			ProgCS.Fraction frac3 = frac1.Add(frac2);
			Console.WriteLine("{0} + {1} = {2}",
			frac1, frac2, frac3);
		}
	}
}
