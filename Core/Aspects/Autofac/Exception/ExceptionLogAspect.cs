using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
       private IHttpContextAccessor _httpContextAccessor;
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
           _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//using Microsoft.Extensions.DependencyInjection
        }
        protected override void OnException(IInvocation invocation,System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);

        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var userName = _httpContextAccessor.HttpContext.User.ClaimUserName();
            var remoteIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter {
                    Name=invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value=invocation.Arguments[i],
                    Type=invocation.Arguments[i].GetType().Name
                });
            }
            var logDetailWidthException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                RequestingName = userName,
                Ip=remoteIp
            };
            return logDetailWidthException;
        }
    }
}
