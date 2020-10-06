using ConverterApp.Models;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your full name:");
            // get namer of user:
            var fullName = Console.ReadLine();

            // text to binary:
            string binaryValue = Models.Converter.StringToBinary2(fullName);
            Console.WriteLine(binaryValue);
            Console.WriteLine("Enter full name in binary:");
            var ascii = Console.ReadLine();

            // Binary to ascii:
            string textFromBinary = Converter.BinaryToString(binaryValue);
            Console.WriteLine($"Binary: {binaryValue}\nText: {textFromBinary}");

            
            // String to hex:
            string hexadecimalValue = Converter.StringToHex(fullName);
            Console.WriteLine("Text to Hexadecimal converter:");
            Console.WriteLine($"Text: {fullName}\nHEX: {hexadecimalValue}");


            // Hex to string:

            string textFromHex = Converter.HexToString(hexadecimalValue);
            Console.WriteLine("Hexadecimal to text Converter:");
            Console.WriteLine($"HEX: {hexadecimalValue}\nText: {textFromHex}");

            // text to base64
            string name = fullName;
            //Output the Base64 encoded string
            Console.WriteLine("Text to Base64:");
            string nameBase64Encoded = Converter.StringToBase64(name);
            Console.WriteLine(nameBase64Encoded);

            // base64 to text
            //Output the decoded Base64 string
            Console.WriteLine("Base 64 to text:");
            string nameBase64Decoded = Converter.Base64ToString(nameBase64Encoded);
            Console.WriteLine(nameBase64Decoded);


            //Convert the full name to a byte array and store in a variable named fullNameBytes
            byte[] fullNamebytes = Encoding.ASCII.GetBytes(fullName);




            string fullNamestr = Encoding.UTF8.GetString(fullNamebytes);  // convert byte to string
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 }; 
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            Models.Encrypter encrypter = new Encrypter(fullNamestr, cipher, encryptionDepth);

            Console.WriteLine("Encryption and Decryption:");
            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(fullNamestr, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");



        }
    }
}

