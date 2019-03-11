using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment1_S19
{
    class Program
    {
        public static void Main()
        {
            // Prime Numbers 
            int a = 5, b = 15;
            PrintPrimeNumbers(a, b);
            Console.WriteLine("\n");

            // Series
            int n1 = 5;
            double r1 = GetSeriesResult(n1);
            Console.WriteLine($"The sum of the series is: {r1}\n");

            // Print triangle with n rows using '*' character
            int n4 = 5;
            PrintTriangle(n4);
            Console.WriteLine("\n");

            // Create frequency table from array of values
            int[] arr = new int[] { 1, 3, 4, 3, 3, 1, 3, 2 };
            ComputeFrequency(arr);
            Console.WriteLine("\n");

            Console.ReadLine();


        }

        /*********************************************************************/
        // PrintPrimeNumbers(int x , int y)
        /**********************************************************************
            x – starting range, integer (int)
            y – ending range, integer (int)
        ----------------------------------------------------------------------- 
            summary:    This method prints all the prime numbers between x and y
            example:    5, 25 will print all the prime numbers between 5 and 25 
                        i.e. 5, 7, 11, 13, 17, 19, 23
            returns:    N/A
            return<T>:  VOID
        **********************************************************************/
        public static void PrintPrimeNumbers(int x, int y)
        {
            // We are going to use the Eratosthenes algorithm to calculate primes
            try
            {

                // Prime numbers are greater than one, thus we will start from 2
                if (x <= 1 || y <= 1)
                {
                    string message = "Only positive integers greater than 1 are allowed.";
                    Console.WriteLine(message);
                    
                }
                // Starting value must be less than the ending value
                else if (x > y)
                {
                    string message = "Starting value must be less than the ending value.";
                    Console.WriteLine(message);
                    
                }

                bool[] primes = new bool[y+1];

                // Boolean array is false by default
                // Index represents prime number
                // 0 and 1 is not prime so it is false;
                // Initialize 2 to N (= y) as true
                for (int i = 2; i <= y; i++)
                {
                    primes[i] = true;
                }


                // Implementing sieve of Eratosthenes
                for (int i = 2; i <= Math.Floor(Math.Sqrt(y)); i++)
                {
                    if (primes[i])
                    {
                        for (int j = 0; j < y; j++)
                        {
                            // strike out non-prime numbers k
                            int k = (i * i) + (j * i);

                            // Prevent out of range assignment
                            if (k <= y)
                            {
                                primes[k] = false;
                            }
                            
                        }
                    }
                }

                // print out primes in specified range
                for (int i = x; i <= y; i++)
                {

                    if (primes[i] == true)
                    {
                        Console.WriteLine("{0}", i);
                    }

                }


            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured while executing method PrintPrimeNumbers");
            }

        }

        /*********************************************************************/
        //  GetSeriesResult(int n)
        /**********************************************************************
            parameter:  n – number of terms of the series, integer (int)
        -----------------------------------------------------------------------
            summary:    This method computes the series 1/2 – 2!/3 + 3!/4 – 4!/5 --- n = 5    
                        where ! means factorial, i.e., 4! = 4*3*2*1 = 24. Round off the results to 
                        three decimal places. 
                        Hint: Odd terms are all positive whereas even terms are all negative.
                        Tip: Write a method to compute factorial of n, call it whenever required.
            returns:    result
            return<T>:  double
        **********************************************************************/
        public static double GetSeriesResult(int n)
        {
            try
            {
                // We want to make sure that n is a positive value greater than or equal to 2
                if (n < 2)
                {
                    string message = "Only n values greater than or equal to 2 is allowed.";
                    Console.WriteLine(message);
                    
                }
                else
                {
                    return RecurSum(n);
                }
                

                // Compute series
                double RecurSum (int a)
                {
                    if (a <= 2)
                    {
                        return Addend(a);
                    }
                    else
                    {
                        return Addend(a) + RecurSum(a-1) ;
                    }
                }

                // Compute factorial
                double Factorial(int m)
                {
                    if (m == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return m * Factorial(m - 1);
                    }
                    
                }

                // Compute addend
                double Addend(int p)
                {
                    return Math.Pow(-1, p) * (Factorial(p - 1) / p);
                }

                

            }
            catch
            {
                Console.WriteLine("Exception occured while executing method getSeriesResult.");
            }

            return 0;
        }

        /********************************************************************/
        //   PrintTriangle(uint n)
        /*********************************************************************
            n – number of lines for the pattern, integer (uint)
        ---------------------------------------------------------------------- 
            summary:    This method prints a triangle using '*' character.
                        For example n = 5 will display the output as: 

                            *
                           ***
                          *****
                         *******
                        *********
                        
            returns:    N/A
            return<T>:  void
        **********************************************************************/
        public static void PrintTriangle(int n)
        {
            try
            {

                
                int j = 0;
                // create the tree
                for (int i = 1; i <= n; i++)
                {
                    // total padding including the '*' leaves
                    Console.WriteLine(CreateStarBranch(n + j, i + j));
                    j++;
                }

                // generate tree branch
                string CreateStarBranch(int sp, int num)
                {
                    return new String('*', num).PadLeft(sp);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while executing method PrintTriangle.");
            }
        }

        /*********************************************************************/
        // ComputeFrequency()
        /**********************************************************************
            a – array of elements, integer (int)
        ----------------------------------------------------------------------- 
            summary:    This method computes the frequency of each element in the array
                        For example a = {1,2,3,2,2,1,3,2} will display the output as: 

                            Number	Frequency
                            1	    2
                            2	    4
                            3	    2

            returns:    N/A
            return<T>:  void
        **********************************************************************/
        public static void ComputeFrequency(int[] arr)
        {
            try
            {
                // We are going to store in a dictionary
                Dictionary<int, int> freqDict = new Dictionary<int, int>();

                // Unique values we are going to count
                int[] distinctArray = arr.Distinct().ToArray();
                Array.Sort(distinctArray);
                int distinctElements = distinctArray.Length;

                // Instantiate the frequency count array
                int[] frequencyArray = new int[distinctElements];

                // Adding key, value pairs to the dictionary
                for (int i = 0; i < distinctElements; i++)
                {
                    freqDict.Add(distinctArray[i], Array.FindAll(arr, a => a == distinctArray[i]).Count());
                }

                // Table layout
                const string col1 = "Value", col2 = "Frequency";
                Console.WriteLine("{0, 7}{1, 12}", col1, col2);

                foreach(KeyValuePair<int, int> items in freqDict)
                {
                    Console.WriteLine("{0, 3}{1, 8}",items.Key, items.Value);
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while executing method computeFrequency.");
            }
        }
    }
}