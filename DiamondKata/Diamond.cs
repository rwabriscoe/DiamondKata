using System;
using System.Text;
using System.Collections.Generic;

namespace DiamondKata
{
    public class Diamond
    {
        static void Main(string[] args)
        {
            ShowDiamond(args);

            PressEnterToExit();
        }

        private static string _diamondChar = string.Empty;

        public static string DiamondChar
        {
            get { return _diamondChar; }
            set
            {
                if (CharIsValid(value, false))
                {
                    _diamondChar = value.ToUpper();
                }
            }
        }

        static public bool ShowDiamond(string[] args)
        {
            bool success = false;

            if (args.Length > 0)
            {
                DiamondChar = args[0];

                if (!string.IsNullOrEmpty(DiamondChar))
                {
                    List<string> diamondRows = MakeDiamond();

                    if (diamondRows.Count > 0)
                    {
                        foreach (string row in diamondRows)
                        {
                            Console.WriteLine(row);
                        }

                        success = true;
                    }
                }
            }

            if (!success)
            {
                ReportInvalidEntry();
            }

            return success;
        }

        static void ReportInvalidEntry()
        {
            Console.WriteLine("Invalid entry");
            Console.WriteLine("Invoke as \"DiamondKata <parameter>\"");
            Console.WriteLine("Where parameter must be a single alphabetic character");
        }

        static void PressEnterToExit()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        static public bool CharIsValid(string diamondChar, bool checkCase=true)
        {
            bool success = false;

            if ((!String.IsNullOrEmpty(diamondChar)) && (diamondChar.Length == 1))
            {
                if (Char.IsLetter(diamondChar, 0))
                {
                    if ((checkCase == false) || (diamondChar == diamondChar.ToUpper()))
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        static public List<string> MakeDiamond()
        {
            List<string> diamondRows = new List<string>();

            if (CharIsValid(DiamondChar))
            {
                int diamondCharIx = DiamondChar[0] - 'A';

                for (char c='A'; c<=(char) DiamondChar[0]; ++c)
                {
                    diamondRows.Add(MakeDiamondRow(c.ToString()));
                }

                for (int i=diamondRows.Count-1; i>0; i--)
                {
                    diamondRows.Add(diamondRows[i-1]);
                }
            }
       
            return diamondRows;
        }

        static public string MakeDiamondRow(string rowChar)
        {
            var sbRow = new StringBuilder();

            if ((CharIsValid(DiamondChar)) && (CharIsValid(rowChar)))
            {
                int diamondCharIx = DiamondChar[0] - 'A';
                int rowCharIx = rowChar[0] - 'A';
                int gapLeft = diamondCharIx - rowCharIx;

                sbRow.Append(rowChar.PadLeft(gapLeft + 1));

                if (rowCharIx > 0)
                {
                    int gapCentre = (2 * rowCharIx) - 1;

                    sbRow.Append(rowChar.PadLeft(gapCentre + 1));
                }
            }

            return sbRow.ToString();
        }
    }
}
