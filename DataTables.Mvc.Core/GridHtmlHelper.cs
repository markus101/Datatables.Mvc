using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using ServiceStack.Text;

namespace DataTables.Mvc.Core
{
    public static class GridHtmlHelper
    {
        public static MvcHtmlString GridHtml(this HtmlHelper html, string htmlId, string htmlClass)
        {
            var tableRow = String.Format("<table id=\"{0}\" class=\"{1}\">", htmlId, htmlClass);
            var sb = new StringBuilder();
            sb.AppendLine(tableRow);
            sb.AppendLine("<thead></thead>");
            sb.AppendLine("<tbody></tbody>");
            sb.AppendLine("</table>");

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString GridHtml(this HtmlHelper html, string htmlId)
        {
            var tableRow = String.Format("<table id=\"{0}\">", htmlId);
            var sb = new StringBuilder();
            sb.AppendLine(tableRow);
            sb.AppendLine("<thead></thead>");
            sb.AppendLine("<tbody></tbody>");
            sb.AppendLine("</table>");

            return new MvcHtmlString(sb.ToString());
        }

        public static Grid GridScript(this HtmlHelper html, string selector)
        {
            return new Grid(selector);
        }

        public static Grid GridScriptForModel(this HtmlHelper html, string selector)
        {
            var model = html.ViewData.Model;

            if (model == null)
                throw new ArgumentException("Model is invalid");

            return new Grid(selector).AData(JsonSerializer.SerializeToString(model));
        }

        public static Grid GridScript(this HtmlHelper html, IEnumerable<object> collection, string selector)
        {
            if (collection == null)
                throw new ArgumentException("Collection is invalid");

            return new Grid(selector).AData(JsonSerializer.SerializeToString(collection));
        }

        public static Grid GridScriptFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string selector)
        {
            var memberEx = expression.Body as MemberExpression;

            if (memberEx == null)
                throw new ArgumentException("Body not a member-expression.");

            string name = memberEx.Member.Name;
            var model = html.ViewData.Model;
            var value = model.GetType().GetProperty(name).GetValue(model, null);

            if (value == null)
                throw new ArgumentException("Collection is invalid");

            return new Grid(selector).AData(JsonSerializer.SerializeToString(value));
        }
    }
}
