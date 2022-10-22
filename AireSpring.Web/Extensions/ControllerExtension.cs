using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace AireSpring.Web.Extensions;

public static class ControllerExtension
{
    public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false) where TModel : class
    {
        if (string.IsNullOrEmpty(viewName))
        {
            viewName = controller.ControllerContext.ActionDescriptor.ActionName;
        }

        controller.ViewData.Model = model;

        using var writer = new StringWriter();
        IViewEngine? viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
        if (viewEngine == null)
        {
            throw new NullReferenceException($"{nameof(viewEngine)} cannot be null");
        }
        ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

        if (viewResult.Success == false)
        {
            return $"The view with the name {viewName} was not found";
        }

        ViewContext viewContext = new(
            controller.ControllerContext,
            viewResult.View,
            controller.ViewData,
            controller.TempData,
            writer,
            new HtmlHelperOptions()
        );

        await viewResult.View.RenderAsync(viewContext);

        return writer.GetStringBuilder().ToString();
    }
}
