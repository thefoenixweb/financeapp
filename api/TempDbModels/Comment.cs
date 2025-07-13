using System;
using System.Collections.Generic;

namespace api.TempDbModels;

public partial class Comment
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int? StockId { get; set; }

    public string AppUserId { get; set; } = null!;

    public virtual AspNetUser AppUser { get; set; } = null!;

    public virtual Stock? Stock { get; set; }
}
