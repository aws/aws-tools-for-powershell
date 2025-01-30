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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Returns metadata related to the given identity, including when the identity was created
    /// and any associated linked logins.
    /// 
    ///  
    /// <para>
    /// You must use AWS Developer credentials to call this API.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CGIIdentity")]
    [OutputType("Amazon.CognitoIdentity.Model.DescribeIdentityResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity DescribeIdentity API operation.", Operation = new[] {"DescribeIdentity"}, SelectReturnType = typeof(Amazon.CognitoIdentity.Model.DescribeIdentityResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentity.Model.DescribeIdentityResponse",
        "This cmdlet returns an Amazon.CognitoIdentity.Model.DescribeIdentityResponse object containing multiple properties."
    )]
    public partial class GetCGIIdentityCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// <para>A unique identifier in the format REGION:GUID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentity.Model.DescribeIdentityResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentity.Model.DescribeIdentityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdentityId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdentityId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdentityId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentity.Model.DescribeIdentityResponse, GetCGIIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdentityId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IdentityId = this.IdentityId;
            #if MODULAR
            if (this.IdentityId == null && ParameterWasBound(nameof(this.IdentityId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CognitoIdentity.Model.DescribeIdentityRequest();
            
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.CognitoIdentity.Model.DescribeIdentityResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.DescribeIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "DescribeIdentity");
            try
            {
                #if DESKTOP
                return client.DescribeIdentity(request);
                #elif CORECLR
                return client.DescribeIdentityAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String IdentityId { get; set; }
            public System.Func<Amazon.CognitoIdentity.Model.DescribeIdentityResponse, GetCGIIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
