using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ML.Data;

namespace ECAIService.PipelineDto;
// App 0,Category 1,Rating 2,Reviews 3,Size 4,Installs 5,Type 6,Price 7,Content Rating 8,Genres 9,Last Updated,Current Ver,Android Ver

// Removed defective record at line 10474: 
// Life Made WI-Fi Touchscreen Photo Frame,1.9,19,3.0M,"1,000+",Free,0,Everyone,,"February 11, 2018",1.0.19,4.0 and up

public record GooglePlayApp
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
    public double Rating { get; set; } = 0;

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
