using System;

class Program
{
    static double CalculateTime(double distance, double velocity)
    {
        return distance / velocity;
    }

    static double CalculateTimeVertical(double distance, double gravity)
    {
        return Math.Sqrt(2 * distance / gravity);
    }

    static int GetPositiveIntegerInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int inputValue) && inputValue > 0)
            {
                return inputValue;
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid positive integer.");
            }
        }
    }

    static string GetMotionPathInput(string ballName, int distanceAB)
    {
        string prompt = $"Enter motion path of ball {ballName} (e.g., 'combination of 'S', 'U' and 'D' such as 'SSDDSSUUSS'): ";
        while (true)
        {
            Console.Write(prompt);
            string path = Console.ReadLine().ToUpper();

            if (path.Length == distanceAB && IsPathValid(path))
            {
                return path;
            }
            else
            {
                Console.WriteLine($"Error: The length of motion path for ball {ballName} should match the distance ({distanceAB}) and should contain only 'S', 'U', or 'D'.");
            }
        }
    }

    static bool IsPathValid(string path)
    {
        foreach (char segment in path)
        {
            if (segment != 'S' && segment != 'U' && segment != 'D')
            {
                return false;
            }
        }
        return true;
    }

    static void CountSegments(string path, ref int straightSegments, ref int downwardSegments, ref int upwardSegments)
    {
        foreach (char segment in path)
        {
            if (segment == 'S')
                straightSegments++;
            else if (segment == 'D')
                downwardSegments++;
            else if (segment == 'U')
                upwardSegments++;
        }
    }

    static void Main(string[] args)
    {
        int distanceAB = GetPositiveIntegerInput("Enter distance from A to B: ");
        string pathA = GetMotionPathInput("A", distanceAB);
        string pathB = GetMotionPathInput("B", distanceAB);

        // Mass of both balls (constant)
        double mass = 1.0;

        // Acceleration due to gravity (constant)
        double gravity = 9.81;

        // Initial velocity of both balls (constant)
        double initialVelocity = 10.0;

        int straightSegmentsA = 0;
        int downwardSegmentsA = 0;
        int upwardSegmentsA = 0;

        int straightSegmentsB = 0;
        int downwardSegmentsB = 0;
        int upwardSegmentsB = 0;

        CountSegments(pathA, ref straightSegmentsA, ref downwardSegmentsA, ref upwardSegmentsA);
        CountSegments(pathB, ref straightSegmentsB, ref downwardSegmentsB, ref upwardSegmentsB);

        double timeStraightA = CalculateTime(distanceAB * straightSegmentsA / pathA.Length, initialVelocity);
        //Time down and time up will use the same fuction 'CalculateTimeVertical' due to the constant intial velocity
        double timeDownA = CalculateTimeVertical(distanceAB * downwardSegmentsA / pathA.Length, gravity);
        double timeUpA = CalculateTimeVertical(distanceAB * upwardSegmentsA / pathA.Length, gravity);

        double timeStraightB = CalculateTime(distanceAB * straightSegmentsB / pathB.Length, initialVelocity);
        //Time down and time up will use the same fuction 'CalculateTimeVertical' due to the constant intial velocity
        double timeDownB = CalculateTimeVertical(distanceAB * downwardSegmentsB / pathB.Length, gravity);
        double timeUpB = CalculateTimeVertical(distanceAB * upwardSegmentsB / pathB.Length, gravity);

        double adjustedTotalTimeA = (timeStraightA + timeDownA + timeUpA) * Math.Sqrt(mass);
        double adjustedTotalTimeB = (timeStraightB + timeDownB + timeUpB) * Math.Sqrt(mass);

        if (adjustedTotalTimeA < adjustedTotalTimeB)
        {
            Console.WriteLine("Ball A reaches point B first.");
        }
        else if (adjustedTotalTimeB < adjustedTotalTimeA)
        {
            Console.WriteLine("Ball B reaches point B first.");
        }
        else
        {
            Console.WriteLine("Both balls reach point B at the same time.");
        }
    }
}
