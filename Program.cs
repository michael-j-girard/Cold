/// When Testing Locally prior to KAtis Submission Do Define
/// On Submit To Katis Website Comment out the #define NOKATIS
#define NOTREADYTOUPLOADTOKATIS
using System;
using System.IO;
using System.Collections.Generic;

public class KatiseStub
{
  
    static StreamWriter writer = null;
    /// <summary>
    /// Main allows arg[0] to be input file. If not Defined it will default to "..\..\Input.Txt"
    ///             arg[1] to be outputile. If not existing it defaults to "..\..\Output.txt" 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static int Main(string[] args)
    {

        if (args.Length == 2)
            OpenNoKatis(args[0], args[1]);
        else
            OpenNoKatis();

        List<string> lstInputLines = new List<string>();
        
        
        string line;
        while ((line = Console.ReadLine()) != null)
         {
            lstInputLines.Add(line);       
         }
        SolveKatisFromInput(lstInputLines);
        CloseNoKatis();
         return 0;
    }
    /// <summary>
    /// Okay Solve your Katis Input Now
    /// This in current status will simply echo to output
    /// delete the WriteLine and solve and write your answer(s)
    /// </summary>
    /// <param name="lstInputLines"></param>
    private static void SolveKatisFromInput(List<string> lstInputLines)
    {

        // This is Really an Echo of input You are to Process Each line and 
      
        
        const long MAX_TEMP = 1000000;
        const long MIN_TEMP = -MAX_TEMP;
        

        var nTemps = Int64.Parse(lstInputLines[0]);

        string str = lstInputLines[1];
        var Temps = str.Split(new char[] { ' ' });    
        long temperature;
        int cntBelow = 0;
        foreach (var s in Temps)
        {
           if (Int64.TryParse(s, out temperature))
           {
               if (temperature >= MIN_TEMP && temperature <= MAX_TEMP)
                   if (temperature < 0)
                       cntBelow++;
           }
        }
        Console.WriteLine(cntBelow.ToString());
    }
 
    

    /// <summary>
    /// Utilty Files 
    /// </summary>
    /// <param name="arg0">Optional with default of Input.txt</param>
    /// <param name="arg1">Optional with a default of Output.txt</param>
    private static void OpenNoKatis(string arg0 = @"..\..\Input.txt", 
                                    string arg1 = @"..\..\Output.txt")
    {
#if NOTREADYTOUPLOADTOKATIS

        try
        {
            
            writer = new StreamWriter(arg1);
            // Redirect standard output from the console to the output file.
            Console.SetOut(writer);
            // Redirect standard input from the console to the input file.
            if (!File.Exists(arg0))
            { 
                var f = File.CreateText(arg0);
                f.WriteLine("EMPTY INPUTFILE");
                f.Flush();
                f.Close();         
                Console.WriteLine($"It would be better if You put some input in {arg0}");

            }

            Console.SetIn(new StreamReader(arg0));
        }
        catch (IOException e)
        {
            TextWriter errorWriter = Console.Error;
            errorWriter.WriteLine(e.Message);     
        }
#endif
    }

    private static void CloseNoKatis()
    {
#if NOTREADYTOUPLOADTOKATIS
        writer.Close();
        // Recover the standard output stream so that a 
        // completion message can be displayed.
        StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
#endif
    }
}



