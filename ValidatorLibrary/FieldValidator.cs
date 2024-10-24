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
    }
}
