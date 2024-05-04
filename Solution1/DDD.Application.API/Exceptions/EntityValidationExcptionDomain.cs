using Sistema.Vendas.Domain.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.API.Exceptions
{
    public class EntityValidationExcptionDomain : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is EntityValidationException)
            {
                var mensagemDeErro = context.Exception.Message;
                var codigoDeStatus = HttpStatusCode.BadRequest;

                context.Result = new ObjectResult(mensagemDeErro)
                {
                    StatusCode = (int) codigoDeStatus
                };
            }
        }
    }
}
