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
using Amazon.RTBFabric;
using Amazon.RTBFabric.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RTB
{
    /// <summary>
    /// Creates an inbound external link.
    /// </summary>
    [Cmdlet("New", "RTBInboundExternalLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse")]
    [AWSCmdlet("Calls the Amazon RTBFabric CreateInboundExternalLink API operation.", Operation = new[] {"CreateInboundExternalLink"}, SelectReturnType = typeof(Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse))]
    [AWSCmdletOutput("Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse",
        "This cmdlet returns an Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse object containing multiple properties."
    )]
    public partial class NewRTBInboundExternalLinkCmdlet : AmazonRTBFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attributes_CustomerProvidedId
        /// <summary>
        /// <para>
        /// <para>The customer-provided unique identifier of the link.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Attributes_CustomerProvidedId { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the gateway.</para>
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
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter Attributes_ResponderErrorMasking
        /// <summary>
        /// <para>
        /// <para>Describes the masking for HTTP error codes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode[] Attributes_ResponderErrorMasking { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign to the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse).
        /// Specifying the name of a property of type Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RTBInboundExternalLink (CreateInboundExternalLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse, NewRTBInboundExternalLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Attributes_CustomerProvidedId = this.Attributes_CustomerProvidedId;
            if (this.Attributes_ResponderErrorMasking != null)
            {
                context.Attributes_ResponderErrorMasking = new List<Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode>(this.Attributes_ResponderErrorMasking);
            }
            context.ClientToken = this.ClientToken;
            context.GatewayId = this.GatewayId;
            #if MODULAR
            if (this.GatewayId == null && ParameterWasBound(nameof(this.GatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.RTBFabric.Model.CreateInboundExternalLinkRequest();
            
            
             // populate Attributes
            var requestAttributesIsNull = true;
            request.Attributes = new Amazon.RTBFabric.Model.LinkAttributes();
            System.String requestAttributes_attributes_CustomerProvidedId = null;
            if (cmdletContext.Attributes_CustomerProvidedId != null)
            {
                requestAttributes_attributes_CustomerProvidedId = cmdletContext.Attributes_CustomerProvidedId;
            }
            if (requestAttributes_attributes_CustomerProvidedId != null)
            {
                request.Attributes.CustomerProvidedId = requestAttributes_attributes_CustomerProvidedId;
                requestAttributesIsNull = false;
            }
            List<Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode> requestAttributes_attributes_ResponderErrorMasking = null;
            if (cmdletContext.Attributes_ResponderErrorMasking != null)
            {
                requestAttributes_attributes_ResponderErrorMasking = cmdletContext.Attributes_ResponderErrorMasking;
            }
            if (requestAttributes_attributes_ResponderErrorMasking != null)
            {
                request.Attributes.ResponderErrorMasking = requestAttributes_attributes_ResponderErrorMasking;
                requestAttributesIsNull = false;
            }
             // determine if request.Attributes should be set to null
            if (requestAttributesIsNull)
            {
                request.Attributes = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse CallAWSServiceOperation(IAmazonRTBFabric client, Amazon.RTBFabric.Model.CreateInboundExternalLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon RTBFabric", "CreateInboundExternalLink");
            try
            {
                return client.CreateInboundExternalLinkAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Attributes_CustomerProvidedId { get; set; }
            public List<Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode> Attributes_ResponderErrorMasking { get; set; }
            public System.String ClientToken { get; set; }
            public System.String GatewayId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.RTBFabric.Model.CreateInboundExternalLinkResponse, NewRTBInboundExternalLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
