using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Identificador (deve ser um valor único gerado automaticamente);
    Descrição (texto);
    Valor (número decimal positivo);
    Tipo (despesa/receita);
    Categoria: restringir a utilização de categorias conforme o valor definido no campo finalidade. Ex.: se o tipo da transação é despesa, não poderá utilizar uma categoria que tenha a finalidade receita.
    Pessoa (identificador da pessoa do cadastro anterior);
*/

namespace Domain.Entities
{
    public class Transactions
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public double Value { get; set; }
        public UniqueExpenseType ExpenseType { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; } = null!;
        public int UserId { get; set; }
        public Users User { get; set; } = null!;
    }
}
