using System;
using System.IO;
public class Program
{
    static void JStart(string filename, List<string> libraries, bool MainClass, bool mainMethod)
    {
        string final = "";
        string includes = "";
        foreach (string s in libraries)
        {
            includes += $"import {s};";
        }
        includes += "\n";
        final += includes;
        if (MainClass && mainMethod)
            final += "public class Main {\n\tpublic static void main(String[] args) {\n\t\t\n\t}\n}";
        else if (MainClass && !mainMethod)
            final += "public class Main {\n\t\n}";
        File.WriteAllText(filename, final);
    }
    static void CStart(string fileName, List<string> libraries, bool mainMethod)
    {
        string final = "";
        string includes = "";
        foreach (string s in libraries)
        {
            includes += $"#include <{s}>\n";
        }
        includes += "\n";
        final += includes;
        if (mainMethod)
            final += "int main(int argc, const char* argv[])\n{\n\treturn 0;\n}";
        File.WriteAllText(fileName, final);
    }
    static void CSStart(string fileName, List<string> libraries, bool programClass, bool mainMethod)
    {
        string final = "";
        string includes = "";
        foreach (string s in libraries)
        {
            includes += $"using {s};\n";
        }
        includes += "\n";
        final += includes;
        if (programClass && mainMethod)
            final += "public class Program\n{\n\tpublic static void Main(string[] args)\n\t{\n\t\t\n\t}\n}";
        else if (programClass && !mainMethod)
            final += "public class Program\n{\n\t\n}";
        else if (mainMethod && !programClass)
            final += "// This program will not work because the main function is not inside of a class\npublic static void Main(string[] args)\n{\n\t\n}";
        File.WriteAllText(fileName, final);
    }
    static void Main(string[] args)
    {
        while (true)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("Welcome to Programming Helper!\nSelect an option:\n");
            Console.WriteLine("1) Write a C file\n2) Write a C# file\n3) Write a Java file");
            Console.Write("Choice: ");
            string ipt0 = Console.ReadLine();
            if (ipt0 == "1")
            {
                Console.Write("Please select a file path: ");
                string filePath = Console.ReadLine();
                Console.Write("How many libraries would you like to include: ");
                string ipt = Console.ReadLine();
                List<string> libraries = new List<string>();
                if (ipt.All(Char.IsDigit))
                {
                    int i = int.Parse(ipt);
                    for (int j = 0; j < i; ++j)
                    {
                        Console.Write("Write a library: ");
                        libraries.Add(Console.ReadLine());
                    }
                }
                Console.Write("Would you like to generate a main function? [Yn]: ");
                string yn = Console.ReadLine();
                if (yn == "n" || yn == "N")
                {
                    CStart(filePath, libraries, false);
                }
                else
                {
                    CStart(filePath, libraries, true);
                }
            } else if (ipt0 == "2")
            {
                Console.Write("Please select a file path: ");
                string filePath = Console.ReadLine();
                Console.Write("How many libraries would you like to include: ");
                string ipt = Console.ReadLine();
                List<string> libraries = new List<string>();
                if (ipt.All(Char.IsDigit))
                {
                    int i = int.Parse(ipt);
                    for (int j = 0; j < i; ++j)
                    {
                        Console.Write("Write a library: ");
                        libraries.Add(Console.ReadLine());
                    }
                }
                Console.Write("Would you like to generate a Program class? [Yn]: ");
                string yn = Console.ReadLine();
                if (yn == "n" || yn == "N") {}
                else
                {
                    Console.Write("Would you like to generate a Main function? [Yn]: ");
                    string mystr = Console.ReadLine();
                    if (mystr == "n" || mystr == "N") { CSStart(filePath, libraries, true, false); }
                    else
                        CSStart(filePath, libraries, true, true);
                }
            } else if (ipt0 == "3")
            {
                Console.Write("Please select a file path: ");
                string filePath = Console.ReadLine();
                Console.Write("How many libraries would you like to include: ");
                string ipt = Console.ReadLine();
                List<string> libraries = new List<string>();
                if (ipt.All(Char.IsDigit))
                {
                    int i = int.Parse(ipt);
                    for (int j = 0; j < i; ++j)
                    {
                        Console.Write("Write a library: ");
                        libraries.Add(Console.ReadLine());
                    }
                }
                Console.Write("Would you like to generate a Main class? [Yn]: ");
                string yn = Console.ReadLine();
                if (yn == "n" || yn == "N") {}
                else
                {
                    Console.Write("Would you like to generate a main function? [Yn]: ");
                    string mystr = Console.ReadLine();
                    if (mystr == "n" || mystr == "N") { JStart(filePath, libraries, true, false); }
                    else
                        CSStart(filePath, libraries, true, true);
                }
            }
        }
    }
}
