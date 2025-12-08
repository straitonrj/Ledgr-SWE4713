using System.ComponentModel;

namespace LedgrLogic;

public class Filter
{
    public static async Task<List<string>> CoAList(List<string> CoA, string Category, string SubCategory, string NS, string accNumFromParam, string accNumToParam, string amountMinParam, string amountMaxParam, string search)
    {
        
        bool checkCat = Category != string.Empty;
        bool checkSubCategory = SubCategory != string.Empty;
        bool checkNS = NS != string.Empty;
        bool checkFrom = accNumFromParam != string.Empty;
        bool checkTo = accNumToParam != string.Empty;
        bool checkMin = amountMinParam != string.Empty;
        bool checkMax = amountMaxParam != string.Empty;
        bool checkSearch = search != string.Empty;
        // Convert to Usable format
        try
        {
            int accountNumFrom = -1;
            int accountNumTo = -1;
            int accountNumMin = -1;
            int accountNumMax = -1;
            
            if (checkFrom){accountNumFrom = Convert.ToInt32(accNumFromParam);}
            if (checkTo){accountNumTo = Convert.ToInt32(accNumToParam);}
            if (checkMin){accountNumMin = Convert.ToInt32(amountMinParam);}
            if (checkMax){accountNumMax = Convert.ToInt32(amountMaxParam);}

            if (NS == "Debit")
            {
                NS = "L";
            }
            else if (NS == "Credit")
            {
                NS = "R";
            }
            else
            {
                NS = "R";
            }
            
            List<string> filtered = new List<string>();
            
            Console.WriteLine("Start of filter");
            // Accounts have fifteen fields
            for (int i = 0; i < CoA.Count; i += 15)
            {
                if ((checkCat && CoA[i + 4] == Category) || !checkCat)
                {
                    Console.WriteLine($"filter cat: {CoA[4]}");
                    if ((checkSubCategory && CoA[i + 5] == SubCategory) || !checkSubCategory)
                    {
                        Console.WriteLine("filter subcat");
                        if ((checkNS && CoA[i + 3] == NS) || !checkNS)
                        {
                            if ((checkFrom && Convert.ToInt32(CoA[i + 0]) >= accountNumFrom) || !checkFrom)
                            {
                                if (checkTo && Convert.ToInt32(CoA[i + 0]) <= accountNumTo || !checkTo)
                                {
                                    if (checkMin && Convert.ToInt32(CoA[i + 9]) >= accountNumMin || !checkMin)
                                    {
                                        if (checkMax && Convert.ToInt32(CoA[i + 9]) <= accountNumMax || !checkMax)
                                        {
                                            if (checkSearch && CoA[i + 1].Contains(search) || !checkSearch)
                                            {
                                                filtered.Add(CoA[i]);
                                                filtered.Add(CoA[i + 1]);
                                                filtered.Add(CoA[i + 2]);
                                                filtered.Add(CoA[i + 3]);
                                                filtered.Add(CoA[i + 4]);
                                                filtered.Add(CoA[i + 5]);
                                                filtered.Add(CoA[i + 6]);
                                                filtered.Add(CoA[i + 7]);
                                                filtered.Add(CoA[i + 8]);
                                                filtered.Add(CoA[i + 9]);
                                                filtered.Add(CoA[i + 10]);
                                                filtered.Add(CoA[i + 11]);
                                                filtered.Add(CoA[i + 12]);
                                                filtered.Add(CoA[i + 13]);
                                                filtered.Add(CoA[i + 14]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return filtered;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return CoA;
        }
        
        
    }
}