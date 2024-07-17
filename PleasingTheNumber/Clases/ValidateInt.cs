using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class ValidateInt :IValidateInt
{
    public bool Validate(string str)
    {
        return int.TryParse(str, out _);
    }
}