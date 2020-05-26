using System.Threading.Tasks;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace CallerAPI
{ 
    public class Result<TValue, TError, TStatus>
    {
        public Result(TValue value, TError error, TStatus status)
        {
            Value = value;
            Error = error;
            Status = status;
        }

        public TValue Value { get; internal set; }

        public TError Error { get; internal set; }

        public TStatus Status { get; internal set; }
    }

    public class Result<TValue, TStatus>
    {
        public Result(TValue value, TStatus status)
        {
            Value = value;
            Status = status;
        }

        public TValue Value { get; internal set; }

        public TStatus Status { get; internal set; }
    }

    public class Result
    {
        public static Result<TValue, TError, TStatus> Create<TValue, TError, TStatus>(TValue value, TError error, TStatus status)
        {
            return new Result<TValue, TError, TStatus>(value, error, status);
        }
    }

    public class Caller 
    {
        public Caller(Uri baseAddress) 
        {
            // Open a new instance for request Web API.
            _requestAPIHelper = new RequestAPI(baseAddress);
        }

        // Declare a new instance for request Web API.
        private RequestAPI _requestAPIHelper { get; set; }

        /// <summary>
        /// Request async method.
        /// </summary>
        /// <param name="action">Params for request.</param>
        /// <returns>
        /// Return a string result.
        /// </returns>
        public async Task<Result<string, string, HttpStatusCode>> RequestTextAsync(Action<Params> action)
        {
            Params @params = new Params();
            action(@params);

            await _requestAPIHelper.RequestAPIAsync(@params);

            if (_requestAPIHelper.StatusCode == @params.HttpStatusCode)
            {
                return Result.Create(_requestAPIHelper.TextResult, default(string), _requestAPIHelper.StatusCode);
            }

            return Result.Create(default(string), _requestAPIHelper.ExceptionTextResult, _requestAPIHelper.StatusCode);
        }

        /// <summary>
        /// Request async method.
        /// </summary>
        /// <typeparam name="TValue">This typeparam is for deserealize a JSON result to a model.</typeparam>
        /// <param name="action">Set params for request./</param>
        /// <returns>
        /// Return a TValue model deserializing an JSON result.
        /// </returns>
        public async Task<Result<TValue, string, HttpStatusCode>> RequestJSONAsync<TValue>(Action<Params> action)
        {
            Params @params = new Params();
            action.Invoke(@params);

            await _requestAPIHelper.RequestAPIAsync(@params);

            if (_requestAPIHelper.StatusCode == @params.HttpStatusCode)
            {
                TValue content = JsonConvert.DeserializeObject<TValue>(_requestAPIHelper.TextResult);
                return Result.Create(content, default(string), _requestAPIHelper.StatusCode);
            }

            return Result.Create(default(TValue), _requestAPIHelper.ExceptionTextResult, _requestAPIHelper.StatusCode);
        }

        /// <summary>
        /// Request async method.
        /// </summary>
        /// <typeparam name="TValue">This typeparam is for deserealize a XML result to a model.</typeparam>
        /// <param name="action">Set params for request./</param>
        /// <returns>
        /// Return a TValue model deserializing an XML result.
        /// </returns>
        public async Task<Result<TValue, string, HttpStatusCode>> RequestXMLAsync<TValue>(Action<Params> action)
        {
            Params @params = new Params();
            action.Invoke(@params);

            await _requestAPIHelper.RequestAPIAsync(@params);

            if (_requestAPIHelper.StatusCode == @params.HttpStatusCode)
            {
                using (StringReader stringReader = new StringReader(_requestAPIHelper.TextResult))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TValue));
                    TValue content = (TValue)xmlSerializer.Deserialize(stringReader);
                    return Result.Create(content, default(string), _requestAPIHelper.StatusCode);
                }
            }

            return Result.Create(default(TValue), _requestAPIHelper.ExceptionTextResult, _requestAPIHelper.StatusCode);
        }

        /// <summary>
        /// Request async method.
        /// </summary>
        /// <typeparam name="TValue">This typeparam is for deserealize a JSON result to a model.</typeparam>
        /// <typeparam name="TError">This typeparam is for deserealize a JSON error result to a model.</typeparam>
        /// <param name="action">Set params for request.</param>
        /// <returns>
        /// Return a TValue model deserializing an JSON result.
        /// </returns>
        public async Task<Result<TValue, TError, HttpStatusCode>> RequestJSONAsync<TValue, TError>(Action<Params> action)
        {
            Params @params = new Params();
            action.Invoke(@params);

            await _requestAPIHelper.RequestAPIAsync(@params);

            if (_requestAPIHelper.StatusCode == @params.HttpStatusCode)
            {
                TValue content = JsonConvert.DeserializeObject<TValue>(_requestAPIHelper.TextResult);
                return Result.Create(content, default(TError), _requestAPIHelper.StatusCode);
            }

            TError error = JsonConvert.DeserializeObject<TError>(_requestAPIHelper.ExceptionTextResult);
            return Result.Create(default(TValue), error, _requestAPIHelper.StatusCode);
        }

        /// <summary>
        /// Request async method.
        /// </summary>
        /// <typeparam name="TValue">This typeparam is for deserealize a XML result to a model.</typeparam>
        /// <typeparam name="TError">This typeparam is for deserealize a XML error result to a model.</typeparam>
        /// <param name="action">Set params for request.</param>
        /// <returns>
        /// Return a TValue model deserializing an XML result.
        /// </returns>
        public async Task<Result<TValue, TError, HttpStatusCode>> RequestXMLAsync<TValue, TError>(Action<Params> action)
        {
            Params @params = new Params();
            action.Invoke(@params);

            await _requestAPIHelper.RequestAPIAsync(@params);

            if (_requestAPIHelper.StatusCode == @params.HttpStatusCode)
            {
                using (StringReader stringReader = new StringReader(_requestAPIHelper.TextResult))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TValue));
                    TValue content = (TValue)xmlSerializer.Deserialize(stringReader);
                    return Result.Create(content, default(TError), _requestAPIHelper.StatusCode);
                }
            }

            using (StringReader stringReader = new StringReader(_requestAPIHelper.ExceptionTextResult))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TError));
                TError error = (TError)xmlSerializer.Deserialize(stringReader);
                return Result.Create(default(TValue), error, _requestAPIHelper.StatusCode);
            }
        }
    }
}
