using Realmdigital_Interview.JsonApi;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Repositories;
using Realmdigital_Interview.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Realmdigital_Interview.MVCGridConfig), "RegisterGrids")]

namespace Realmdigital_Interview
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;

    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            RegisterProductGrid();
            RegisterProductPrices();
        }

        private static void RegisterProductPrices()
        {
            MVCGridDefinitionTable.Add("ProductPricesGrid", new MVCGridBuilder<ProductPrices>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .WithSorting(sorting: true, defaultSortColumn: "Id", defaultSortDirection: SortDirection.Dsc)
                .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                .WithClientSideLoadingMessageFunctionName("showLoading")
                .WithClientSideLoadingCompleteFunctionName("finalizeGrid")
                .WithAdditionalQueryOptionNames("search")
                .WithPageParameterNames("barCode")
                .AddColumns(cols =>
                {
                    cols.Add("SellingPrice").WithHeaderText("SellingPrice")
                        .WithVisibility(true, true)
                        .WithSorting(true)
                        .WithValueExpression(p => p.SellingPrice);
                    cols.Add("CurrencyCode").WithHeaderText("CurrencyCode")
                        .WithVisibility(true, true)
                        .WithSorting(true)
                        .WithValueExpression(p => p.CurrencyCode);
                })
                    .WithRetrieveDataMethod((context) =>
                    {
                        var options = context.QueryOptions;

                        int totalRecords;
                        string globalSearch = string.IsNullOrEmpty(options.GetAdditionalQueryOptionString("search")) ? string.Empty : options.GetAdditionalQueryOptionString("search").ToLower();

                        string sortColumn = options.GetSortColumnData<string>();

                        string barCode = context.QueryOptions.GetPageParameterString("barCode");

                        var productService = new ProductService(new ProductRepository(new JsonWebServiceClient<Product>()));
                        var productPrices = productService.GetProducts().FirstOrDefault(p => p.BarCode == barCode);

                        var items = productPrices.PriceRecords;

                        totalRecords = items.Count;

                        if (!string.IsNullOrEmpty(globalSearch))
                        {
                            items = items.Where(ent => ent.CurrencyCode.ToLower().Contains(globalSearch)).ToList();
                        }

                        return new QueryResult<ProductPrices>()
                        {
                            Items = items,
                            TotalRecords = totalRecords
                        };
                    })
            );
        }

        private static void RegisterProductGrid()
        {
            MVCGridDefinitionTable.Add("ProductGrid", new MVCGridBuilder<Product>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .WithSorting(sorting: true, defaultSortColumn: "Id", defaultSortDirection: SortDirection.Dsc)
                .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                .WithClientSideLoadingMessageFunctionName("showLoading")
                .WithClientSideLoadingCompleteFunctionName("finalizeGrid")
                .WithAdditionalQueryOptionNames("search")
                .AddColumns(cols =>
                {
                    cols.Add("BarCode").WithHeaderText("BarCode")
                        .WithVisibility(true, true)
                        .WithSorting(true)
                        .WithValueExpression(p => p.BarCode);
                    cols.Add("ItemName").WithHeaderText("ItemName")
                        .WithVisibility(true, true)
                        .WithSorting(true)
                        .WithValueExpression(p => p.ItemName);
                    cols.Add("Prices").WithSorting(false)
                         .WithHeaderText("Prices")
                         .WithHtmlEncoding(false)
                         .WithValueExpression(p => p.BarCode)
                         .WithValueTemplate("<a data-fieldid='{Value}' class='fieldbtn btn btn-default fieldId-btn'>Prices</a>");
                })
                    .WithRetrieveDataMethod((context) =>
                    {
                        var options = context.QueryOptions;

                        int totalRecords;
                        string globalSearch = string.IsNullOrEmpty(options.GetAdditionalQueryOptionString("search")) ? string.Empty : options.GetAdditionalQueryOptionString("search").ToLower();

                        string sortColumn = options.GetSortColumnData<string>();

                        var productService = new ProductService(new ProductRepository(new JsonWebServiceClient<Product>()));

                        var items = productService.GetProducts();

                        totalRecords = items.Count;

                        if (!string.IsNullOrEmpty(globalSearch))
                        {
                            items = items.Where(ent => ent.BarCode.ToLower().Contains(globalSearch)).ToList();
                        }

                        return new QueryResult<Product>()
                        {
                            Items = items,
                            TotalRecords = totalRecords
                        };
                    })
            );
        }
    }
}