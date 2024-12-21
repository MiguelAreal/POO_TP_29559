using System.Drawing;
using System.Windows.Forms;

namespace ValidationLibrary
{
    /// <summary>
    /// Classe estática para validações de campos e manipulação visual associada.
    /// </summary>
    /// <remarks>
    /// A classe `FieldValidator` fornece métodos estáticos para validar diferentes tipos de campos em formulários,
    /// ajustando dinamicamente o estado visual de controles como labels para indicar erros ou sucesso. 
    /// Foi projetada para melhorar a experiência do utilizador, assegurando feedback visual consistente em aplicações Windows Forms.
    /// </remarks>
    public static class FieldValidator
    {
        #region ValidateFields

        /// <summary>
        /// Valida um conjunto de controles e ajusta a cor das labels associadas conforme a validade dos campos.
        /// </summary>
        /// <param name="controls">Array de controles a serem validados.</param>
        /// <param name="labels">Array de labels que indicam visualmente o estado de cada campo.</param>
        /// <param name="successColor">Cor opcional para os campos válidos (por padrão é preto).</param>
        /// <returns>Retorna <c>true</c> se todos os controles forem válidos, caso contrário, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Lançada quando o número de controles e labels não é o mesmo.</exception>
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

        #endregion

        #region ValidateField

        /// <summary>
        /// Valida um controle individual e ajusta a cor da label associada.
        /// </summary>
        /// <param name="control">O controle a ser validado.</param>
        /// <param name="label">A label associada ao controle que terá sua cor ajustada.</param>
        /// <param name="successColor">Cor a ser usada para campos válidos (opcional).</param>
        /// <returns>Retorna <c>true</c> se o campo for válido, caso contrário, <c>false</c>.</returns>
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

        #endregion

        #region ValidateNineDigits

        /// <summary>
        /// Valida um número de telefone ou NIF para garantir que contenha 9 dígitos.
        /// </summary>
        /// <param name="number">String com o texto de entrada a ser validado.</param>
        /// <param name="label">Label associada para alterar a cor e avisar o utilizador.</param>
        /// <param name="successColor">Cor opcional para campos válidos (por padrão é preto).</param>
        /// <returns>Retorna <c>true</c> se o número for válido, caso contrário, <c>false</c>.</returns>
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

        #endregion

        #region ValidateDate

        /// <summary>
        /// Valida se a data selecionada em um controle não é futura.
        /// </summary>
        /// <param name="datePicker">Controle <see cref="DateTimePicker"/> com a data a ser validada.</param>
        /// <param name="label">Label associada que exibirá a mensagem de erro caso a data seja inválida.</param>
        /// <returns>Retorna <c>true</c> se a data for válida (não futura), caso contrário, <c>false</c>.</returns>
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

        #endregion
    }
}
