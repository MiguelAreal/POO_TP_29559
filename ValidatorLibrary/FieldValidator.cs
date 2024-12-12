using System.Drawing;
using System.Windows.Forms;

namespace ValidationLibrary
{
    public static class FieldValidator
    {

        /// <summary>
        /// Valida um conjunto de controlos e altera a cor das labels associadas.
        /// Verifica se cada controlo tem um texto válido e ajusta a cor da label correspondente para vermelho ou preto.
        /// </summary>
        /// <param name="controls">Array de controlos a serem validados.</param>
        /// <param name="labels">Array de labels que indicam visualmente o estado de cada campo.</param>
        /// <returns>Retorna `true` se todos os controlos forem válidos, caso contrário, `false`.</returns>
        /// <exception cref="ArgumentException">Lançada quando o número de controlos e labels não é o mesmo.</exception>
        
        public static bool ValidateFields(Control[] controls, Label[] labels)
        {
            if (controls.Length != labels.Length)
            {
                throw new ArgumentException("Array de Controlos e Labels tem de ter o mesmo número de itens.");
            }

            bool isValid = true;

            for (int i = 0; i < controls.Length; i++)
            {
                isValid &= ValidateField(controls[i], labels[i]);
            }

            return isValid;
        }



        /// <summary>
        /// Valida um controlo individual e altera a cor da label associada dependendo do resultado.
        /// </summary>
        /// <param name="control">O controlo a ser validado.</param>
        /// <param name="label">A label associada ao controlo que terá a cor ajustada.</param>
        /// <returns>Retorna `true` se o campo for válido (não vazio), caso contrário, `false`.</returns>
        private static bool ValidateField(Control control, Label label)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                label.ForeColor = Color.Red; // Inválido
                return false;
            }
            else
            {
                label.ForeColor = Color.Black; // Válido
                return true;
            }
        }


        /// <summary>
        /// Valida um número de telefone e NIF para garantir que contenha apenas números e tenha exatamente 9 caracteres.
        /// Exibe mensagens de erro nas labels correspondentes em caso de falha na validação.
        /// </summary>
        /// <param name="number">String com texto de entrada a ser validado.</param>
        /// <param name="label">Label para alterar a cor e avisar utilizador.</param>
        /// <returns>Retorna <c>true</c> se for válido; caso contrário, <c>false</c>.</returns>
        public static bool ValidateNineDigits(string number, Label label)
        {
            // Verifica se a entrada tem exatamente 9 caracteres e se pode ser convertida para um número inteiro
            if (number.Length != 9 || !int.TryParse(number, out _))
            {
                label.ForeColor = Color.Red;
                return false;
            }
            else
            {
                // Se for válido, pode atualizar a cor da label para indicar sucesso (opcional)
                label.ForeColor = Color.Black;
                return true;
            }
            
        }


        /// <summary>
        /// Valida se a data selecionada em um controle <see cref="DateTimePicker"/> não é uma data futura.
        /// Caso a data seja futura, exibe uma mensagem de erro na <see cref="Label"/> correspondente.
        /// </summary>
        /// <param name="datePicker">O controlo <see cref="DateTimePicker"/> com a data a ser validada.</param>
        /// <param name="label">A <see cref="Label"/> onde será exibida a mensagem de erro caso a data seja inválida.</param>
        /// <returns>Retorna <c>true</c> se a data no <paramref name="datePicker"/> é válida (não futura); <c>false</c> se a data for futura.</returns>
        public static bool ValidateDate(DateTimePicker datePicker, Label label)
        {
            // Obtém a data selecionada no DateTimePicker
            DateTime selectedDate = datePicker.Value;

            // Verifica se a data selecionada é superior à data atual
            if (selectedDate > DateTime.Now)
            {
                label.ForeColor = Color.Red;
                return false;
            }
            return true;
        }



    }
}
