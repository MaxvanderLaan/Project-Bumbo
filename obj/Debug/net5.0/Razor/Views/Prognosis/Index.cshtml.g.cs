#pragma checksum "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f411908c7d3676fca639ea033bebeb3dcfb19c4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prognosis_Index), @"mvc.1.0.view", @"/Views/Prognosis/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\_ViewImports.cshtml"
using Bumbo.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\_ViewImports.cshtml"
using Bumbo.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
using Bumbo.Domain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f411908c7d3676fca639ea033bebeb3dcfb19c4d", @"/Views/Prognosis/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46e2f0ca9b4a70efd240b47401d999e81bbe6eca", @"/Views/_ViewImports.cshtml")]
    public class Views_Prognosis_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bumbo.Domain.Models.Forecast>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/forecast.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn bg-bumbo-yellow"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Prognosis", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Recalculate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("recalculateId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
  
    ViewData["Title"] = "Prognose overzicht";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f411908c7d3676fca639ea033bebeb3dcfb19c4d7738", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""container-fluid"">
    <div class=""d-flex justify-content-between align-items-center"">
        <h1 class=""text-white"">Prognose</h1>
        <div>
            <button class=""btn bg-gray-800 text-white"" data-bs-toggle=""modal"" data-bs-target=""#forecast-modal-create"">Prognose aanmaken</button>
        </div>
    </div>

    <div class=""d-flex mt-4 mb-3"">
        <div class=""shadow d-flex flex-column border w-100 p-3 bg-white rounded"">
            <table id=""ForecastTable"" class=""display table"">
                <thead>
                <tr>
                    <th>#</th>
                    <th class=""col-2"">
                        Branchenaam
                    </th>
                    <th>
                        Aantal klanten
                    </th>
                    <th>
                        Aantal colli
                    </th>
                    <th class=""col-3"">
                        Beschrijving
                    </th>
                    <th>
    ");
            WriteLiteral("                    Datum\r\n                    </th>\r\n                    <th>Bewerken</th>\r\n                </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 43 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                 foreach (Forecast item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 47 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ForecastId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 50 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Branch.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 53 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AmountOfCustomers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 56 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.RollContainers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                       Write(item.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                        <td>
                            <div class=""d-flex"">
                                <button type=""submit"" class=""btn btn-dark"">
                                    <i class=""bi bi-pen-fill""></i>
                                </button>
                            </div>
                        </td>
                    </tr>
");
#nullable restore
#line 72 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
        
        <div class=""modal fade"" id=""forecast-modal-create"" tabindex=""-1"" aria-labelledby=""forecast-modal"" aria-hidden=""true"">
                <div class=""modal-dialog modal-dialog-centered"">
                    <div class=""modal-content"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f411908c7d3676fca639ea033bebeb3dcfb19c4d13660", async() => {
                WriteLiteral(@"
                            <div class=""modal-header"">
                                <h5 class=""modal-title"" id=""exampleModalLabel"">Maak een nieuwe prognose aan</h5>
                                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                            </div>
                            <div class=""modal-body"">
                                <div class=""mb-3"">
                                    <label class=""form-label"" for=""exampleInputPassword1"">Locatie</label>
                                    <select name=""branchId"" class=""form-select"" aria-label=""Default select example"" required>
");
#nullable restore
#line 89 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                         foreach (dynamic item in ViewBag.Branches)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f411908c7d3676fca639ea033bebeb3dcfb19c4d14992", async() => {
#nullable restore
#line 91 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                                                      Write(item.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                               WriteLiteral(item.BranchId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 92 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </select>\r\n                                </div>\r\n        \r\n                                <div");
                BeginWriteAttribute("class", " class=\"", 4130, "\"", 4138, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    <label class=""form-label"" for=""date-create"">Voeg een datum toe</label>
                                    <input type=""date"" id=""date-create"" name=""date"" class=""form-control"" required/>
                                </div>
        
                                <div class=""mb-3"">
                                    <label class=""form-label"" for=""customer"">Verwachte aantal klanten</label>
                                    <input type=""number"" class=""form-control"" name=""amountOfCustomers"" id=""customer"" min=""0"" max=""99999"" placeholder=""Aantal klanten..."" required>
                                </div>
                                <div class=""mb-3"">
                                    <label class=""form-label"" for=""colli"">Verwachte aantal colli</label>
                                    <input type=""number"" class=""form-control"" name=""rollContainers"" id=""colli"" min=""0"" max=""99999"" placeholder=""Aantal colli..."" required>
                                <");
                WriteLiteral(@"/div>
                                <div>
                                    <label class=""form-label"" for=""description"">Voeg een beschrijving toe</label>
                                    <textarea type=""text"" class=""form-control"" name=""Description"" id=""description"" placeholder=""Beschrijving...""></textarea>
                                </div>
                            </div>
                            <div class=""modal-footer"">
                                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"" aria-label=""Close"">Sluiten</button>
                                <button id=""button"" type=""submit"" class=""btn btn-dark"">Aanmaken</button>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
            </div>

        <div class=""modal fade"" id=""forecast-modal-edit"" tabindex=""-1"" aria-labelledby=""forecast-modal"" aria-hidden=""true"">
            <div class=""modal-dialog modal-dialog-centered"">
                <div class=""modal-content"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f411908c7d3676fca639ea033bebeb3dcfb19c4d20871", async() => {
                WriteLiteral(@"
                        <input type=""hidden"" name=""forecastId"" id=""forecast-id""/>
                        <div class=""modal-header"">
                            <h5 class=""modal-title"" id=""exampleModalLabel"">Bewerk de prognose</h5>
                            <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                        </div>
                        <div class=""modal-body"">
                            <div class=""mb-3"">
                                <label class=""form-label"" for=""exampleInputPassword1"">Locatie</label>
                                <select id=""branch-id"" name=""branchId"" class=""form-select"" aria-label=""Default select example"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f411908c7d3676fca639ea033bebeb3dcfb19c4d21920", async() => {
                    WriteLiteral("Selecteer een locatie...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 137 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                     foreach (dynamic item in ViewBag.Branches)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f411908c7d3676fca639ea033bebeb3dcfb19c4d23962", async() => {
#nullable restore
#line 139 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 139 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                           WriteLiteral(item.BranchId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 140 "C:\Projects\C#\AVANS 2021\Bumbo\soprj6-groep-k\Bumbo.Web\Views\Prognosis\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </select>
                            </div>
                            
                            <div class=""mb-3"">
                                <label class=""form-label"" for=""date"">Voeg een datum toe</label>
                                <input type=""date"" id=""date-edit"" name=""date"" class=""form-control"" />
                            </div>

                            <div class=""mb-3"">
                                <label class=""form-label"" for=""customer"">Verwachte aantal klanten</label>
                                <input type=""number"" class=""form-control"" name=""amountOfCustomers"" id=""customer-edit"" placeholder=""Aantal klanten..."" min=""0"" max=""99999"" onchange=""onChangeEvent()"">
                            </div>
                            <div class=""mb-3"">
                                <label class=""form-label"" for=""colli"">Verwachte aantal colli</label>
                                <input type=""number"" class=""form-control"" name=""rollConta");
                WriteLiteral(@"iners"" id=""colli-edit"" placeholder=""Aantal colli..."" min=""0"" max=""99999"" onchange=""onChangeEvent()"">
                            </div>
                            <div>
                                <label class=""form-label"" for=""description"">Voeg een beschrijving toe</label>
                                <textarea type=""text"" class=""form-control"" name=""Description"" id=""description-edit"" placeholder=""Beschrijving...""></textarea>
                            </div>
                            <div>
                                <label class=""form-label"" for=""description"">Benodigde uren bij kassa</label>
                                <input type=""number"" class=""form-control"" name=""AmountOfCashiers"" min=""0"" max=""999"" id=""cashiers-edit"">
                            </div>
                            <div>
                                <label class=""form-label"" for=""description"">Benodigde uren bij vers</label>
                                <input type=""number"" class=""form-control"" name=""Amo");
                WriteLiteral(@"untOfFresh"" min=""0"" max=""999"" id=""fresh-edit"">
                            </div>
                            <div class=""mb-3"">
                                <label class=""form-label"" for=""description"">Benodigde uren bij vakkenvullen</label>
                                <input type=""number"" class=""form-control"" name=""AmountOfStockClerks"" min=""0"" max=""999"" id=""stock-clerks-edit"">
                            </div>
                            <div id=""dangerId"" class=""text-danger""></div>
                        </div>
                        <div class=""modal-footer justify-content-between"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f411908c7d3676fca639ea033bebeb3dcfb19c4d29015", async() => {
                    WriteLiteral("Herbereken");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <div>\r\n                                <button type=\"button\" class=\"btn btn-secondary\" data-bs-dismiss=\"modal\" aria-label=\"Close\">Sluiten</button>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f411908c7d3676fca639ea033bebeb3dcfb19c4d31282", async() => {
                    WriteLiteral("Wijzig");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\" src=\"js/Prognosis/Main.js\"></script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bumbo.Domain.Models.Forecast>> Html { get; private set; }
    }
}
#pragma warning restore 1591