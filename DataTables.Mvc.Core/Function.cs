using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTables.Mvc.Core
{
    public class Function
    {
        private string _dtFunctionName;
        private string[] _functionParams;
        private string _function;

        public Function(string dataTablesFunction, string[] parameters, string functionName)
        {
            _dtFunctionName = dataTablesFunction;
            _functionParams = parameters;
            _function = functionName;
        }

        public override string ToString()
        {
            // Create javascript
            var function = new StringBuilder();

            // Start script
            function.AppendFormat("\"{0}\": function({1}) {{{2}({1})}},", _dtFunctionName, String.Join(", ", _functionParams), _function);

            // Return script + required elements
            return function.ToString();
        }
    }
}
