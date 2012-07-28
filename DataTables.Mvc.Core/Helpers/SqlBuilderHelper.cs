using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTables.Mvc.Core.Models;

namespace DataTables.Mvc.Core.Helpers
{
    public static class SqlBuilderHelper
    {
        private static IEnumerable<string> GetSearchClause(DataTablesPageRequest pageRequest)
        {
            var columns = pageRequest.ColumnNames.Split(',');

            for (var idx = 0; idx < pageRequest.Searchable.Count; ++idx)
            {
                if (pageRequest.Searchable[idx])
                    yield return string.Format("{0} LIKE @0", columns[idx]);
            }
        }

        private static IEnumerable<string> GetOrderByClause(DataTablesPageRequest pageRequest)
        {
            var columns = pageRequest.ColumnNames.Split(',');

            for (var idx = 0; idx < pageRequest.SortingCols; ++idx)
            {
                yield return string.Format("{0} {1}", columns[pageRequest.SortCol[idx]], pageRequest.SortDir[idx]);
            }
        }
    }
}
