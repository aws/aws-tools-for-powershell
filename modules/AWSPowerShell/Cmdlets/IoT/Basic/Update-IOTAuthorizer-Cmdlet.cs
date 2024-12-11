/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates an authorizer.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateAuthorizer</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTAuthorizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateAuthorizerResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateAuthorizer API operation.", Operation = new[] {"UpdateAuthorizer"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateAuthorizerResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateAuthorizerResponse",
        "This cmdlet returns an Amazon.IoT.Model.UpdateAuthorizerResponse object containing multiple properties."
    )]
    public partial class UpdateIOTAuthorizerCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthorizerFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the authorizer's Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerFunctionArn { get; set; }
        #endregion
        
        #region Parameter AuthorizerName
        /// <summary>
        /// <para>
        /// <para>The authorizer name.</para>
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
        public System.String AuthorizerName { get; set; }
        #endregion
        
        #region Parameter EnableCachingForHttp
        /// <summary>
        /// <para>
        /// <para>When <c>true</c>, the result from the authorizer’s Lambda function is cached for the
        /// time specified in <c>refreshAfterInSeconds</c>. The cached result is used while the
        /// device reuses the same HTTP connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableCachingForHttp { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the update authorizer request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.AuthorizerStatus")]
        public Amazon.IoT.AuthorizerStatus Status { get; set; }
        #endregion
        
        #region Parameter TokenKeyName
        /// <summary>
        /// <para>
        /// <para>The key used to extract the token from the HTTP headers. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenKeyName { get; set; }
        #endregion
        
        #region Parameter TokenSigningPublicKey
        /// <summary>
        /// <para>
        /// <para>The public keys used to verify the token signature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TokenSigningPublicKeys")]
        public System.Collections.Hashtable TokenSigningPublicKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateAuthorizerResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateAuthorizerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AuthorizerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTAuthorizer (UpdateAuthorizer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateAuthorizerResponse, UpdateIOTAuthorizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizerFunctionArn = this.AuthorizerFunctionArn;
            context.AuthorizerName = this.AuthorizerName;
            #if MODULAR
            if (this.AuthorizerName == null && ParameterWasBound(nameof(this.AuthorizerName)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableCachingForHttp = this.EnableCachingForHttp;
            context.Status = this.Status;
            context.TokenKeyName = this.TokenKeyName;
            if (this.TokenSigningPublicKey != null)
            {
                context.TokenSigningPublicKey = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TokenSigningPublicKey.Keys)
                {
                    context.TokenSigningPublicKey.Add((String)hashKey, (System.String)(this.TokenSigningPublicKey[hashKey]));
                }
            }
            
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
            var request = new Amazon.IoT.Model.UpdateAuthorizerRequest();
            
            if (cmdletContext.AuthorizerFunctionArn != null)
            {
                request.AuthorizerFunctionArn = cmdletContext.AuthorizerFunctionArn;
            }
            if (cmdletContext.AuthorizerName != null)
            {
                request.AuthorizerName = cmdletContext.AuthorizerName;
            }
            if (cmdletContext.EnableCachingForHttp != null)
            {
                request.EnableCachingForHttp = cmdletContext.EnableCachingForHttp.Value;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TokenKeyName != null)
            {
                request.TokenKeyName = cmdletContext.TokenKeyName;
            }
            if (cmdletContext.TokenSigningPublicKey != null)
            {
                request.TokenSigningPublicKeys = cmdletContext.TokenSigningPublicKey;
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
        
        private Amazon.IoT.Model.UpdateAuthorizerResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateAuthorizer");
            try
            {
                #if DESKTOP
                return client.UpdateAuthorizer(request);
                #elif CORECLR
                return client.UpdateAuthorizerAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthorizerFunctionArn { get; set; }
            public System.String AuthorizerName { get; set; }
            public System.Boolean? EnableCachingForHttp { get; set; }
            public Amazon.IoT.AuthorizerStatus Status { get; set; }
            public System.String TokenKeyName { get; set; }
            public Dictionary<System.String, System.String> TokenSigningPublicKey { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateAuthorizerResponse, UpdateIOTAuthorizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
