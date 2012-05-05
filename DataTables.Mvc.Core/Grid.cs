using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using DataTables.Mvc.Core.Enum;

namespace DataTables.Mvc.Core
{
    public class Grid : IHtmlString
    {
        private List<Column> _columns;
        private string _selector;
        private string _aData;
        private string _ajaxSource;
        private bool? _serverSide;
        private bool? _processing;
        private bool? _paginate;
        private bool? _changePageLength;
        private int _pageLength;
        private int[] _lengthMenu;
        private bool? _filter;
        private bool? _sort;
        private bool? _showInfo;
        private bool? _autoWidth;
        private bool? _saveState;
        private int _cookieDuration;
        private string _cookiePrefix;
        private List<KeyValuePair<int, SortDirection>> _sorting;
        private string _rowCreated;
        private string _paginationType;
        private ServerMethod? _serverMethod;
        private string _ajaxDataProperty;
        private Language _language;
        private string _dom;
        private bool? _hideHeaders;
        private string _serverData;

        public Grid(string selector)
        {
            _selector = selector;
            _columns = new List<Column>();
            _sorting = new List<KeyValuePair<int, SortDirection>>();
        }

        public Grid AddColumn(Column column)
        {
            _columns.Add(column);
            return this;
        }

        public Grid AData(string aData)
        {
            _aData = aData;
            return this;
        }

        public Grid AjaxSource(string ajaxSource)
        {
            _ajaxSource = ajaxSource;
            return this;
        }

        public Grid ServerSide(bool serverSide)
        {
            _serverSide = serverSide;
            return this;
        }

        public Grid Processing(bool showProcessingMessage)
        {
            _processing = showProcessingMessage;
            return this;
        }

        public Grid Paginate(bool paginate)
        {
            _paginate = paginate;
            return this;
        }

        public Grid ChangePageLength(bool changePageLength)
        {
            _changePageLength = changePageLength;
            return this;
        }

        public Grid PageLength(int pageLength)
        {
            _pageLength = pageLength;
            return this;
        }

        public Grid LengthMenu(int[] array)
        {
            _lengthMenu = array;
            return this;
        }

        public Grid Filter(bool filter)
        {
            _filter = filter;
            return this;
        }

        public Grid Sort(bool sort)
        {
            _sort = sort;
            return this;
        }

        public Grid ShowInfo(bool showInfo)
        {
            _showInfo = showInfo;
            return this;
        }

        public Grid AutoWidth(bool autoWidth)
        {
            _autoWidth = autoWidth;
            return this;
        }

        public Grid SaveState(bool saveState)
        {
            _saveState = saveState;
            return this;
        }

        public Grid CookieDuration(int cookieDuration)
        {
            _cookieDuration = cookieDuration;
            return this;
        }

        public Grid CookiePrefix(string cookiePrefix)
        {
            _cookiePrefix = cookiePrefix;
            return this;
        }

        public Grid RowCreatedCallback(string callback)
        {
            _rowCreated = callback;
            return this;
        }

        public Grid PaginationType(string type)
        {
            _paginationType = type;
            return this;
        }

        public Grid ServerMethod(ServerMethod serverMethod)
        {
            _serverMethod = serverMethod;
            return this;
        }

        public Grid AjaxDataProperty(string property)
        {
            _ajaxDataProperty = property;
            return this;
        }

        public Grid AddSorting(int columnNumber, SortDirection direction = SortDirection.Asc)
        {
            _sorting.Add(new KeyValuePair<int, SortDirection>(columnNumber, direction));

            return this;
        }

        public Grid Language(Language language)
        {
            _language = language;

            return this;
        }

        public Grid Dom(string dom)
        {
            _dom = dom;

            return this;
        }

        public Grid HideHeaders(bool hideHeaders)
        {
            _hideHeaders = hideHeaders;

            return this;
        }

        public Grid ServerData(string function)
        {
            _serverData = function;
            return this;
        }

        /// <summary>
        /// Creates and returns the javascript to initialize the grid
        /// </summary>
        /// <returns></returns>
        public string RenderJavascript()
        {
            var dataTable = new StringBuilder();
            dataTable.AppendLine("$(document).ready(function () {");
            dataTable.AppendLine("oTable = $('" + _selector + "').dataTable({");

            if (!String.IsNullOrWhiteSpace(_aData))
                dataTable.AppendLine(String.Format("\"aaData\": {0},", _aData));

            if (!String.IsNullOrWhiteSpace(_ajaxSource))
                dataTable.AppendLine(String.Format("\"sAjaxSource\": \"{0}\",", _ajaxSource));

            if (_serverSide.HasValue)
                dataTable.AppendLine(String.Format("\"bServerSide\": {0},", _serverSide.ToString().ToLower()));

            if (!String.IsNullOrWhiteSpace(_ajaxDataProperty))
                dataTable.AppendLine(String.Format("\"sAjaxDataProp\": \"{0}\",", _ajaxDataProperty));

            if (_processing.HasValue)
                dataTable.AppendLine(String.Format("\"bProcessing\": {0},", _processing.ToString().ToLower()));

            if (_paginate.HasValue)
                dataTable.AppendLine(String.Format("\"bPaginate\": {0},", _paginate.ToString().ToLower()));

            if (_changePageLength.HasValue)
                dataTable.AppendLine(String.Format("\"bLengthChange\": {0},", _changePageLength.ToString().ToLower()));

            if (_pageLength > 0)
                dataTable.AppendLine(String.Format("\"iDisplayLength\": {0},", _pageLength));

            if (_lengthMenu != null)
                dataTable.AppendLine(String.Format("\"aLengthMenu\": [{0}],", String.Join(", ", _lengthMenu)));

            if (_filter.HasValue)
                dataTable.AppendLine(String.Format("\"bFilter\": {0},", _filter.ToString().ToLower()));

            if (_sort.HasValue)
                dataTable.AppendLine(String.Format("\"bSort\": {0},", _sort.ToString().ToLower()));

            if (_showInfo.HasValue)
                dataTable.AppendLine(String.Format("\"bInfo\": {0},", _showInfo.ToString().ToLower()));

            if (_autoWidth.HasValue)
                dataTable.AppendLine(String.Format("\"bAutoWidth\": {0},", _autoWidth.ToString().ToLower()));

            if (!String.IsNullOrWhiteSpace(_paginationType))
                dataTable.AppendLine(String.Format("\"sPaginationType\": \"{0}\",", _paginationType));

            if (_saveState.HasValue)
                dataTable.AppendLine(String.Format("\"bStateSave\": {0},", _saveState.ToString().ToLower()));

            if (_cookieDuration > 0)
                dataTable.AppendLine(String.Format("\"iCookieDuration\": {0},", _cookieDuration));

            if (!String.IsNullOrWhiteSpace(_cookiePrefix))
                dataTable.AppendLine(String.Format("\"sCookiePrefix\": \"{0}\",", _cookiePrefix));

            //Set the sorting order
            if (_sorting != null && _sorting.Count > 0)
                dataTable.AppendLine(String.Format("\"aaSorting\": {0},", GetSortingArray()));

            //Use GET or POST if assigned
            if (!String.IsNullOrWhiteSpace(_ajaxSource))
            {
                if (_serverMethod != null)
                    dataTable.AppendLine(String.Format("\"sServerMethod\": \"{0}\",", _serverMethod));
            }

            if (!String.IsNullOrWhiteSpace(_rowCreated))
                dataTable.AppendFormat("fnCreatedRow: function(row, aData, index) {{{0}}},", _rowCreated);

            if (!String.IsNullOrWhiteSpace(_dom))
                dataTable.AppendLine(String.Format("\"sDom\": \"{0}\",", _dom));

            if (_language != null)
            {
                dataTable.AppendLine(_language.ToString());
            }

            if (!String.IsNullOrWhiteSpace(_serverData))
                dataTable.AppendFormat("fnServerData: function(sSource, aoData, fnCallback) {{{0}}},", _serverData);

            //Handle all the columns
            //Open the column array
            if (_columns.Count > 0)
            {
                dataTable.AppendLine("\"aoColumns\": [");
                foreach (var column in _columns)
                {
                    if (column == null)
                    {
                        dataTable.AppendLine("null,");    
                    }

                    else
                        dataTable.AppendLine(column.ToString());
                }
                dataTable.Remove(dataTable.ToString().LastIndexOf(','), 1);
                //Close the column array
                dataTable.AppendLine("]");
            }

            //End dataTable initialization
            dataTable.AppendLine("});");

            if (_hideHeaders.HasValue && _hideHeaders.Value)
                dataTable.AppendLine(String.Format("$('{0}').children('thead').remove();", _selector));

            // End document.ready()
            dataTable.AppendLine("});");
            return dataTable.ToString();
        }

        public string GetSortingArray()
        {
            var sb = new StringBuilder();
            //Start the array
            sb.Append("[");

            for (int i = 0; i < _sorting.Count; i++)
            {
                //Prepend a comma if its not the first sorting array
                if (i != 0)
                    sb.Append(",");

                var kvp = _sorting[i];

                sb.Append(String.Format("[{0}, '{1}']", kvp.Key, kvp.Value.ToString().ToLower()));
            }

            //End the array
            sb.Append("]");

            return sb.ToString();
        }

        /// <summary>
        /// Creates and returns the javascript to initialize the grid
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Create javascript
            var script = new StringBuilder();

            // Start script
            script.AppendLine("<script type=\"text/javascript\">");
            script.Append(RenderJavascript());
            script.AppendLine("</script>");

            // Return script + required elements
            return script.ToString();
        }

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}
