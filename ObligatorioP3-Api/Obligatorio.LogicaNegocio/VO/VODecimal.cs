namespace Obligatorio.LogicaNegocio.VO
{
    public abstract record VODecimal
    {
        public decimal Value { get; private set; }
        public VODecimal(decimal value)
        {
            if (!IsAllowedValue(value, out string errorMsg))
            {
                throw CreateInvalidValueException(value, errorMsg);
            }

            Value = value;
        }

        protected abstract Exception CreateInvalidValueException(decimal value, string errorMsg);

        protected virtual bool IsAllowedValue(decimal value, out string errorMsg)
        {
            if (value < 0)
            {
                errorMsg = "El valor no puede ser negativo.";
                return false;
            }

            errorMsg = string.Empty;
            return true;
        }

    }
}
