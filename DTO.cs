using System;
using System.Runtime.InteropServices;

namespace DTO;

// size is 24 byte header + 4 byte int + 4 byte padding + 8 byte reference
public class DataClass
{
    int num;

    string s;
}

// size is 8 byte reference + 4 byte int + 4 byte padding
public struct DataStruct
{
    string s;
    int num;
}

// size is 8 byte reference + 4 byte int + 4 byte int (same as previous one)
public struct DataStruct2
{

    string s;
    int num;
    int num2;
}

// same as before - compiler rearranges the fields.
public struct DataStruct3
{
    int num;
    string s;
    int num2;
}

// same as before - compiler packs the two bytes with two byte
public struct DataStruct4
{
    byte b1;
    byte b2;
    string s;
    int num2;
}

// takes 24 bytes because DateTime? is a value type of a boolean + 8 byte reference
[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct DataStruct5
{
    string s;
    DateTime? dt;
}