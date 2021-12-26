#pragma checksum "C:\Users\nanan\RiderProjects\AdiPlus\AdiPlus\Views\Admin\ServiceGrid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b44bf34c200a061cf21e5346a82673204ba25ccc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ServiceGrid), @"mvc.1.0.view", @"/Views/Admin/ServiceGrid.cshtml")]
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
#line 1 "C:\Users\nanan\RiderProjects\AdiPlus\AdiPlus\Views\_ViewImports.cshtml"
using AdiPlus;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nanan\RiderProjects\AdiPlus\AdiPlus\Views\_ViewImports.cshtml"
using AdiPlus.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b44bf34c200a061cf21e5346a82673204ba25ccc", @"/Views/Admin/ServiceGrid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"227dd85341b0ba1bc4af11ee4d557b38dabb3b18", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ServiceGrid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div id=\"grid\"> </div>\r\n<script>\r\n    $(\"#grid\").kendoGrid({\r\n                dataSource: {\r\n                    transport: {\r\n                        read: \"");
#nullable restore
#line 6 "C:\Users\nanan\RiderProjects\AdiPlus\AdiPlus\Views\Admin\ServiceGrid.cshtml"
                          Write(Url.Action("GetAllService", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                        update: {\r\n                            url: \"");
#nullable restore
#line 8 "C:\Users\nanan\RiderProjects\AdiPlus\AdiPlus\Views\Admin\ServiceGrid.cshtml"
                             Write(Url.Action("UpdateService", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                            dataType: \"json\",\r\n                            type: \"POST\"\r\n                        },\r\n");
            WriteLiteral(@"                    },
                    schema: {
                        model: {
                            id: ""Id"",
                            fields: {
                                Id: {from: ""id"", type: ""number"", editable: false},
                                ServiceName: { from: ""serviceName"", validation: { required: true } },
                                Description: { from: ""description"", validation: { required: true } },
                                Price: { from: ""price"", validation: { required: true } },
                                Specialization: { from: ""specialization"", validation: { required: true } },
                                SpecializationId: { from: ""specializationId"", validation: { required: true } },
                                Materials: { from: ""materials"",type:""object"", validation: { required: true } },
                                MaterialsIds: { from: ""materialsIds"", validation: { required: true } },
                            }
     ");
            WriteLiteral(@"                   }
                    },
                    pageSize: 20,
                    serverPaging: true,
                    serverFiltering: true,
                    serverSorting: true
        },
        toolbar: [
            { name: ""create"" }
        ],
                height: 550,
                editable: ""popup"",
                pageable: true,
                columns: [
                    {
                        field:""Id"",
                        filterable: false
                    },
                    {
                        field: ""ServiceName"",
                        title: ""Название""
                    },
                    {
                        field: ""Price"",
                        title: ""Цена""
                    },
                    {
                        field: ""Description"",
                        title: ""Количество""
                    },
                    {
                        field: ""Specialization.specialization");
            WriteLiteral(@"Name"",
                        title: ""Специальность"",
                        editor: specializationEditor,
                        template: function (dataItem) {
                            if (dataItem.Specialization == null)
                                return '';
                            else
                                return dataItem.Specialization.specializationName;
                        }
                    },
                    {
                        field: ""Materials.materialName"",
                        title: ""Материалы"",
                        template: citiesDisplay,
                        editor: materialsEditor
                    },
                    {
                        command: ""edit""
                    },
                    {
                        command: ""destroy""
                    }
                ]
    });

    function specializationEditor(container, options) {
        $('<input required name=""SpecializationId"">')
       ");
            WriteLiteral(@"         .appendTo(container)
                .kendoDropDownList({
                    dataTextField: ""specializationName"",
                    dataValueField: ""id"",
                    height: 500,
                    dataSource: {
                        transport: {
                            read: {
                                url: """);
#nullable restore
#line 102 "C:\Users\nanan\RiderProjects\AdiPlus\AdiPlus\Views\Admin\ServiceGrid.cshtml"
                                 Write(Url.Action("GetAllSpecializations", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                dataType: ""json"",
                                cache: false
                            }
                        }
                    }
                });
    }

    var multiSelectArrayToString = function (item) {
        return item.countries.join(', ');
    };

    function materialsEditor(container, options) {
        $('<select name=""Materials"" data-for=""Materials"" multiple=""multiple"" data-bind=""value:Materials"" data-container-for=""Materials""/>')
                .appendTo(container)
                .kendoMultiSelect({
                    dataTextField: ""materialName"",
                    dataValueField: ""id"",
                    height: 500,
                    valuePrimitive: false,
                    dataSource: {
                        transport: {
                            read: {
                                url: """);
#nullable restore
#line 126 "C:\Users\nanan\RiderProjects\AdiPlus\AdiPlus\Views\Admin\ServiceGrid.cshtml"
                                 Write(Url.Action("GetAllMaterials", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                dataType: ""json"",
                                cache: false
                            }
                        }
                    }
                });
    }
    function citiesDisplay(data) {
        console.log(data)
        var res = data.Materials.map(function(name) {
                    return name.materialName;
                  });
        return res.join("", "");
    }
</script>");
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
