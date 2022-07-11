using System.Text;

namespace Token_generator.Models
{
    public class Generator
    {
        Random random = new Random();
        StringBuilder stringValue = new StringBuilder();
        public string GenerateToken()
        {
            
            string[] numValue = new string[]
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "0"
            };

            string[] alphValue = new string[]
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J",
                "K",
                "L",
                "M",
                "N",
                "O",
                "P",
                "Q",
                "R",
                "S",
                "T",
                "U",
                "V",
                "W",
                "X",
                "Y",
                "Z"
            };
            while (stringValue.Length < 5)
            {
                
                stringValue.Append(numValue[random.Next(0, 9)]);
                stringValue.Append(alphValue[random.Next(0, 25)]);
            }
            
            return stringValue.ToString();
        }
    }
}
