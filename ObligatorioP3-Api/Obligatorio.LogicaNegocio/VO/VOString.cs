namespace Obligatorio.LogicaNegocio.VO
{
    public abstract record VOString
    {
        public string Value { get; private set; }

        public VOString(string value)
        {
         
            Value = value;
        }

        protected abstract Exception CreateInvalidValueException(string value, string errorMsg);

        protected virtual bool Validar(string value, out string errorMsg)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMsg = string.Empty;
                return false;
            }

            errorMsg = string.Empty;
            return true;
        }

        public String GetTString()
        {
            return Value.ToString();
        }
    }
}


