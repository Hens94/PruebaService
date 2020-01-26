using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static PruebaService_Common.Extensions.CommonExtensions;

namespace System
{
    public static class ExceptionExtensions
    {
        public delegate void ExecuteErrorInfo(string message, int resultCode = 999, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string detailMessage = null);
        public delegate void ExecuteErrorInfoWithException(BaseException exception);

        public static async Task<T> UseCatchExceptionAsync<T, TException>(
            Func<ExecuteErrorInfo, Task<T>> func,
            string genericErrorMessage = null) where TException : BaseException
        {
            try
            {
                return await func((errorMessage, resultCode, statusCode, errorDetailMessage) =>
                {
                    throw GetException<TException>(errorMessage, resultCode, statusCode, errorDetailMessage);
                });
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw GetException<TException>(message: genericErrorMessage, exception: ex);
            }
        }

        public static async Task UseCatchExceptionAsync<TException>(
            Func<ExecuteErrorInfo, Task> func,
            string genericErrorMessage = null) where TException : BaseException
        {
            try
            {
                await func((errorMessage, resultCode, statusCode, errorDetailMessage) =>
                {
                    throw GetException<TException>(errorMessage, resultCode, statusCode, errorDetailMessage);
                });
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw GetException<TException>(message: genericErrorMessage, exception: ex);
            }
        }

        public static async Task<T> UseCatchCustomExceptionAsync<T, TException>(
            Func<ExecuteErrorInfo, ExecuteErrorInfoWithException, Task<T>> func,
            string genericErrorMessage = null)
            where TException : BaseException
        {
            try
            {
                return await func(
                    (errorMessage, resultCode, statusCode, errorDetailMessage) =>
                    {
                        throw GetException<TException>(errorMessage, resultCode, statusCode, errorDetailMessage);
                    },
                    exception =>
                    {
                        throw exception;
                    });
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw GetException<TException>(message: genericErrorMessage, exception: ex);
            }
        }

        public static async Task UseCatchCustomExceptionAsync<TException>(
            Func<ExecuteErrorInfo, ExecuteErrorInfoWithException, Task> func,
            string genericErrorMessage = null)
            where TException : BaseException
        {
            try
            {
                await func(
                    (errorMessage, resultCode, statusCode, errorDetailMessage) =>
                    {
                        throw GetException<TException>(errorMessage, resultCode, statusCode, errorDetailMessage);
                    },
                    exception =>
                    {
                        throw exception;
                    });
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw GetException<TException>(message: genericErrorMessage, exception: ex);
            }
        }

        public static T UseCatchException<T, TException>(
            Func<ExecuteErrorInfo, T> func,
            string genericErrorMessage = null) where TException : BaseException
        {
            try
            {
                return func((errorMessage, resultCode, statusCode, errorDetailMessage) =>
                {
                    throw GetException<TException>(errorMessage, resultCode, statusCode, errorDetailMessage);
                });
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw GetException<TException>(message: genericErrorMessage, exception: ex);
            }
        }

        public static T UseCatchException<T, TException>(
            Func<ExecuteErrorInfo, ExecuteErrorInfoWithException, T> func,
            string genericErrorMessage = null)
            where TException : BaseException
        {
            try
            {
                return func(
                    (errorMessage, resultCode, statusCode, errorDetailMessage) =>
                    {
                        throw GetException<TException>(errorMessage, resultCode, statusCode, errorDetailMessage);
                    },
                    exception =>
                    {
                        throw exception;
                    });
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw GetException<TException>(message: genericErrorMessage, exception: ex);
            }
        }

        private static T GetException<T>(string message, int resultCode = 999, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string detailMessage = null, Exception exception = null) where T : BaseException
        {
            if (exception is null)
            {
                var exceptionConst = CreateConstructor(typeof(T), typeof(string), typeof(int), typeof(HttpStatusCode), typeof(string));
                return (T)exceptionConst(message, resultCode, statusCode, detailMessage);
            }
            else
            {
                Log.Error(exception, $"Ha ocurrido un error no controlado: {exception.Source}");

                var exceptionConst = CreateConstructor(typeof(T), typeof(Exception), typeof(string), typeof(int), typeof(HttpStatusCode), typeof(string));
                return (T)exceptionConst(exception, message, resultCode, statusCode, detailMessage);
            }
        }
    }
}