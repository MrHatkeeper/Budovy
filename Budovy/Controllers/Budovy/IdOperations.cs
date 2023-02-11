namespace Budovy.Controllers.Budovy;

public class IdOperations
{
    private const string IdCounter = "bin/Debug/net7.0/database/idCounter";
    public int GetIdAndAddOneToId(string typeOfId)
    {
        int output = new int();
        var file = File.ReadAllLines(IdCounter).ToList();
        switch (typeOfId)
        {
            case "b":
                output = int.Parse(file[0]) + 1;
                file[0] = output.ToString();
                break;
            case "r":
                output = int.Parse(file[1]) + 1;
                file[1] = output.ToString();
                break;
            case "t":
                output = int.Parse(file[2]) + 1;
                file[2] = output.ToString();
                break;
        }

        File.WriteAllLines(IdCounter, file);

        return output;
    }
}