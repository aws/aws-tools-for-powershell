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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Adds a MethodResponse to an existing Method resource.
    /// </summary>
    [Cmdlet("Write", "AGMethodResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutMethodResponseResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway PutMethodResponse API operation.", Operation = new[] {"PutMethodResponse"}, SelectReturnType = typeof(Amazon.APIGateway.Model.PutMethodResponseResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutMethodResponseResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.PutMethodResponseResponse object containing multiple properties."
    )]
    public partial class WriteAGMethodResponseCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP verb of the Method resource.</para>
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
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The Resource identifier for the Method resource.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResponseModel
        /// <summary>
        /// <para>
        /// <para>Specifies the Model resources used for the response's content type. Response models
        /// are represented as a key/value map, with a content type as the key and a Model name
        /// as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseModels")]
        public System.Collections.Hashtable ResponseModel { get; set; }
        #endregion
        
        #region Parameter ResponseParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying required or optional response parameters that API Gateway
        /// can send back to the caller. A key defines a method response header name and the associated
        /// value is a Boolean flag indicating whether the method response parameter is required
        /// or not. The method response header names must match the pattern of <c>method.response.header.{name}</c>,
        /// where <c>name</c> is a valid and unique header name. The response parameter names
        /// defined here are available in the integration response to be mapped from an integration
        /// response header expressed in <c>integration.response.header.{name}</c>, a static value
        /// enclosed within a pair of single quotes (e.g., <c>'application/json'</c>), or a JSON
        /// expression from the back-end response payload in the form of <c>integration.response.body.{JSON-expression}</c>,
        /// where <c>JSON-expression</c> is a valid JSON expression without the <c>$</c> prefix.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseParameters")]
        public System.Collections.Hashtable ResponseParameter { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated RestApi.</para>
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
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter StatusCode
        /// <summary>
        /// <para>
        /// <para>The method response's status code.</para>
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
        public System.String StatusCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.PutMethodResponseResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.PutMethodResponseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RestApiId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RestApiId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RestApiId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AGMethodResponse (PutMethodResponse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.PutMethodResponseResponse, WriteAGMethodResponseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RestApiId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HttpMethod = this.HttpMethod;
            #if MODULAR
            if (this.HttpMethod == null && ParameterWasBound(nameof(this.HttpMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter HttpMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResponseModel != null)
            {
                context.ResponseModel = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseModel.Keys)
                {
                    context.ResponseModel.Add((String)hashKey, (System.String)(this.ResponseModel[hashKey]));
                }
            }
            if (this.ResponseParameter != null)
            {
                context.ResponseParameter = new Dictionary<System.String, System.Boolean>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseParameter.Keys)
                {
                    context.ResponseParameter.Add((String)hashKey, (System.Boolean)(this.ResponseParameter[hashKey]));
                }
            }
            context.RestApiId = this.RestApiId;
            #if MODULAR
            if (this.RestApiId == null && ParameterWasBound(nameof(this.RestApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StatusCode = this.StatusCode;
            #if MODULAR
            if (this.StatusCode == null && ParameterWasBound(nameof(this.StatusCode)))
            {
                WriteWarning("You are passing $null as a value for parameter StatusCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.APIGateway.Model.PutMethodResponseRequest();
            
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResponseModel != null)
            {
                request.ResponseModels = cmdletContext.ResponseModel;
            }
            if (cmdletContext.ResponseParameter != null)
            {
                request.ResponseParameters = cmdletContext.ResponseParameter;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StatusCode != null)
            {
                request.StatusCode = cmdletContext.StatusCode;
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
        
        private Amazon.APIGateway.Model.PutMethodResponseResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.PutMethodResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "PutMethodResponse");
            try
            {
                #if DESKTOP
                return client.PutMethodResponse(request);
                #elif CORECLR
                return client.PutMethodResponseAsync(request).GetAwaiter().GetResult();
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
            public System.String HttpMethod { get; set; }
            public System.String ResourceId { get; set; }
            public Dictionary<System.String, System.String> ResponseModel { get; set; }
            public Dictionary<System.String, System.Boolean> ResponseParameter { get; set; }
            public System.String RestApiId { get; set; }
            public System.String StatusCode { get; set; }
            public System.Func<Amazon.APIGateway.Model.PutMethodResponseResponse, WriteAGMethodResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
