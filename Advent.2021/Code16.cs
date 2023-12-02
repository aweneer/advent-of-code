using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code16
    {
        public static readonly Dictionary<int, string> operators = new()
        {
            { 0, "+" },
            { 1, "*" },
            { 2, "min" },
            { 3, "max" },
            { 4, "ltr" },
            { 5, ">" },
            { 6, "<" },
            { 7, "==" },
        };

        public static int FirstPuzzle(string[] input)
        {
            string binary = HexToBinary(input[0]);
            binary = binary.Substring(0, binary.Length - 3); // Trim last three zeroes
            Console.WriteLine(binary);

            long packetVersion = BinaryToDecimal(binary.Substring(0, 3));
            long packetTypeID = BinaryToDecimal(binary.Substring(3, 3));
            Console.WriteLine("Packet version: " + packetVersion);
            Console.WriteLine("Packet type ID: " + packetTypeID);
            string res = "ABCDEF";
            string packet = string.Empty;
            Console.WriteLine(binary);
            binary = binary.Substring(6);
            while (binary.Length > 0)
            {
                Console.WriteLine(binary);
                if (packetTypeID == 4)
                {

                    for (int i = 0; i < binary.Length / 5; i++)
                    {
                        Console.WriteLine(binary);

                        if (binary[0] == '1')
                        {
                            Console.WriteLine("if");
                            for (int j = 0; j < 4; j++)
                            {
                                packet += binary[1 + j];
                            }
                            binary = binary[5..];
                        }
                        else
                        {
                            Console.WriteLine("else");
                            for (int j = 0; j < 4; j++)
                            {
                                packet += binary[i + 1 + j];
                            }
                            binary = "";

                        }
                    }
                }
            }
            Console.WriteLine(packet);
            Console.WriteLine(BinaryToDecimal(packet));

            while (res.Length > 0)
            {
                Console.WriteLine(res);
                res = res.Substring(1, res.Length - 1);
            }

            for (int i = 6; i < binary.Length - 3; i++)
            {
                if (i % 5 == 0)
                    if (i % 5 == 1)
                    {
                        if (binary[i] == 1)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                packet += binary[i + 1 + j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                packet += binary[i + 1 + j];
                            }
                            packet = "";
                        }
                    }
            }
            Console.WriteLine(packet);
            Console.WriteLine(BinaryToDecimal(packet));

            Console.WriteLine();
            Console.WriteLine(BinaryToDecimal("000"));
            Console.WriteLine(BinaryToDecimal("001"));
            Console.WriteLine(BinaryToDecimal("010"));
            Console.WriteLine(BinaryToDecimal("011"));
            Console.WriteLine(BinaryToDecimal("100"));
            Console.WriteLine(BinaryToDecimal("101"));
            Console.WriteLine(BinaryToDecimal("110"));
            Console.WriteLine(BinaryToDecimal("111"));
            return -1;
        }

        public static int SecondPuzzle(string[] input)
        {
            Decoder decoder = new(input[7]);
            Console.WriteLine(decoder.HexTransmission);
            Console.WriteLine(decoder.BinTransmission);
            decoder.ProcessTransmission();
            return -1;
        }

        internal class Decoder
        {
            private string _hex;
            private string _bin;
            public string HexTransmission { get => _hex; set => _hex = value; }
            public string BinTransmission { get => _bin; set => _bin = value; }

            private List<Packet> packets = new();

            public Decoder(string transmission)
            {
                _hex = transmission;
                string binary = HexToBinary(transmission);
                _bin = binary[0..^3];
            }

            public void ProcessTransmission()
            {
                string message = new(BinTransmission);
                Console.WriteLine("L:" + message.Length);
                Console.WriteLine("Read version:");
                int version = BinaryToDecimal(ReadVersion(ref message));
                Console.WriteLine(version);
                Console.WriteLine("L:" + message.Length);
                Console.WriteLine("Read type:");
                int type = BinaryToDecimal(ReadType(ref message));
                Console.WriteLine(type);
                Console.WriteLine("L:" + message.Length);
                Console.WriteLine("Process type:");
                string packet = ProcessType(ref message, type);

                Console.WriteLine("L:" + message.Length);
                packets.Add(new(version, type, 3, 4));
                Console.WriteLine(packets[0].Info());
                Console.WriteLine();
                Console.WriteLine();
                string x = "110100010100101001000100100";
                Console.WriteLine(ProcessType(ref x, 4));
                Console.WriteLine(BinaryToDecimal("01010"));
                Console.WriteLine(BinaryToDecimal("00010100"));
            }

            private string ReadVersion(ref string message)
            {
                string version = message.Substring(0, 3);
                message = message[3..];
                return version;
            }

            private string ReadType(ref string message)
            {
                string type = message.Substring(0, 3);
                message = message[3..];
                return type;
            }

            private string ProcessType(ref string message, int type)
            {
                List<Packet> packets = new();
                int literalValue = 0;
                switch (type)
                {
                    case 4:
                        string literal = string.Empty;
                        bool lastGroup = false;
                        while (!lastGroup)
                        {
                            if (message[0] == '1')
                            {
                                literal += message[1..5];
                                message = message[5..];
                            }
                            else
                            {
                                Console.WriteLine(message[1..5]);
                                literal += message[1..5];
                                lastGroup = true;
                            }
                        }
                        literalValue = BinaryToDecimal(literal);
                        break;
                    default:

                        Console.WriteLine(message);
                        int number = 0;
                        if (message[0] == '0')
                        {
                            Console.WriteLine("0 = 15");
                            number = BinaryToDecimal(message[1..16]);
                            Console.WriteLine(" " + message[1..16]);
                            message = message[16..];
                            Console.WriteLine(message);
                            Console.WriteLine(number);
                        }
                        else
                        {
                            Console.WriteLine("11");
                            number = BinaryToDecimal(message[1..12]);
                            message = message[12..];
                            Console.WriteLine(message);
                            Console.WriteLine(number);
                        }
                        break;
                }
                Console.WriteLine(literalValue);
                return "";
            }


        }

        internal class Packet
        {
            private int _version;
            private int _typeID;
            private int _value = 0;
            private int _length = 0;
            public int Version { get => _version; set => _version = value; }
            public int TypeID { get => _typeID; set => _typeID = value; }
            public int Value { get => _value; set => _value = value; }
            public int Length { get => _length; set => _length = value; }

            private List<Packet> _children = new();
            public List<Packet> Children { get => _children; set => _children = value; }

            public Packet(int version, int typeID, int value, int length)
            {
                _version = version;
                _typeID = typeID;
                _value = value;
                _length = length;
            }

            public string Info()
            {
                return "Packet version: " + Version + ", Type ID: " + TypeID + ", Value: " + Value + ", Length: " + Length;
            }
        }


        public static string HexToBinary(string hex)
        {
            string binary = string.Empty;
            foreach (var symbol in hex)
            {
                binary += Convert.ToString(Convert.ToInt32(symbol.ToString(), 16), 2).PadLeft(4, '0');
            }
            return binary;
        }

        public static int BinaryToDecimal(string binary)
        {
            int dec = 0;
            double j = Convert.ToDouble(binary.Length - 1);
            for (int i = 0; i < binary.Length; i++)
            {
                dec += Int32.Parse(binary[i].ToString()) * Convert.ToInt32(Math.Pow(2.0, j--));
            }
            return dec;
        }
    }
}