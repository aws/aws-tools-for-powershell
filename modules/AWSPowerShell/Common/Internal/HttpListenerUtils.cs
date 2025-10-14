/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 * 
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *  
 */

using Amazon.Runtime;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.PowerShell.Common.Internal
{
    /// <summary>
    /// Contains the result of starting an HTTP listener.
    /// </summary>
    public class HttpListenerResult : IDisposable
    {
        /// <summary>
        /// The redirect URI where the listener is accepting requests.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Task that completes when a request is received.
        /// </summary>
        public Task<HttpListenerContext> RequestTask { get; set; }

        /// <summary>
        /// The underlying HTTP listener. Must be disposed after sending response.
        /// </summary>
        internal HttpListener Listener { get; set; }

        /// <summary>
        /// Stops and disposes the HTTP listener. Call after sending response.
        /// </summary>
        public void Dispose()
        {
            try
            {
                Listener?.Stop();
                Listener?.Close();
                (Listener as IDisposable)?.Dispose();
            }
            catch
            {
                // Best effort cleanup
            }
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Utility methods for HTTP listener operations.
    /// </summary>
    public static class HttpListenerUtils
    {
        /// <summary>
        /// Starts an HTTP listener on an available port and waits for a single request.
        /// Returns the HttpListenerContext for processing query parameters and other request data.
        /// </summary>
        /// <param name="path">The path to listen on (e.g., "/oauth/callback/")</param>
        /// <param name="cancellationToken">Cancellation token to stop listening</param>
        /// <returns>HttpListenerResult containing the redirect URI and a task that completes with the request context</returns>
        /// <exception cref="AmazonClientException">Thrown when the web server fails to start (SEP requirement)</exception>
        public static HttpListenerResult StartListenerAsync(
            string path,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be null or empty", nameof(path));
            
            if (!path.EndsWith("/"))
                path += "/";

            const int minPort = 1024;
            const int maxPort = 65535;
            const int randomAttempts = 10;
            const int sequentialScanSize = 100;

            var random = new Random();
            HttpListener listener = null;
            string redirectUri = null;

            // Fast path: Try random ports first (most likely to succeed quickly)
            for (int i = 0; i < randomAttempts; i++)
            {
                var port = random.Next(minPort, maxPort + 1);
                if (TryStartListener(port, path, out listener, out redirectUri))
                    break;
            }

            // Fallback: Sequential scan of limited range if random attempts failed
            if (listener == null)
            {
                var scanStart = random.Next(minPort, maxPort - sequentialScanSize + 1);
                for (int port = scanStart; port < scanStart + sequentialScanSize; port++)
                {
                    if (TryStartListener(port, path, out listener, out redirectUri))
                        break;
                }
            }

            if (listener == null)
            {
                throw new AmazonClientException("Failed to start local web server. No available ports found.");
            }
            var task = WaitForRequestAsync(listener, cancellationToken);
            return new HttpListenerResult
            {
                RedirectUri = redirectUri,
                RequestTask = task,
                Listener = listener
            };
        }

        /// <summary>
        /// Attempts to start an HTTP listener on the specified port.
        /// </summary>
        private static bool TryStartListener(int port, string path, out HttpListener listener, out string redirectUri)
        {
            listener = null;
            redirectUri = null;

            try
            {
                listener = new HttpListener();
                var prefixUrl = $"http://127.0.0.1:{port}{path}";
                listener.Prefixes.Add(prefixUrl);
                listener.Start();
                redirectUri = prefixUrl;
                return true;
            }
            catch (HttpListenerException)
            {
                listener?.Close();
                listener = null;
                return false;
            }
        }

        /// <summary>
        /// Waits for a single HTTP request and returns the context.
        /// Note: Caller is responsible for closing the response and disposing the listener.
        /// </summary>
        /// <param name="listener">The HTTP listener to wait on</param>
        /// <param name="cancellationToken">Token to cancel the wait operation</param>
        /// <returns>The HTTP listener context containing request and response objects</returns>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested</exception>
        private static async Task<HttpListenerContext> WaitForRequestAsync(
            HttpListener listener,
            CancellationToken cancellationToken)
        {
            try
            {
                using (cancellationToken.Register(() => listener.Stop()))
                {
                    var context = await listener.GetContextAsync().ConfigureAwait(false);
                    return context;
                }
            }
            catch (HttpListenerException) when (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("HTTP listener was cancelled.", cancellationToken);
            }
            catch (ObjectDisposedException) when (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("HTTP listener was cancelled.", cancellationToken);
            }
        }
    }
}
