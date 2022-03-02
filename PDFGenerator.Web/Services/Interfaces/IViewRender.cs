﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PDFGenerator.Web.Services.Interfaces
{
    public interface IViewRender
    {
        string Render<TModel>(string name, TModel model);
        string Render<TModel>(string name, TModel model, ViewDataDictionary viewData);
    }
}
