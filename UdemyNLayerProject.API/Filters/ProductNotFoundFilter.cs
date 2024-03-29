﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;

        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            // eger product null degilse devam et
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new();

                errorDto.Status = 404;

                errorDto.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı.");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }

    }
}
