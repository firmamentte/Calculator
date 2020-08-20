
namespace Calculator.BLL.DataContract
{
    public class CalculateReq
    {
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string MathSign { get; set; }

        public float GetNumber1
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Number1))
                {
                    return float.Parse(Number1.Replace('.', ',').Replace(" ", ""));
                }
                else
                {
                    return float.MinValue;
                }
            }
        }

        public float GetNumber2
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Number1))
                {
                    return float.Parse(Number2.Replace('.', ',').Replace(" ", ""));
                }
                else
                {
                    return float.MinValue;
                }
            }
        }
    }
}
