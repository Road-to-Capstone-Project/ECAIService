using Microsoft.ML.Data;

namespace ECAIService.PipelineDto;

public record GooglePlayAppUnparsed
(

)
{
    [property: LoadColumn(0)]
    public string AppName { get; set; } = "";
    [property: LoadColumn(1)]
    public string Category { get; set; } = "";

    /// <summary>
    /// Possible NaN.
    /// </summary>
    [property: LoadColumn(2)]
    public string Rating { get; set; } = "";

    [property: LoadColumn(3)]
    public string Reviews { get; set; } = string.Empty;

    [property: LoadColumn(4)]
    public string Size { get; set; } = string.Empty;

    [property: LoadColumn(5)]
    public string Installs { get; set; } = string.Empty;

    [property: LoadColumn(6)]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Price either "0" or "$Price".
    /// </summary>
    [property: LoadColumn(7)]
    public string Price { get; set; } = "0";

    /// <summary>
    /// Unrated possible.
    /// </summary>
    [property: LoadColumn(8)]
    public string ContentRating { get; set; } = "";

    /// <summary>
    /// Seperated by ';'
    /// </summary>
    [property: LoadColumn(9)]
    public string Genres { get; set; } = "";

    [property: LoadColumn(10)]
    public string LastUpdated { get; set; } = "";

    [property: LoadColumn(11)]
    public string CurrenVer { get; set; } = "";
    [property: LoadColumn(12)]
    public string AndroidVer { get; set; } = "";
}
