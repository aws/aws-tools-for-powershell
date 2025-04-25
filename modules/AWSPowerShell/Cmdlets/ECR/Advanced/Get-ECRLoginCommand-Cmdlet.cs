/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ECR;
using Amazon.ECR.Model;
using System.Threading;

#pragma warning disable CS0612,CS0618 
namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// <para>
    /// Retrieves a token that is valid for a specified registry for 12 hours and outputs a PSObject containing the decoded username, password, proxy endpoint
    /// and token expiry data, plus a pre-formatted docker login command utilizing those fields that you can execute to log in to your registry with Docker. 
    /// After you have logged in to an Amazon ECR registry with this command, you can use the Docker CLI to push and pull images from that registry until the 
    /// token expires. 
    /// </para>
    /// <para>
    /// The credentials and region required to call the service to obtain the authorization token(s) can be specified using parameters to the cmdlet or 
    /// will be obtained from the shell-default user credential profile and region.
    /// </para>
    /// <para>
    /// <br/><br/>
    /// <b>NOTE:</b> This command writes objects to the pipeline containing authentication credentials. Your credentials could be visible
    /// by other users on your system in a process list display or a command history. If you are not on a secure system, you should consider this risk and 
    /// login interactively. 
    /// </para>
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECR/latest/APIReference/API_GetAuthorizationToken.html">GetAuthorizationToken</a> 
    /// and <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/what-is-ecr.html">What Is Amazon EC2 Container Registry?</a>in the Amazon 
    /// EC2 Container Registry documentation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECRLoginCommand")]
    [OutputType(typeof(PSObject[]))]
    [AWSCmdlet("Obtains time-limited authorization tokens for one or more Amazon EC2 Container Registries and outputs a PSObject containing "
               + "the login user credentials, endpoint data and a pre-formatted login command for your default registry. If one or more registry IDs "
               + "are specified, multiple objects are output containing the login details for each registry.")]
    [AWSCmdletOutput("PSObject[]",
        "This cmdlet returns one or more PSOBjects containing the login data and pre-formatted login command(s) to your registries."
    )]
    public class GetECRLoginCommandCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// Optional collection of one or more AWS account IDs associated with the registries for which to get authorization 
        /// tokens and login commands. If you do not specify any IDs, a single login command for your default registry is output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String[] RegistryId { get; set; }
        #endregion

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                RegistryId = this.RegistryId
            };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            CmdletOutput output;
            
            try
            {
                var request = new GetAuthorizationTokenRequest();
                if (cmdletContext.RegistryId != null && cmdletContext.RegistryId.Length > 0)
                {
                    request.RegistryIds = new List<string>(cmdletContext.RegistryId);
                }

                var response = CallAWSServiceOperation(client, request);

                var loginInfoObjects = new List<PSObject>();

                foreach (var authData in response.AuthorizationData)
                {
                    var authTokenBytes = Convert.FromBase64String(response.AuthorizationData[0].AuthorizationToken);
                    var authToken = Encoding.UTF8.GetString(authTokenBytes);
                    var decodedTokens = authToken.Split(':');
                    var loginCommand = string.Format("docker login --username {0} --password {1} {2}",
                                                     decodedTokens[0],
                                                     decodedTokens[1],
                                                     response.AuthorizationData[0].ProxyEndpoint);

                    var loginInfo = new PSObject();
                    loginInfo.Properties.Add(new PSNoteProperty("Username", decodedTokens[0]));
                    loginInfo.Properties.Add(new PSNoteProperty("Password", decodedTokens[1]));
                    loginInfo.Properties.Add(new PSNoteProperty("ProxyEndpoint", authData.ProxyEndpoint));
                    loginInfo.Properties.Add(new PSAliasProperty("Endpoint", "ProxyEndpoint"));
                    loginInfo.Properties.Add(new PSNoteProperty("ExpiresAt", authData.ExpiresAt));
                    loginInfo.Properties.Add(new PSNoteProperty("Command", loginCommand));

                    loginInfoObjects.Add(loginInfo);
                }

                output = new CmdletOutput
                {
                    PipelineOutput = loginInfoObjects
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.ECR.Model.GetAuthorizationTokenResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.GetAuthorizationTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "GetAuthorizationToken");
            try
            {
                return client.GetAuthorizationTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public System.String[] RegistryId { get; set; }
        }
        
    }
}
