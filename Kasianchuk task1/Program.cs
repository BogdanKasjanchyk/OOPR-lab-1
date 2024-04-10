using System;
using System.IO;

public class Program
{
    int N;
    string filename;
    int trainNumber;
    string station;

    public void RW(string filename)
    {
        int startHours, startMinutes;
        int finishHours, finishMinutes;

        if (filename == "INFO.TXT")
        {
            Console.WriteLine("Trains amount: ");
            N = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Type trains number: ");
                trainNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Type destinate station: ");
                station = Console.ReadLine();

                Console.WriteLine("Type start time (hours): ");
                startHours = int.Parse(Console.ReadLine());

                Console.WriteLine("Type start time (minutes): ");
                startMinutes = int.Parse(Console.ReadLine());

                Console.WriteLine("Type finish time (hours): ");
                finishHours = int.Parse(Console.ReadLine());

                Console.WriteLine("Type finish time (minutes): ");
                finishMinutes = int.Parse(Console.ReadLine());

                using (StreamWriter book_file = new StreamWriter(filename, true))
                {
                    book_file.Write(trainNumber + " ");
                    book_file.Write(station + " ");

                    if (startMinutes < 10)
                    {
                        book_file.Write(startHours + ":0" + startMinutes + " ");
                    }
                    else
                    {
                        book_file.Write(startHours + ":" + startMinutes + " ");
                    }

                    if (finishMinutes < 10)
                    {
                        book_file.Write(finishHours + ":0" + finishMinutes + " ");
                    }
                    else
                    {
                        book_file.Write(finishHours + ":" + finishMinutes + " ");
                    }

                    int hours = finishHours - startHours;
                    int minutes = finishMinutes - startMinutes;

                    Console.WriteLine(hours + ":" + minutes + " time left");
                    book_file.Write(hours + ":" + minutes + " time left");

                    if (hours <= 10)
                    {
                        Console.WriteLine(" Less then 10 hours");
                        book_file.WriteLine(" Less then 10 hours");
                    }
                    else
                    {
                        Console.WriteLine(" More then 10 hours");
                        book_file.WriteLine(" More then 10 hours");
                    }

                    N--;
                }

            } while (N != 0);
        }
    }

    public void RD(string filename)
    {

        if (filename == "INFO.TXT")
        {
            using (StreamReader read_file = new StreamReader(filename))
            {
                string line;
                while ((line = read_file.ReadLine()) != null)
                {
                    if (line.Contains("Less then 10 hours"))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }

    static void Main()
    {
        Program program = new Program();

        Console.WriteLine("Choose file: INFO.DAT or INFO.TXT");

        program.filename = Console.ReadLine();

        Console.WriteLine("Edit OR Read");

        string func = Console.ReadLine();

        if (func == "Edit")
        {
            program.RW(program.filename);
        }
        if (func == "Read")
        {
            program.RD(program.filename);
        }
    }
}
