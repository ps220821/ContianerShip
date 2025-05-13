using ContainerShip.Classes.Containers;
using ContainerShip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Classes
{
    public class UrlGenerator
    {
        public static string GetUrl(Ship ship)
        {
            string url = $"https://app6i872272.luna.fhict.nl/index.html?length={ship.Lenght}&width={ship.Width}";

            List<string> stackRows = new List<string>();
            List<string> weightRows = new List<string>();

            for (int row = 0; row < ship.Width; row++)  // Iterate over Width for rows
            {
                List<string> stackColumns = new List<string>();
                List<string> weightColumns = new List<string>();

                for (int column = 0; column < ship.Lenght; column++)  // Iterate over Length for columns
                {
                    IStack stack = ship.Grid[column, row]; // Corrected access: [column, row]
                    if (stack.Containers.Any())
                    {
                        stackColumns.Add(string.Join("-", stack.Containers.Select(c => ((int)c.Containertype).ToString())));
                        weightColumns.Add(string.Join("-", stack.Containers.Select(c => c.Weight.ToString())));
                    }
                }

                // Only add the row if it's not empty
                if (stackColumns.Any())
                {
                    stackRows.Add(string.Join(",", stackColumns));
                    weightRows.Add(string.Join(",", weightColumns));
                }
            }

            // Only add to URL if there is at least one stack row
            if (stackRows.Any())
            {
                url += $"&stacks={string.Join("/", stackRows)}";
            }
            if (weightRows.Any())
            {
                url += $"&weights={string.Join("/", weightRows)}";
            }

            return url;
        }
    }
}
