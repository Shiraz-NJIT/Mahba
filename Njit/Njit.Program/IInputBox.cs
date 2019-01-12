using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Program
{
    public interface IInputBox
    {
        int? IntValue { get; }
        long? LongValue { get; }
        short? ShortValue { get; }
        float? FloatValue { get; }
        double? DoubleValue { get; }
        decimal? DecimalValue { get; }
        string Text { get; set; }
        bool AllowEmptyText { get; set; }
        InputBoxValidationHelper.InputTypes InputType { get; set; }
        double? MinValue { get; set; }
        double? MaxValue { get; set; }
        int MaxLength { get; set; }
        int MinLength { get; set; }
        string IllegalCharacters { get; set; }
        int SelectionStart { get; set; }
        string GetNewText(char value);
        void SetText(string value);
        bool AutoSeparateDigits { get; set; }
    }
}
