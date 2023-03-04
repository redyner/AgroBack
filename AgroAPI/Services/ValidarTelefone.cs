using System.Text.RegularExpressions;

namespace AgroAPI.Services
{
    public static class ValidarTelefone
    {
        public static bool IsTelefone(string telefone)
        {
            //exemplos de formatos aceitos (31) 98888-8888 ; 31 98888888 ; 31988888888

            var regexTelefone = new Regex(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");

            if (!regexTelefone.IsMatch(telefone))
                return false;

            return true;
        }
    }
}
