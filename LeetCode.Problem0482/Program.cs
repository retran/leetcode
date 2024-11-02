﻿using System.ComponentModel;
using System.Diagnostics;
using System.Text;

var solution = new Solution();

Debug.Assert(solution.LicenseKeyFormatting("5F3Z-2e-9-w", 4) == "5F3Z-2E9W");
Debug.Assert(solution.LicenseKeyFormatting("2-5g-3-J", 2) == "2-5G-3J");

public class Solution
{
    char ToUpper(char c)
    {
        if (c >= 'a' && c <= 'z')
            return (char)(c - 'a' + 'A');
        return c;
    }

    public string LicenseKeyFormatting(string s, int k)
    {
        var chars = s.ToCharArray();
        int count = 0;

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != '-')
            {
                count++;
            }
        }

        int currentGroupCount = count % k;
        if (currentGroupCount == 0)
        {
            currentGroupCount = k;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '-')
            {
                continue;
            }

            if (currentGroupCount == 0)
            {
                currentGroupCount = k;
                sb.Append('-');
            }

            sb.Append(ToUpper(chars[i]));
            currentGroupCount--;
        }

        return sb.ToString();
    }
}