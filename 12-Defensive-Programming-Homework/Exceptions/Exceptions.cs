using System;
using System.Collections.Generic;
using System.Text;

class Exceptions
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (startIndex < 0 || arr.Length - 1 < startIndex)
        {
            throw new IndexOutOfRangeException("Start index must be in range [0...array length - 1].");
        }

        if ((startIndex + count) > arr.Length)
        {
            throw new ArgumentOutOfRangeException("Start index + count can not be greater than array length.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            return "Invalid count!";
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);
        }
        catch (IndexOutOfRangeException ior)
        {
            Console.WriteLine(ior.Message);
        }
        catch (ArgumentOutOfRangeException aor)
        {
            Console.WriteLine(aor.Message);
        }

        try
        {
            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));
        }
        catch (IndexOutOfRangeException ior)
        {
            Console.WriteLine(ior.Message);
        }
        catch (ArgumentOutOfRangeException aor)
        {
            Console.WriteLine(aor.Message);
        }

        try
        {
            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));
        }
        catch (IndexOutOfRangeException ior)
        {
            Console.WriteLine(ior.Message);
        }
        catch (ArgumentOutOfRangeException aor)
        {
            Console.WriteLine(aor.Message);
        }

        try
        {
            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));
        }
        catch (IndexOutOfRangeException ior)
        {
            Console.WriteLine(ior.Message);
        }
        catch (ArgumentOutOfRangeException aor)
        {
            Console.WriteLine(aor.Message);
        }

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        Console.WriteLine(CheckPrime(23) ? "23 is prime." : "23 is not prime");
        Console.WriteLine(CheckPrime(33) ? "33 is prime." : "33 is not prime");

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();

        if (peterAverageResult == -1)
        {
            Console.WriteLine("Can not calculate average result, because, " + 
                "this student has no exams.");
        }
        else
        {
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
