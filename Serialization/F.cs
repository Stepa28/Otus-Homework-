using System.Text;

namespace Serialization;

public record F
{
    public int i1, i2, i3, i4, i5;
    
    public F(){}

    public F(string str)
    {
        var items = str.Split(',');
        i1 = IntValue(items[0]);
        i2 = IntValue(items[1]);
        i3 = IntValue(items[2]);
        i4 = IntValue(items[3]);
        i5 = IntValue(items[4]);
    }
    
    public F(byte[] arr)
    {
        if(arr.Length < 20)
            throw new Exception();

        i1 = BitConverter.ToInt32(arr, 0);
        i2 = BitConverter.ToInt32(arr, 4);
        i3 = BitConverter.ToInt32(arr, 8);
        i4 = BitConverter.ToInt32(arr, 12);
        i5 = BitConverter.ToInt32(arr, 16);
    }

    private int IntValue(string str)
    {
        var chip = str.Split('=');
        return int.Parse(chip.Last().Trim());
    }

    public static F Get() =>
        new()
        {
            i1 = 1
            , i2 = 2
            , i3 = 3
            , i4 = 4
            , i5 = 5
        };

    public byte[] Serialize()
    {
        using var res = new MemoryStream();
        res.Write(BitConverter.GetBytes(i1));
        res.Write(BitConverter.GetBytes(i2));
        res.Write(BitConverter.GetBytes(i3));
        res.Write(BitConverter.GetBytes(i4));
        res.Write(BitConverter.GetBytes(i5));
        return res.ToArray();
    }
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"{nameof(F)}:{{");
        PrintMembers(sb);
        sb.Append('}');
        return sb.ToString();
    }
}