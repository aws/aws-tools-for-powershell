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
using System.Threading;
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates an authorizer.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateAuthorizer</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTAuthorizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateAuthorizerResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateAuthorizer API operation.", Operation = new[] {"CreateAuthorizer"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateAuthorizerResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateAuthorizerResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateAuthorizerResponse object containing multiple properties."
    )]
    public partial class NewIOTAuthorizerCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthorizerFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the authorizer's Lambda function.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// <para>When <c>true</c>, the result from the authorizer’s Lambda function is cached for clients
        /// that use persistent HTTP connections. The results are cached for the time specified
        /// by the Lambda function in <c>refreshAfterInSeconds</c>. This value does not affect
        /// authorization of clients that use MQTT connections.</para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableCachingForHttp { get; set; }
        #endregion
        
        #region Parameter SigningDisabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether IoT validates the token signature in an authorization request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SigningDisabled { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the create authorizer request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.AuthorizerStatus")]
        public Amazon.IoT.AuthorizerStatus Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage the custom authorizer.</para><note><para>For URI Request parameters use format: ...key1=value1&amp;key2=value2...</para><para>For the CLI command-line parameter use format: &amp;&amp;tags "key1=value1&amp;key2=value2..."</para><para>For the cli-input-json file use format: "tags": "key1=value1&amp;key2=value2..."</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TokenKeyName
        /// <summary>
        /// <para>
        /// <para>The name of the token key used to extract the token from the HTTP headers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenKeyName { get; set; }
        #endregion
        
        #region Parameter TokenSigningPublicKey
        /// <summary>
        /// <para>
        /// <para>The public keys used to verify the digital signature returned by your custom authentication
        /// service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TokenSigningPublicKeys")]
        public System.Collections.Hashtable TokenSigningPublicKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateAuthorizerResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateAuthorizerResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AuthorizerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTAuthorizer (CreateAuthorizer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateAuthorizerResponse, NewIOTAuthorizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizerFunctionArn = this.AuthorizerFunctionArn;
            #if MODULAR
            if (this.AuthorizerFunctionArn == null && ParameterWasBound(nameof(this.AuthorizerFunctionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizerFunctionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthorizerName = this.AuthorizerName;
            #if MODULAR
            if (this.AuthorizerName == null && ParameterWasBound(nameof(this.AuthorizerName)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableCachingForHttp = this.EnableCachingForHttp;
            context.SigningDisabled = this.SigningDisabled;
            context.Status = this.Status;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.IoT.Model.CreateAuthorizerRequest();
            
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
            if (cmdletContext.SigningDisabled != null)
            {
                request.SigningDisabled = cmdletContext.SigningDisabled.Value;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoT.Model.CreateAuthorizerResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateAuthorizer");
            try
            {
                return client.CreateAuthorizerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? SigningDisabled { get; set; }
            public Amazon.IoT.AuthorizerStatus Status { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.String TokenKeyName { get; set; }
            public Dictionary<System.String, System.String> TokenSigningPublicKey { get; set; }
            public System.Func<Amazon.IoT.Model.CreateAuthorizerResponse, NewIOTAuthorizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
