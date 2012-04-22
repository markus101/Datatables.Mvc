using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;

namespace DataTables.Mvc.Core
{
    public class Column
    {
        private bool? _sortable;
        private bool? _visible;
        private string _dataProperty;
        private bool _dataPropertyIsFunction;
        private string _class;
        private string _defaultContent;
        private string _title;
        private string _width;
        private string _renderFunction;

        public Column Sortable(bool sortable)
        {
            _sortable = sortable;
            return this;
        }

        public Column Visible(bool visible)
        {
            _visible = visible;
            return this;
        }

        public Column DataProperty(string dataProperty, bool isFunction = false)
        {
            _dataProperty = dataProperty;
            _dataPropertyIsFunction = isFunction;
            return this;
        }

        public Column Class(string className)
        {
            _class = className;
            return this;
        }

        public Column DefaultContent(string defaultContent)
        {
            _defaultContent = defaultContent;
            return this;
        }

        public Column Title(string title)
        {
            _title = title;
            return this;
        }

        public Column Width(string width)
        {
            _width = width;
            return this;
        }

        [Obsolete("Use DataProperty with a function instead")]
        public Column RenderFunction(string renderFunction)
        {
            _renderFunction = renderFunction;
            return this;
        }

        public Column Link(string url, string text, object htmlAttributes)
        {
            var htmlAttributesDictionary = new RouteValueDictionary(htmlAttributes);

            var linkBuilder = new StringBuilder();
            linkBuilder.Append(String.Format("<a href=\"{0}\"", ReplaceVariables(url)));

            foreach (var att in htmlAttributesDictionary)
                linkBuilder.Append(String.Format(" {0}=\"{1}\"", CleanAttributeName(att.Key), ReplaceVariables(att.Value)));

            linkBuilder.Append(String.Format(">{0}</a>", ReplaceVariables(text)));

            var builder = new StringBuilder();
            builder.AppendLine("if (type === 'display' || type === 'filter') {");
            builder.AppendLine(String.Format("return '{0}';", linkBuilder));
            builder.AppendLine("}");
            builder.AppendLine(String.Format("return '{0}';", ReplaceVariables(text)));

            _dataProperty = builder.ToString();
            _dataPropertyIsFunction = true;
            return this;
        }

        public Column Image(string imageUrl, object imgAttributes, string sortData = null)
        {
            imageUrl = imageUrl.Replace("{", "' + source[\"").Replace("}", "\"] + '");
            var imgAttributesDictionary = new RouteValueDictionary(imgAttributes);

            var imageBuilder = new StringBuilder();
            imageBuilder.Append(String.Format("<img src=\"{0}\"", imageUrl));

            foreach (var att in imgAttributesDictionary)
                imageBuilder.Append(String.Format(" {0}=\"{1}\"", CleanAttributeName(att.Key), ReplaceVariables(att.Value)));

            imageBuilder.Append("/>");

            var builder = new StringBuilder();

            builder.AppendLine("if (type === 'display' || type === 'filter') {");

            builder.AppendLine(String.Format("return '{0}';", imageBuilder));
            builder.AppendLine("}");

            if (!String.IsNullOrEmpty(sortData))
                builder.AppendLine(String.Format("return '{0}';", ReplaceVariables(sortData)));

            else
                builder.AppendLine(String.Format("return '{0}';", imageUrl));

            _dataProperty = builder.ToString();
            _dataPropertyIsFunction = true;

            return this;
        }

        public Column DisplayAndSort(string displayData, string sortData)
        {
            var builder = new StringBuilder();

            builder.AppendLine("if (type === 'display' || type === 'filter') {");
            builder.AppendLine(String.Format("return source[\"{0}\"];", displayData));
            builder.AppendLine("}");
            builder.AppendLine(String.Format("return source[\"{0}\"];", sortData));

            _dataProperty = builder.ToString();
            _dataPropertyIsFunction = true;

            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("{ ");

            if (!String.IsNullOrWhiteSpace(_title))
                sb.AppendFormat("sTitle: '{0}',", _title);

            if (!String.IsNullOrWhiteSpace(_width))
                sb.AppendFormat("sWidth: '{0}',", _width);

            if (!String.IsNullOrWhiteSpace(_dataProperty))
            {
                int columnNumber;

                //Integer
                if (Int32.TryParse(_dataProperty, out columnNumber))
                    sb.AppendFormat("mDataProp: {0},", columnNumber);

                //Function
                else if (_dataPropertyIsFunction)
                    sb.AppendFormat("mDataProp: function(source, type, val) {{{0}}},", _dataProperty);
                
                else if (_dataProperty == "NULL")
                    sb.AppendFormat("mDataProp: null,");

                else
                    sb.AppendFormat("mDataProp: '{0}',", _dataProperty);
            }

            if (!String.IsNullOrWhiteSpace(_class))
                sb.AppendFormat("sClass: '{0}',", _class);

            if (!String.IsNullOrWhiteSpace(_defaultContent))
                sb.AppendFormat("sDefaultContent: '{0}',", _defaultContent);

            if (_sortable.HasValue)
                sb.AppendFormat("bSortable: {0},", _sortable.ToString().ToLower());

            if (_visible.HasValue)
                sb.AppendFormat("bVisible: {0},", _visible.ToString().ToLower());

            if (!String.IsNullOrWhiteSpace(_renderFunction))
                sb.AppendFormat("fnRender: function(row, val) {{{0}}},", _renderFunction);

            //Close the column
            sb.Append(" },");

            return sb.ToString();//.Remove(sb.ToString().LastIndexOf(','), 1);
        }

        internal object ReplaceVariables(object value)
        {
            if (value.ToString().Contains("{") && value.ToString().Contains("}"))
                return value.ToString().Replace("{", "' + source[\"").Replace("}", "\"] + '");

            return value;
        }

        internal string CleanAttributeName(string attribute)
        {
            if (attribute.StartsWith("data_"))
                return attribute.Replace("data_", "data-");

            return attribute;
        }
    }
}