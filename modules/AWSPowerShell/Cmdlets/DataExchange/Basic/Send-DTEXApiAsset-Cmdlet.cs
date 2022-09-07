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
using Amazon.DataExchange;
using Amazon.DataExchange.Model;

namespace Amazon.PowerShell.Cmdlets.DTEX
{
    /// <summary>
    /// This operation invokes an API Gateway API asset. The request is proxied to the provider’s
    /// API Gateway API.
    /// </summary>
    [Cmdlet("Send", "DTEXApiAsset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataExchange.Model.SendApiAssetResponse")]
    [AWSCmdlet("Calls the AWS Data Exchange SendApiAsset API operation.", Operation = new[] {"SendApiAsset"}, SelectReturnType = typeof(Amazon.DataExchange.Model.SendApiAssetResponse))]
    [AWSCmdletOutput("Amazon.DataExchange.Model.SendApiAssetResponse",
        "This cmdlet returns an Amazon.DataExchange.Model.SendApiAssetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendDTEXApiAssetCmdlet : AmazonDataExchangeClientCmdlet, IExecutor
    {
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>Asset ID value for the API request.</para>
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
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>The request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Body { get; set; }
        #endregion
        
        #region Parameter DataSetId
        /// <summary>
        /// <para>
        /// <para>Data set ID value for the API request.</para>
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
        public System.String DataSetId { get; set; }
        #endregion
        
        #region Parameter Method
        /// <summary>
        /// <para>
        /// <para>HTTP method value for the API request. Alternatively, you can use the appropriate
        /// verb in your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Method { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>URI path value for the API request. Alternatively, you can set the URI path directly
        /// by invoking /v1/{pathValue}.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter QueryStringParameter
        /// <summary>
        /// <para>
        /// <para>Attach query string parameters to the end of the URI (for example, /v1/examplePath?exampleParam=exampleValue).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryStringParameters")]
        public System.Collections.Hashtable QueryStringParameter { get; set; }
        #endregion
        
        #region Parameter RequestHeader
        /// <summary>
        /// <para>
        /// <para>Any header value prefixed with x-amzn-dataexchange-header- will have that stripped
        /// before sending the Asset API request. Use this when you want to override a header
        /// that AWS Data Exchange uses. Alternatively, you can use the header without a prefix
        /// to the HTTP request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestHeaders")]
        public System.Collections.Hashtable RequestHeader { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Revision ID value for the API request.</para>
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
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataExchange.Model.SendApiAssetResponse).
        /// Specifying the name of a property of type Amazon.DataExchange.Model.SendApiAssetResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-DTEXApiAsset (SendApiAsset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataExchange.Model.SendApiAssetResponse, SendDTEXApiAssetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetId = this.AssetId;
            #if MODULAR
            if (this.AssetId == null && ParameterWasBound(nameof(this.AssetId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Body = this.Body;
            context.DataSetId = this.DataSetId;
            #if MODULAR
            if (this.DataSetId == null && ParameterWasBound(nameof(this.DataSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Method = this.Method;
            context.Path = this.Path;
            if (this.QueryStringParameter != null)
            {
                context.QueryStringParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.QueryStringParameter.Keys)
                {
                    context.QueryStringParameter.Add((String)hashKey, (String)(this.QueryStringParameter[hashKey]));
                }
            }
            if (this.RequestHeader != null)
            {
                context.RequestHeader = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestHeader.Keys)
                {
                    context.RequestHeader.Add((String)hashKey, (String)(this.RequestHeader[hashKey]));
                }
            }
            context.RevisionId = this.RevisionId;
            #if MODULAR
            if (this.RevisionId == null && ParameterWasBound(nameof(this.RevisionId)))
            {
                WriteWarning("You are passing $null as a value for parameter RevisionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataExchange.Model.SendApiAssetRequest();
            
            if (cmdletContext.AssetId != null)
            {
                request.AssetId = cmdletContext.AssetId;
            }
            if (cmdletContext.Body != null)
            {
                request.Body = cmdletContext.Body;
            }
            if (cmdletContext.DataSetId != null)
            {
                request.DataSetId = cmdletContext.DataSetId;
            }
            if (cmdletContext.Method != null)
            {
                request.Method = cmdletContext.Method;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.QueryStringParameter != null)
            {
                request.QueryStringParameters = cmdletContext.QueryStringParameter;
            }
            if (cmdletContext.RequestHeader != null)
            {
                request.RequestHeaders = cmdletContext.RequestHeader;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
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
        
        private Amazon.DataExchange.Model.SendApiAssetResponse CallAWSServiceOperation(IAmazonDataExchange client, Amazon.DataExchange.Model.SendApiAssetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Exchange", "SendApiAsset");
            try
            {
                #if DESKTOP
                return client.SendApiAsset(request);
                #elif CORECLR
                return client.SendApiAssetAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetId { get; set; }
            public System.String Body { get; set; }
            public System.String DataSetId { get; set; }
            public System.String Method { get; set; }
            public System.String Path { get; set; }
            public Dictionary<System.String, System.String> QueryStringParameter { get; set; }
            public Dictionary<System.String, System.String> RequestHeader { get; set; }
            public System.String RevisionId { get; set; }
            public System.Func<Amazon.DataExchange.Model.SendApiAssetResponse, SendDTEXApiAssetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
