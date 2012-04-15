using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTables.Mvc.Core
{
    public class Language
    {
        private string _emptyTable;
        private string _zeroRecords;
        private string _loadingRecords;
        private string _processing;

        public Language EmptyTable(string message)
        {
            _emptyTable = message;
            return this;
        }

        public Language ZeroRecords(string message)
        {
            _zeroRecords = message;
            return this;
        }

        public Language LoadingRecords(string message)
        {
            _loadingRecords = message;
            return this;
        }

        public Language Processing(string message)
        {
            _processing = message;
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("\"oLanguage\": { ");
            
            if (!String.IsNullOrWhiteSpace(_emptyTable))
                sb.AppendFormat("sEmptyTable: '{0}',", _emptyTable);

            if (!String.IsNullOrWhiteSpace(_zeroRecords))
                sb.AppendFormat("sZeroRecords: '{0}',", _zeroRecords);

            if (!String.IsNullOrWhiteSpace(_loadingRecords))
                sb.AppendFormat("sLoadingRecords: '{0}',", _loadingRecords);

            if (!String.IsNullOrWhiteSpace(_processing))
                sb.AppendFormat("sProcessing: '{0}',", _processing);

            //Close the column
            sb.Append(" },");

            return sb.ToString();//.Remove(sb.ToString().LastIndexOf(','), 1);
        }
    }
}
