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
using Amazon;

namespace Amazon.PowerShell.Common.Internal
{
    /// <summary>
    /// Resolves Identity Center instance ID and AWS region from customer-provided SSO endpoints.
    /// Supports AWS-owned portal URLs and vanity domains that redirect to AWS endpoints.
    /// </summary>
    internal static class SSOEndpointResolver
    {
        // AWS-owned domain suffixes for label-boundary matching.
        // Each entry is matched as a suffix on a DNS label boundary (preceded by '.' or equal to the full hostname).
        private static readonly string[] AwsDomainSuffixes = { ".app.aws", ".portal.amazonaws.com", ".awsapps.com" };

        // identitycenter.amazonaws.com is matched as an exact hostname (not a suffix).
        private const string IdentityCenterDomain = "identitycenter.amazonaws.com";

        private static readonly Regex[] UrlPatterns =
        {
            // New portal, DualStack: https://ssoins-72238f444baccc75.portal.us-west-2.app.aws
            new Regex(@"^(https?://)?(?<id>[^.]+)\.portal\.(?<region>[^./]+)\.app\.aws", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1)),
            // New portal, IPv4-only: https://ssoins-72238f444baccc75.us-west-2.portal.amazonaws.com
            new Regex(@"^(https?://)?(?<id>[^.]+)\.(?<region>[^.]+)\.portal\.amazonaws\.com", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1)),
            // Legacy portal: https://d-90670a2e75.awsapps.com
            new Regex(@"^(https?://)?(?<id>[^.]+)\.awsapps\.com", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1)),
            // Issuer URL: https://identitycenter.amazonaws.com/ssoins-72238f444baccc75
            new Regex(@"^(https?://)?identitycenter\.amazonaws\.com/(?<id>[^/]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1)),
        };

        private static readonly TimeSpan HttpTimeout = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Resolves a customer-provided SSO endpoint into both the canonical issuer URL and region
        /// in a single resolution pass (one HTTP redirect at most).
        /// When the URL carries region information, the URL-derived region is used and regionOverride is ignored.
        /// regionOverride is only used as a fallback for region-less URL forms (awsapps.com, issuer URL).
        /// Throws ArgumentException if the URL cannot be resolved to an AWS-generated domain.
        /// </summary>
        internal static async Task<SSOResolvedEndpoint> ResolveAsync(string startUrl, string regionOverride)
        {
            // Determine if the original URL is a vanity domain (not AWS-owned) before resolution.
            var normalizedUrl = startUrl;
            if (!string.IsNullOrEmpty(normalizedUrl) &&
                !normalizedUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !normalizedUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                normalizedUrl = "https://" + normalizedUrl;
            }
            var isVanityUrl = !string.IsNullOrEmpty(normalizedUrl) && !IsAwsDomain(normalizedUrl);

            var resolvedUrl = await ResolveToAwsGeneratedDomainAsync(startUrl).ConfigureAwait(false);
            if (resolvedUrl == null)
            {
                throw new ArgumentException(
                    $"Unable to resolve Identity Center instance from URL: {startUrl}. " +
                    "The URL must be an AWS-generated domain or a vanity domain that redirects to one.");
            }
            var parts = ParseUrl(resolvedUrl, startUrl);
            var issuerUrl = $"https://identitycenter.amazonaws.com/{parts.InstanceId}";
            // When the URL carries region information, use it (sso_region is ignored).
            // Only fall back to regionOverride when the URL does not carry region (awsapps.com, issuer URL).
            var region = !string.IsNullOrEmpty(parts.Region) ? parts.Region : regionOverride;

            // Validate the region parsed from the URL against known AWS region codes.
            // MUST NOT silently fall back to sso_region if the parsed region is invalid.
            if (!string.IsNullOrEmpty(parts.Region) && !IsKnownRegion(parts.Region))
            {
                throw new ArgumentException(
                    $"Region '{parts.Region}' extracted from URL '{startUrl}' is not a known AWS region.");
            }

            return new SSOResolvedEndpoint(issuerUrl, region, isVanityUrl, startUrl, resolvedUrl);
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
        /// Enforces HTTPS: both the initial URL and redirect targets must use HTTPS.
        /// </summary>
        private static async Task<string> ResolveToAwsGeneratedDomainAsync(string url, int maxRedirects)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            // If no scheme is provided, default to https
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
            }

            // sso_start_url MUST use the https scheme
            if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    $"The sso_start_url must use HTTPS: {url}");
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

                    // Every redirect target MUST use https
                    if (!redirectLocation.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException(
                            $"Redirect target must use HTTPS. Got: {redirectLocation}");
                    }

                    currentUrl = redirectLocation;
                }

                if (IsAwsDomain(currentUrl))
                {
                    return currentUrl;
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch
            {
                // Network errors are non-fatal
            }

            return null;
        }

        /// <summary>
        /// Issues an HTTP GET request with auto-redirect disabled and returns the redirect
        /// Location if the response is a redirect (301-308).
        /// Uses GET (not HEAD).
        /// Returns the redirect target URL, or null if no redirect occurred.
        /// </summary>
        private static async Task<string> FollowSingleRedirectAsync(string url)
        {
            using (var handler = new HttpClientHandler { AllowAutoRedirect = false })
            using (var client = new HttpClient(handler) { Timeout = HttpTimeout })
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await client.SendAsync(request).ConfigureAwait(false))
            {
                var statusCode = (int)response.StatusCode;

                if ((statusCode == 301 || statusCode == 302 || statusCode == 303 ||
                     statusCode == 307 || statusCode == 308) && response.Headers.Location != null)
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
        /// Uses case-insensitive, label-boundary suffix matching per RFC 4343.
        /// A hostname matches if it ends with one of the AWS suffixes on a DNS label boundary
        /// (i.e., preceded by '.') or is exactly equal to the suffix without the leading dot.
        /// This prevents look-alike domains like "awsapps.com.evil.net" from matching.
        /// </summary>
        private static bool IsAwsDomain(string url)
        {
            try
            {
                var hostname = new Uri(url).Host.ToLowerInvariant();

                // Check exact match for identitycenter.amazonaws.com
                if (hostname.Equals(IdentityCenterDomain, StringComparison.Ordinal))
                {
                    return true;
                }

                // Check label-boundary suffix match for other domains
                foreach (var suffix in AwsDomainSuffixes)
                {
                    if (hostname.EndsWith(suffix, StringComparison.Ordinal))
                    {
                        return true;
                    }
                    // Also match if hostname equals the suffix without leading dot (e.g., "awsapps.com")
                    var bareHostname = suffix.TrimStart('.');
                    if (hostname.Equals(bareHostname, StringComparison.Ordinal))
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
        /// Validates that the region string is a known AWS region code.
        /// Uses the same check as the SDK's endpoint resolver.
        /// </summary>
        private static bool IsKnownRegion(string region)
        {
            try
            {
                return !string.IsNullOrEmpty(region) &&
                       RegionEndpoint.GetBySystemName(region).DisplayName != "Unknown";
            }
            catch
            {
                return false;
            }
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

    /// <summary>
    /// Contains the resolved issuer URL and region from an SSO endpoint resolution.
    /// </summary>
    internal readonly struct SSOResolvedEndpoint
    {
        /// <summary>
        /// The canonical Identity Center issuer URL (https://identitycenter.amazonaws.com/{idcInstanceId}).
        /// </summary>
        internal string IssuerUrl { get; }

        /// <summary>
        /// The AWS region, or null if not determinable from the URL (legacy/issuer formats without override).
        /// </summary>
        internal string Region { get; }

        /// <summary>
        /// True if the original sso_start_url was a customer vanity URL (not an AWS-owned domain)
        /// that was resolved to an AWS endpoint. Can be used to set SSO_LOGIN_VANITY_URL feature ID
        /// on SSO-OIDC requests.
        /// </summary>
        internal bool IsVanityUrl { get; }

        /// <summary>
        /// The original start URL provided by the user (before resolution).
        /// </summary>
        internal string StartUrl { get; }

        /// <summary>
        /// The AWS-owned URL that the start URL resolved to (after following redirects if needed).
        /// </summary>
        internal string ResolvedUrl { get; }

        internal SSOResolvedEndpoint(string issuerUrl, string region, bool isVanityUrl, string startUrl, string resolvedUrl)
        {
            IssuerUrl = issuerUrl;
            Region = region;
            IsVanityUrl = isVanityUrl;
            StartUrl = startUrl;
            ResolvedUrl = resolvedUrl;
        }
    }
}
