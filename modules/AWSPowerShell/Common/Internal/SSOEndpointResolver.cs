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

using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Amazon.PowerShell.Common.Internal
{
    /// <summary>
    /// Resolves Identity Center instance ID and AWS region from customer-provided SSO endpoints.
    /// Supports AWS-owned portal URLs and vanity domains that redirect to AWS endpoints.
    /// </summary>
    internal static class SSOEndpointResolver
    {
        private static readonly string[] AwsDomains = { ".app.aws", ".portal.amazonaws.com", ".awsapps.com", "identitycenter.amazonaws.com" };

        private static readonly Regex[] UrlPatterns =
        {
            // New portal, DualStack: https://ssoins-72238f444baccc75.portal.us-west-2.app.aws
            new Regex(@"^(https?://)?(?<id>[^.]+)\.portal\.(?<region>[^./]+)\.app\.aws", RegexOptions.Compiled, TimeSpan.FromSeconds(1)),
            // New portal, IPv4-only: https://ssoins-72238f444baccc75.us-west-2.portal.amazonaws.com
            new Regex(@"^(https?://)?(?<id>[^.]+)\.(?<region>[^.]+)\.portal\.amazonaws\.com", RegexOptions.Compiled, TimeSpan.FromSeconds(1)),
            // Legacy portal: https://d-90670a2e75.awsapps.com
            new Regex(@"^(https?://)?(?<id>[^.]+)\.awsapps\.com", RegexOptions.Compiled, TimeSpan.FromSeconds(1)),
            // Issuer URL: https://identitycenter.amazonaws.com/ssoins-72238f444baccc75
            new Regex(@"^(https?://)?identitycenter\.amazonaws\.com/(?<id>[^/]+)", RegexOptions.Compiled, TimeSpan.FromSeconds(1)),
        };

        private static readonly TimeSpan HttpTimeout = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Resolves an SSO start URL into the canonical Identity Center issuer URL.
        /// Format: https://identitycenter.amazonaws.com/{idcInstanceId}
        /// </summary>
        internal static async Task<string> ResolveIssuerUrlAsync(string startUrl)
        {
            var resolvedUrl = await ResolveToAwsGeneratedDomainAsync(startUrl).ConfigureAwait(false);
            if (resolvedUrl == null)
            {
                throw new ArgumentException(
                    $"Unable to resolve Identity Center instance from URL: {startUrl}. " +
                    "The URL must be an AWS-generated domain or a vanity domain that redirects to one.");
            }
            var parts = ParseUrl(resolvedUrl, startUrl);
            return $"https://identitycenter.amazonaws.com/{parts.InstanceId}";
        }

        /// <summary>
        /// Resolves the AWS region from a customer-provided SSO endpoint.
        /// If regionOverride is provided, it takes precedence.
        /// Returns null if region cannot be determined (caller must handle).
        /// </summary>
        internal static async Task<string> ResolveRegionAsync(string startUrl, string regionOverride)
        {
            if (!string.IsNullOrEmpty(regionOverride))
            {
                return regionOverride;
            }

            if (string.IsNullOrEmpty(startUrl))
            {
                return null;
            }

            var resolvedUrl = await ResolveToAwsGeneratedDomainAsync(startUrl).ConfigureAwait(false);
            if (resolvedUrl == null)
            {
                return null;
            }

            foreach (var pattern in UrlPatterns)
            {
                var match = pattern.Match(resolvedUrl);
                if (match.Success && match.Groups["region"].Success)
                {
                    return match.Groups["region"].Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks if the URL is an AWS-generated domain. If not, follows up to 1 redirect
        /// and checks again. Returns the AWS-generated URL if found, or null if the URL
        /// cannot be resolved to an AWS-generated domain.
        /// </summary>
        private static async Task<string> ResolveToAwsGeneratedDomainAsync(string url)
        {
            return await ResolveToAwsGeneratedDomainAsync(url, maxRedirects: 1).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if the URL is an AWS-generated domain. If not, follows the redirect chain
        /// up to maxRedirects hops, then checks if the final location is an AWS-generated domain.
        /// Returns the AWS-generated URL if found, or null otherwise.
        /// </summary>
        private static async Task<string> ResolveToAwsGeneratedDomainAsync(string url, int maxRedirects)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
            }

            if (IsAwsDomain(url))
            {
                return url;
            }

            try
            {
                var currentUrl = url;
                for (int i = 0; i < maxRedirects; i++)
                {
                    var redirectLocation = await FollowSingleRedirectAsync(currentUrl).ConfigureAwait(false);
                    if (redirectLocation == null)
                    {
                        break;
                    }
                    currentUrl = redirectLocation;
                }

                if (IsAwsDomain(currentUrl))
                {
                    return currentUrl;
                }
            }
            catch
            {
                // Network errors are non-fatal
            }

            return null;
        }

        /// <summary>
        /// Attempts to follow a single HTTP redirect from the given URL.
        /// Tries HEAD first since only the Location header is needed.
        /// Falls back to GET if the server rejects HEAD (e.g. 405 Method Not Allowed),
        /// since not all servers/load balancers support HEAD requests.
        /// Returns the redirect target URL, or null if no redirect occurred.
        /// </summary>
        private static async Task<string> FollowSingleRedirectAsync(string url)
        {
            var location = await TrySendRequestAsync(url, HttpMethod.Head).ConfigureAwait(false);
            if (location != null)
            {
                return location;
            }
            return await TrySendRequestAsync(url, HttpMethod.Get).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends an HTTP request with auto-redirect disabled and returns the Location header
        /// value if the response is a redirect (301-308). Returns null for non-redirect responses.
        /// Resolves relative Location URIs against the request URL.
        /// </summary>
        private static async Task<string> TrySendRequestAsync(string url, HttpMethod method)
        {
            using (var handler = new HttpClientHandler { AllowAutoRedirect = false })
            using (var client = new HttpClient(handler) { Timeout = HttpTimeout })
            using (var request = new HttpRequestMessage(method, url))
            {
                var response = await client.SendAsync(request).ConfigureAwait(false);
                var statusCode = (int)response.StatusCode;

                if (statusCode >= 301 && statusCode <= 308 && response.Headers.Location != null)
                {
                    var location = response.Headers.Location;
                    if (location.IsAbsoluteUri)
                    {
                        return location.AbsoluteUri;
                    }
                    // Resolve relative URI against the request URL
                    var baseUri = new Uri(url);
                    var resolved = new Uri(baseUri, location);
                    return resolved.AbsoluteUri;
                }

                return null;
            }
        }

        /// <summary>
        /// Checks if a URL belongs to a known AWS-generated Identity Center domain.
        /// Matches against: .app.aws, .portal.amazonaws.com, .awsapps.com, identitycenter.amazonaws.com.
        /// </summary>
        private static bool IsAwsDomain(string url)
        {
            try
            {
                var hostname = new Uri(url).Host;
                foreach (var domain in AwsDomains)
                {
                    if (hostname.EndsWith(domain, StringComparison.OrdinalIgnoreCase) ||
                        hostname.Equals(domain.TrimStart('.'), StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            catch (UriFormatException)
            {
            }
            return false;
        }

        /// <summary>
        /// Parses an AWS-generated URL to extract the Identity Center instance ID and optionally the region.
        /// Throws ArgumentException if the URL does not match any known pattern.
        /// </summary>
        private static SSOEndpointParts ParseUrl(string resolvedUrl, string originalUrl)
        {
            foreach (var pattern in UrlPatterns)
            {
                var match = pattern.Match(resolvedUrl);
                if (match.Success)
                {
                    var id = match.Groups["id"].Value;
                    var region = match.Groups["region"].Success ? match.Groups["region"].Value : null;
                    return new SSOEndpointParts(id, region);
                }
            }

            throw new ArgumentException(
                $"Unable to resolve Identity Center instance from URL: {originalUrl}. " +
                "Supported formats: https://{{id}}.portal.{{region}}.app.aws, " +
                "https://{{id}}.{{region}}.portal.amazonaws.com, " +
                "https://{{id}}.awsapps.com, " +
                "https://identitycenter.amazonaws.com/{{id}}, " +
                "or a vanity domain that redirects to one of these.");
        }

        private readonly struct SSOEndpointParts
        {
            internal string InstanceId { get; }
            internal string Region { get; }

            internal SSOEndpointParts(string instanceId, string region)
            {
                InstanceId = instanceId;
                Region = region;
            }
        }
    }
}
