using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace RandomSs
{
    //Randomising strings
    public static class RandStringSs
    {
        public static string GenerateRandomString(int strLength, Boolean useless = true)
        // Returns a human readeable hex no of length strlength
        {
            // Get the current datetime as a seed
            long seed = DateTime.Now.Ticks;
            string randomHexString;

            // Initialize a random number generator with the seed
            Random random = new Random((int)(seed & 0xFFFFFFFFL) | (int)(seed >> 32));

            // Create a byte array to store the random bytes
            byte[] randomBytes = new byte[strLength];

            // Generate random bytes
            random.NextBytes(randomBytes);

            // Convert the byte array to a hexadecimal string
            if (useless)
            {
                randomHexString = BitConverter.ToString(randomBytes).Replace("-", "");
            }
            else
            {
                randomHexString = BitConverter.ToString(randomBytes); //.Replace("-", ""); //This is the difference
            }
            return randomHexString;
        }
    }
}

namespace MyStringFunctions
{
    public class MyStringFunctions
    {
        public static void FormatNumericTextBox(TextBox textBox, char fieldType) //Formats Text box from TextChanged property
        {
            textBox.TextChanged += (sender, e) =>
            {
                TextBox currentTextBox = (TextBox)sender;
                if (!string.IsNullOrEmpty(currentTextBox.Text))
                {
                    // 
                    string value = currentTextBox.Text; //.Replace(",", "").Replace(".", "");

                    switch (char.ToUpper(fieldType))
                    {
                        case 'D':
                            if (double.TryParse(value, out double dblNumber))
                            {
                                // Apply the formatting
                                currentTextBox.Text = string.Format("{0:#,##0.00}", dblNumber);
                            }
                            else
                            {
                                //currentTextBox = (TextBox)sender;
                            }
                            break;
                        case 'I':
                            if (int.TryParse(value, out int intNumber))
                            {
                                // Apply the formatting
                                currentTextBox.Text = string.Format("{0:#,##0}", intNumber);
                            }
                            else
                            {
                                //currentTextBox = (TextBox)sender;
                            }
                            break;
                        case 'L':
                            if (long.TryParse(value, out long longNumber))
                            {
                                // Apply the formatting
                                currentTextBox.Text = string.Format("{0:#,##0}", longNumber);
                            }
                            else
                            {
                                //currentTextBox = (TextBox)sender;
                            }
                            break;
                        default:
                            currentTextBox = (TextBox)sender; //Leave as it was
                            break;
                    }

                    currentTextBox.Select(currentTextBox.Text.Length, 0);
                }
            };
        }


        public static void FormatNumericTextBox(MaskedTextBox textBox, char fieldType) //Formats Masked Text box from TextChanged property
        {
            textBox.TextChanged += (sender, e) =>
            {
                MaskedTextBox currentTextBox = (MaskedTextBox)sender;
                if (!string.IsNullOrEmpty(currentTextBox.Text))
                {
                    // 
                    string value = currentTextBox.Text; //.Replace(",", "").Replace(".", "");

                    switch (char.ToUpper(fieldType))
                    {
                        case 'D':
                            if (double.TryParse(value, out double dblNumber))
                            {
                                // Apply the formatting
                                currentTextBox.Text = string.Format("{0:#,##0.00}", dblNumber);
                            }
                            else
                            {
                                //currentTextBox = (TextBox)sender;
                            }
                            break;
                        case 'I':
                            if (int.TryParse(value, out int intNumber))
                            {
                                // Apply the formatting
                                currentTextBox.Text = string.Format("{0:#,##0}", intNumber);
                            }
                            else
                            {
                                //currentTextBox = (TextBox)sender;
                            }
                            break;
                        case 'L':
                            if (long.TryParse(value, out long longNumber))
                            {
                                // Apply the formatting
                                currentTextBox.Text = string.Format("{0:#,##0}", longNumber);
                            }
                            else
                            {
                                //currentTextBox = (TextBox)sender;
                            }
                            break;
                        default:
                            currentTextBox = (MaskedTextBox)sender; //Leave as it was
                            break;
                    }

                    currentTextBox.Select(currentTextBox.Text.Length, 0);
                }
            };
        }

        public static void FormatNoChangeTextBox(MaskedTextBox textBox, char fieldType) //Formats Text box
        {
            MaskedTextBox currentTextBox = (MaskedTextBox)textBox;
            if (!string.IsNullOrEmpty(currentTextBox.Text))
            {
                // 
                string value = currentTextBox.Text; //.Replace(",", "").Replace(".", "");

                switch (char.ToUpper(fieldType))
                {
                    case 'D':
                        if (double.TryParse(value, out double dblNumber))
                        {
                            // Apply the formatting
                            currentTextBox.Text = string.Format("{0:#,##0.00}", dblNumber);
                        }
                        else
                        {
                            //currentTextBox = (TextBox)sender;
                        }
                        break;
                    case 'I':
                        if (int.TryParse(value, out int intNumber))
                        {
                            // Apply the formatting
                            currentTextBox.Text = string.Format("{0:#,##0}", intNumber);
                        }
                        else
                        {
                            //currentTextBox = (TextBox)sender;
                        }
                        break;
                    case 'L':
                        if (long.TryParse(value, out long longNumber))
                        {
                            // Apply the formatting
                            currentTextBox.Text = string.Format("{0:#,##0}", longNumber);
                        }
                        else
                        {
                            //currentTextBox = (TextBox)sender;
                        }
                        break;
                    default:
                        currentTextBox = (MaskedTextBox)textBox; //Leave as it was
                        break;
                }

                currentTextBox.Select(currentTextBox.Text.Length, 0);
            }

        }

        public static void FormatNoChangeTextBox(TextBox textBox, char fieldType, int significance = 2) //Formats Text box
        {
            TextBox currentTextBox = (TextBox)textBox;
            if (!string.IsNullOrEmpty(currentTextBox.Text))
            {
                // 
                string value = currentTextBox.Text; //.Replace(",", "").Replace(".", "");
                string digitDouble = "{0:#,##0";

                if (significance > 0)
                {
                    digitDouble += ".";
                    for (int x = 0; x < significance; x++)
                    {
                        digitDouble += "0";
                    }
                }

                digitDouble += "}";

                switch (char.ToUpper(fieldType))
                {
                    case 'D':
                        if (double.TryParse(value, out double dblNumber))
                        {
                            // Apply the formatting
                            currentTextBox.Text = string.Format(digitDouble, dblNumber);
                        }
                        else
                        {
                            //currentTextBox = (TextBox)sender;
                        }
                        break;
                    case 'I':
                        if (int.TryParse(value, out int intNumber))
                        {
                            // Apply the formatting
                            currentTextBox.Text = string.Format("{0:#,##0}", intNumber);
                        }
                        else
                        {
                            //currentTextBox = (TextBox)sender;
                        }
                        break;
                    case 'L':
                        if (long.TryParse(value, out long longNumber))
                        {
                            // Apply the formatting
                            currentTextBox.Text = string.Format("{0:#,##0}", longNumber);
                        }
                        else
                        {
                            //currentTextBox = (TextBox)sender;
                        }
                        break;
                    default:
                        currentTextBox = (TextBox)textBox; //Leave as it was
                        break;
                }

                currentTextBox.Select(currentTextBox.Text.Length, 0);
            }

        }
    }
}

