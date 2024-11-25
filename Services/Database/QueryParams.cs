using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Database
{
    internal class SelectQueryColumns
    {
        public required string Name { get; set; }
        public string? Alias { get; set; } = null;
    }

    internal class UpdateQueryColumns
    {
        public required string Name { get; set; }
        public required string Value { get; set; }
    }

    internal class WhereCondition
    {
        public required string Column { get; set; }
        public required string Value { get; set; }
    }

    internal class SelectQueryParams
    {
        public required string TableName { get; set; }
        public SelectQueryColumns[]? Columns { get; set; } = null;
        public string Where { get; set; } = "";
        public string OrderBy { get; set; } = "";
        public string[] InnerJoin { get; set; } = [];
        public string[] LeftJoin { get; set; } = [];
    }

    internal class InsertQueryParams
    {
        public required string TableName { get; set; }
        public required string[] Columns { get; set; }
        public required string[] Values { get; set; }
    }

    internal class DeleteQueryParams
    {
        public required string TableName { get; set; }
        public required WhereCondition Where { get; set; }
    }

    internal class UpdateQueryParams
    {
        public required string TableName { get; set; }
        public required UpdateQueryColumns[] Columns { get; set; }
        public required WhereCondition Where { get; set; }
    }
}
