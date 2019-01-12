using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware
{
    public class SearchField
    {
        public SearchField(Model.Archive.ArchiveField Field, SearchMethod Method, string Value = "", Relations Relation = Relations.None, List<SearchField> SearchFields = null)
        {
            this.Field = Field;
            this.Method = Method;
            this.Value = Value;
            this.Relation = Relation;
            this.SearchFields = SearchFields;
        }

        public enum Relations
        {
            None,
            And,
            Or
        }

        private Relations _Relation;
        public Relations Relation
        {
            get
            {
                return _Relation;
            }
            set
            {
                _Relation = value;
            }
        }

        private Model.Archive.ArchiveField _Field;
        public Model.Archive.ArchiveField Field
        {
            get
            {
                return _Field;
            }
            set
            {
                _Field = value;
            }
        }

        private SearchMethod _Method;
        public SearchMethod Method
        {
            get
            {
                return _Method;
            }
            set
            {
                _Method = value;
            }
        }

        private string _Value;
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        private List<SearchField> _SearchFields;
        public List<SearchField> SearchFields
        {
            get
            {
                return _SearchFields;
            }
            set
            {
                _SearchFields = value;
            }
        }

        public string RelationQuery
        {
            get
            {
                if (this.Field == null)
                    return "";
                if (this.Method == null)
                    return "";
                if (this.Value == null)
                    return "";
                string temp = "";
                if (this.Relation == Relations.And)
                    temp += " AND ";
                else if (this.Relation == Relations.Or)
                    temp += " OR ";
                return temp;
            }
        }

        public string SearchQueryWithoutRelation
        {
            get
            {
                if (this.Field == null)
                    return "";
                if (this.Method == null)
                    return "";
                if (this.Value == null)
                    return "";
                string temp = "";
                temp += string.Format(" dbo.[{0}].[{1}]", this.Field.ArchiveTab.Name, this.Field.FieldName);
                switch ((SearchMethod.SearchMethods)this.Method.Code)
                {
                    case SearchMethod.SearchMethods.Equal:
                        if (this.Field.IsNumber() && Value.IsNumber())
                            temp += " = " + this.Value;
                        else
                            temp += " = " + "N'" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.NotEqual:
                        if (this.Field.IsNumber() && Value.IsNumber())
                            temp += " <> " + this.Value;
                        else
                            temp += " <> " + "N'" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.Contains:
                        temp += " LIKE " + "N'%" + this.Value + "%' ";
                        break;
                    case SearchMethod.SearchMethods.StartsWith:
                        temp += " LIKE " + "N'" + this.Value + "%' ";
                        break;
                    case SearchMethod.SearchMethods.NotStartsWith:
                        temp += " NOT LIKE " + "N'" + this.Value + "%' ";
                        break;
                    case SearchMethod.SearchMethods.EndsWith:
                        temp += " LIKE " + "N'%" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.NotEndsWith:
                        temp += " NOT LIKE " + "N'%" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.LessThan:
                        if (this.Field.IsNumber() && Value.IsNumber())
                            temp += " < " + this.Value;
                        else
                            temp += " < " + "N'" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.LessThanOrEqual:
                        if (this.Field.IsNumber() && Value.IsNumber())
                            temp += " <= " + this.Value;
                        else
                            temp += " <= " + "N'" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.GreaterThan:
                        if (this.Field.IsNumber() && Value.IsNumber())
                            temp += " > " + this.Value;
                        else
                            temp += " > " + "N'" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.GreaterThanOrEqual:
                        if (this.Field.IsNumber() && Value.IsNumber())
                            temp += " >= " + this.Value;
                        else
                            temp += " >= " + "N'" + this.Value + "' ";
                        break;
                    case SearchMethod.SearchMethods.IsNull:
                        temp += " IS NULL ";
                        break;
                    case SearchMethod.SearchMethods.IsNotNull:
                        temp += " IS NOT NULL ";
                        break;
                    case SearchMethod.SearchMethods.In:
                        string[] inValues = Value.Split(',', '،');
                        bool inValuesIsNumber = inValues.All(t => t.IsNumber());
                        if (!(this.Field.IsNumber() && inValuesIsNumber))
                        {
                            for (int i = 0; i < inValues.Length; i++)
                            {
                                inValues[i] = "N'" + inValues[i] + "'";
                            }
                        }
                        temp += " IN (" + inValues.Aggregate((a, b) => a + "," + b) + ") ";
                        break;
                    case SearchMethod.SearchMethods.NotIn:
                        string[] notInValue = Value.Split(',', '،');
                        bool notInValuesIsNumber = notInValue.All(t => t.IsNumber());
                        if (!(this.Field.IsNumber() && notInValuesIsNumber))
                        {
                            for (int i = 0; i < notInValue.Length; i++)
                            {
                                notInValue[i] = "N'" + notInValue[i] + "'";
                            }
                        }
                        temp += " NOT IN (" + notInValue.Aggregate((a, b) => a + "," + b) + ") ";
                        break;
                }
                return temp;
            }
        }

        public string SearchQuery
        {
            get
            {
                return this.RelationQuery + this.SearchQueryWithoutRelation;
            }
        }

        public override string ToString()
        {
            string relation = "";
            switch (this.Relation)
            {
                case Relations.And:
                    relation = "و";
                    break;
                case Relations.Or:
                    relation = "یا";
                    break;
            }
            switch ((SearchMethod.SearchMethods)this.Method.Code)
            {
                case SearchMethod.SearchMethods.Equal:
                    return relation + " " + this.Field.Label + " " + "با" + "   " + "\"" + this.Value + "\"" + "   " + "برابر باشد";
                case SearchMethod.SearchMethods.NotEqual:
                    return relation + " " + this.Field.Label + " " + "با" + "   " + "\"" + this.Value + "\"" + "   " + "برابر نباشد";
                case SearchMethod.SearchMethods.Contains:
                    return relation + " " + this.Field.Label + " " + "حاوی" + "   " + "\"" + this.Value + "\"" + "   " + "باشد";
                case SearchMethod.SearchMethods.StartsWith:
                    return relation + " " + this.Field.Label + " " + "با" + "   " + "\"" + this.Value + "\"" + "   " + "شروع شود";
                case SearchMethod.SearchMethods.NotStartsWith:
                    return relation + " " + this.Field.Label + " " + "با" + "   " + "\"" + this.Value + "\"" + "   " + "شروع نشود";
                case SearchMethod.SearchMethods.EndsWith:
                    return relation + " " + this.Field.Label + " " + "با" + "   " + "\"" + this.Value + "\"" + "   " + "خاتمه یابد";
                case SearchMethod.SearchMethods.NotEndsWith:
                    return relation + " " + this.Field.Label + " " + "با" + "   " + "\"" + this.Value + "\"" + "   " + "خاتمه نیابد";
                case SearchMethod.SearchMethods.LessThan:
                    return relation + " " + this.Field.Label + " " + "از" + "   " + "\"" + this.Value + "\"" + "   " + "کوچکتر باشد";
                case SearchMethod.SearchMethods.LessThanOrEqual:
                    return relation + " " + this.Field.Label + " " + "کوچکتر یا مساوی باشد با" + "   " + "\"" + this.Value + "\"";
                case SearchMethod.SearchMethods.GreaterThan:
                    return relation + " " + this.Field.Label + " " + "از" + "   " + "\"" + this.Value + "\"" + "   " + "بزرگ تر باشد";
                case SearchMethod.SearchMethods.GreaterThanOrEqual:
                    return relation + " " + this.Field.Label + " " + "بزرگتر یا مساوی باشد با" + "   " + "\"" + this.Value + "\"";
                case SearchMethod.SearchMethods.IsNull:
                    return relation + " " + this.Field.Label + " " + "خالی باشد";
                case SearchMethod.SearchMethods.IsNotNull:
                    return relation + " " + this.Field.Label + " " + "خالی نباشد";
                case SearchMethod.SearchMethods.In:
                    return relation + " " + this.Field.Label + " " + "یکی از مقادیر (" + this.Value + ")" + " باشد";
                case SearchMethod.SearchMethods.NotIn:
                    return relation + " " + this.Field.Label + " " + "هیچکدام از مقادیر (" + this.Value + ")" + " نباشد";
                default:
                    throw new Exception();
            }
        }
    }
}
