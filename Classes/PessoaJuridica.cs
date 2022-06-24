


using System.Text.RegularExpressions;
using BE5.Interfaces;

namespace BE5.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {

        public string ?cnpj { get; set; }
        public string ?razao { get; set; }
        
        public override float PagarImposto(float rendimento)
        {                 
            if (rendimento <= 3500)
            {
                return rendimento * 0.03f;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                return rendimento * 0.05f;
            }
            else if (rendimento >3500 && rendimento <= 6000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }   
        }

//Verificar formato do CNPJ para validar pessoa Juridica xx.xxx.xx/0001-xx e xxxxxxxx0001-xx

        public bool ValidarCnpj(string cnpj)
        {
            if(Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if(cnpj.Length == 18)
                {
                    if(cnpj.Substring(11, 4) == "0001")
                    {
                        return true;
                    }
                }
                else if(cnpj.Length == 14)
                {
                    if(cnpj.Substring(8,4) == "0001")
                    {
                        return true;
                    }
                }  
            }
            return false;
        }
    }
}