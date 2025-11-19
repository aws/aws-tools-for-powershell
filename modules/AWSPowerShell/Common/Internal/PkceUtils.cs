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
using System.Security.Cryptography;
using System.Text;

namespace Amazon.PowerShell.Common.Internal
{
    /// <summary>
    /// Contains PKCE (Proof Key for Code Exchange) parameters per RFC 7636.
    /// </summary>
    public class PkceParameters
    {
        /// <summary>
        /// The code verifier - a cryptographically random string (128 characters).
        /// </summary>
        public string CodeVerifier { get; set; }

        /// <summary>
        /// The code challenge - BASE64URL(SHA256(CodeVerifier)) (43 characters).
        /// </summary>
        public string CodeChallenge { get; set; }

        /// <summary>
        /// The code challenge method.
        /// </summary>
        public string CodeChallengeMethod => "SHA-256";
    }

    /// <summary>
    /// Utility methods for PKCE (Proof Key for Code Exchange) per RFC 7636.
    /// </summary>
    public static class PkceUtils
    {
        /// <summary>
        /// Generates PKCE parameters (code_verifier and code_challenge).
        /// </summary>
        /// <returns>PkceParameters object containing code_verifier and code_challenge</returns>
        public static PkceParameters GeneratePkceParameters()
        {
            var codeVerifier = GenerateCodeVerifier();
            var codeChallenge = GenerateCodeChallenge(codeVerifier);
            
            return new PkceParameters
            {
                CodeVerifier = codeVerifier,
                CodeChallenge = codeChallenge
            };
        }

        /// <summary>
        /// Generates a CSRF prevention state token. This is a non-guessable, opaque value (cryptographically random UUID v4).
        /// </summary>
        public static string GenerateState()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates a cryptographically random code_verifier of 128 characters from [A-Z, a-z, 0-9, -._~]
        /// </summary>
        private static string GenerateCodeVerifier()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-._~";
            var random = new byte[128];
            
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
            }

            var result = new StringBuilder(128);
            for (int i = 0; i < 128; i++)
            {
                result.Append(chars[random[i] % chars.Length]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Generates code_challenge from code_verifier. This should be BASE64URL(SHA256(code_verifier)) of exactly 43 bytes.
        /// </summary>
        private static string GenerateCodeChallenge(string codeVerifier)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.ASCII.GetBytes(codeVerifier));
                return Utils.Common.Base64UrlEncode(hash);
            }
        }
    }
}
