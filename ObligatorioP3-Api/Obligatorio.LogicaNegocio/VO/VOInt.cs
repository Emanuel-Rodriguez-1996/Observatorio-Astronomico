namespace Obligatorio.LogicaNegocio.VO
{
    public abstract record VOInt
    {
        public int Value { get; private set; }

        public VOInt(int value)
        {
            if (!Validar(value, out string errorMsg))
            {
                throw CreateInvalidValueException(value, errorMsg);
            }

            Value = value;
        }

        protected abstract Exception CreateInvalidValueException(int value, string errorMsg);

        protected virtual bool Validar(int value, out string errorMsg)
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
