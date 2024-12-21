using System.Drawing;
using System.Windows.Forms;

namespace ValidationLibrary
{
    /**
    * @class FieldValidator
    * @brief Classe estática para validações de campos e manipulação visual associada.
    * 
    * A classe `FieldValidator` fornece métodos estáticos para validar diferentes tipos de campos em formulários,
    * ajustando dinamicamente o estado visual de controles como labels para indicar erros ou sucesso. 
    * Foi projetada para melhorar a experiência do utilizador, assegurando feedback visual consistente em aplicações Windows Forms.
    * 
    * @author Miguel Areal
    * @date 12/2024
    */
    public static class FieldValidator
    {
        /**
        * @brief Valida um conjunto de controles e ajusta a cor das labels associadas conforme a validade dos campos.
        * 
        * Este método verifica se cada controle possui texto válido e ajusta a cor da label correspondente para 
        * vermelho ou para a cor de sucesso especificada.
        * 
        * @param controls Array de controles a serem validados.
        * @param labels Array de labels que indicam visualmente o estado de cada campo.
        * @param successColor Cor opcional para os campos válidos (por padrão é preto).
        * @return Retorna `true` se todos os controles forem válidos, caso contrário, `false`.
        * @exception ArgumentException Lançada quando o número de controles e labels não é o mesmo.
        */
        public static bool ValidateFields(Control[] controls, Label[] labels, Color successColor = default)
        {
            if (successColor == default)
            {
                successColor = Color.Black;
            }

            if (controls.Length != labels.Length)
            {
                throw new ArgumentException("Array de controles e labels deve ter o mesmo número de itens.");
            }

            bool isValid = true;

            for (int i = 0; i < controls.Length; i++)
            {
                isValid &= ValidateField(controls[i], labels[i], successColor);
            }

            return isValid;
        }

        /**
        * @brief Valida um controle individual e ajusta a cor da label associada.
        * 
        * Este método verifica se o texto de um controle não está vazio. Caso esteja, altera a cor da label para vermelho.
        * Caso contrário, utiliza a cor de sucesso especificada.
        * 
        * @param control O controle a ser validado.
        * @param label A label associada ao controle que terá sua cor ajustada.
        * @param successColor Cor a ser usada para campos válidos (opcional).
        * @return Retorna `true` se o campo for válido, caso contrário, `false`.
        */
        private static bool ValidateField(Control control, Label label, Color successColor)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                label.ForeColor = Color.Red;
                return false;
            }
            else
            {
                label.ForeColor = successColor;
                return true;
            }
        }

        /**
        * @brief Valida um número de telefone ou NIF para garantir que contenha 9 dígitos.
        * 
        * Este método verifica se o texto possui exatamente 9 caracteres e se é composto apenas por números.
        * Em caso de falha, a label associada é ajustada para exibir um aviso em vermelho.
        * 
        * @param number String com o texto de entrada a ser validado.
        * @param label Label associada para alterar a cor e avisar o utilizador.
        * @param successColor Cor opcional para campos válidos (por padrão é preto).
        * @return Retorna `true` se o número for válido, caso contrário, `false`.
        */
        public static bool ValidateNineDigits(string number, Label label, Color successColor = default)
        {
            if (successColor == default)
            {
                successColor = Color.Black;
            }

            if (number.Length != 9 || !int.TryParse(number, out _))
            {
                label.ForeColor = Color.Red;
                return false;
            }
            else
            {
                label.ForeColor = successColor;
                return true;
            }
        }

        /**
        * @brief Valida se a data selecionada em um controle não é futura.
        * 
        * Este método verifica se a data selecionada no `DateTimePicker` é anterior ou igual à data atual.
        * Em caso de falha, a label associada é ajustada para exibir um aviso em vermelho.
        * 
        * @param datePicker Controle `DateTimePicker` com a data a ser validada.
        * @param label Label associada que exibirá a mensagem de erro caso a data seja inválida.
        * @return Retorna `true` se a data for válida (não futura), caso contrário, `false`.
        */
        public static bool ValidateDate(DateTimePicker datePicker, Label label)
        {
            DateTime selectedDate = datePicker.Value;

            if (selectedDate > DateTime.Now)
            {
                label.ForeColor = Color.Red;
                return false;
            }
            return true;
        }
    }
}
