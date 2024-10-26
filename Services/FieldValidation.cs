using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Services
{
    internal class FieldValidation
    {
        private static (int,string) ValidateField(string value, string field, int minLength = 0, bool isCombobox = false, bool isNumeric = false)
        {
            if (string.IsNullOrEmpty(value))
                return (1, field);
            
            if (minLength > 0 && value.Length < minLength)
                return (2, field);

            if (isCombobox)
            {
                if (value.Equals("-1"))
                    return (3, field);
            }

            if (isNumeric) 
            {
                if(value.Equals("0"))
                    return (4, field);
            }

            return (0, "");
        }

        public static List<(int Key, string Value)> ValidateControls(Panel pnl)
        {
            List<(int Key, string Value)> result = [];
            (int, string) valid;

            foreach (var item in pnl.Controls)
            {
                if (item is TextBox txt)
                {
                    string field = txt.Name[3..];
                    int minLength = 0;

                    if (txt.Name.Equals("txtId"))
                    {
                        field = "CPF";
                        minLength = 11;
                    }

                    valid = ValidateField(txt.Text, field, minLength);
                    result.Add((valid.Item1, valid.Item2));
                    continue;
                }

                if (item is ComboBox cmb)
                {
                    string field = cmb.Name.Equals("cmbPos") ? "Cargo" : "Categoria";

                    valid = ValidateField(cmb.SelectedIndex.ToString(), field, isCombobox: true);
                    result.Add((valid.Item1, valid.Item2));
                    continue;
                }

                if (item is NumericUpDown num)
                {
                    string field = num.Name.Equals("numValue") ? "Valor" : "Qtde";

                    valid = ValidateField(num.Value.ToString(), field, isNumeric: true);
                    result.Add((valid.Item1, valid.Item2));
                    continue;
                }
            }

            return result;
        }

        public static string SetMessage(List<(int, string)> result)
        {
            string message = "";
            foreach (var (Key, Value) in result)
            {
                switch (Key)
                {
                    case 1:
                        message += $"• Campo \"{Value}\" não pode ser em branco! \n";
                        continue;
                    case 2:
                        message += $"• Campo \"{Value}\" deve possuir 11 digitos! \n";
                        continue;
                    case 3:
                        message += $"• Um valor deve ser selecionado para o campo \"{Value}\"! \n";
                        continue;
                    case 4:
                        message += $"• Campo \"{Value}\" deve possuir valor maior que 0! \n";
                        continue;
                    default:
                        break;
                }
            }

            return message;
        }
    }
}
