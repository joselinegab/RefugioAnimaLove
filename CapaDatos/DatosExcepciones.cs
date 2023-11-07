using System;

namespace CapaDatos
{
    public class DatosExcepciones : ApplicationException
    {
        public DatosExcepciones(string men, Exception original)
            : base(men, original)
        {

        }
        public DatosExcepciones(string men)
            : base(men)
        {

        }
    }
}
