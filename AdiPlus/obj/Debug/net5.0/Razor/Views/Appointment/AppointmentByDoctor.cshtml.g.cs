#pragma checksum "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\Appointment\AppointmentByDoctor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08c91f1d8952d43f4ca99874c46c74bfba1ce2cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointment_AppointmentByDoctor), @"mvc.1.0.view", @"/Views/Appointment/AppointmentByDoctor.cshtml")]
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
#line 1 "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\_ViewImports.cshtml"
using AdiPlus;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\_ViewImports.cshtml"
using AdiPlus.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08c91f1d8952d43f4ca99874c46c74bfba1ce2cd", @"/Views/Appointment/AppointmentByDoctor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"227dd85341b0ba1bc4af11ee4d557b38dabb3b18", @"/Views/_ViewImports.cshtml")]
    public class Views_Appointment_AppointmentByDoctor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div id=\"example\">\r\n    <div id=\"scheduler\"></div>\r\n</div>\r\n<script id=\"event-template\" type=\"text/x-kendo-template\">\r\n    <div class=\"movie-template\">\r\n      <a href=\"");
#nullable restore
#line 6 "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\Appointment\AppointmentByDoctor.cshtml"
          Write(Url.Action("AppointmentResult","Appointment"));

#line default
#line hidden
#nullable disable
            WriteLiteral("/?appointmentId=#= id #\"><p>#: title #</p></a>\r\n      </div>\r\n    </script>\r\n<script>\r\n$(function() {\r\n    $(\"#scheduler\").kendoScheduler({\r\n        footer: false,\r\n        date: new Date(\"");
#nullable restore
#line 13 "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\Appointment\AppointmentByDoctor.cshtml"
                   Write(DateTime.Now.ToString("yyyy-M-d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"),\r\n        startTime: new Date(\"");
#nullable restore
#line 14 "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\Appointment\AppointmentByDoctor.cshtml"
                        Write(DateTime.Now.ToString("yyyy-M-d 08:00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""),
        allDaySlot: false,
        views: [
            {
                type: ""day"",
                selected: true,
            },
            {
                type: ""workWeek""
            }
        ],
        editable: false,
        eventTemplate: $(""#event-template"").html(),
        timezone: ""Europe/Minsk"",
        dataSource: {
            batch: true,
            transport: {
                read: {
                    url: """);
#nullable restore
#line 32 "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\Appointment\AppointmentByDoctor.cshtml"
                     Write(Url.Action("GetTalonsDoctorByDoctorId", "Appointment", new {id = ViewBag.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    dataType: ""json""
                },
            },
            schema: {
                model: {
                    id: ""id"",
                    fields: {
                        id: {
                            from: ""id"",
                            type: ""number""
                        },
                        title: {
                            defaultValue: ""No title"",
                            validation: {
                                required: false
                            }
                        },
                        start: {
                            type: ""date"",
                            from: ""dateStart""
                        },
                        end: {
                            type: ""date"",
                            from: ""dateEnd""
                        },
                        doctorId: {
                            type: ""number"",
                            from: ""doctorId"",
                      ");
            WriteLiteral("      defaultValue: ");
#nullable restore
#line 61 "C:\Users\great\RiderProjects\AdiPlus\AdiPlus\Views\Appointment\AppointmentByDoctor.cshtml"
                                     Write(ViewBag.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        }
                    }
                }
            }
        }
    });
});
</script>
<style>
    .k-icon.k-i-arrow-60-down{
        display: none;
        }
    .k-icon.k-i-arrow-60-up{
        display: none;
        }
    .k-current-time{
        display: none;
        }
    p{
        color: black;
        }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
