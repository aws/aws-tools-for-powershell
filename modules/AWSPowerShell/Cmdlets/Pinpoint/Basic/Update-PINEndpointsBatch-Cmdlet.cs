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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates a new batch of endpoints for an application or updates the settings and attributes
    /// of a batch of existing endpoints for an application. You can also use this operation
    /// to define custom attributes for a batch of endpoints. If an update includes one or
    /// more values for a custom attribute, Amazon Pinpoint replaces (overwrites) any existing
    /// values with the new values.
    /// </summary>
    [Cmdlet("Update", "PINEndpointsBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateEndpointsBatch API operation.", Operation = new[] {"UpdateEndpointsBatch"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageBody or Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINEndpointsBatchCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter EndpointBatchRequest_Item
        /// <summary>
        /// <para>
        /// <para>An array that defines the endpoints to create or update and, for each endpoint, the
        /// property values to set or change. An array can contain a maximum of 100 items.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Pinpoint.Model.EndpointBatchItem[] EndpointBatchRequest_Item { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageBody";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINEndpointsBatch (UpdateEndpointsBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse, UpdatePINEndpointsBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EndpointBatchRequest_Item != null)
            {
                context.EndpointBatchRequest_Item = new List<Amazon.Pinpoint.Model.EndpointBatchItem>(this.EndpointBatchRequest_Item);
            }
            #if MODULAR
            if (this.EndpointBatchRequest_Item == null && ParameterWasBound(nameof(this.EndpointBatchRequest_Item)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointBatchRequest_Item which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.UpdateEndpointsBatchRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate EndpointBatchRequest
            var requestEndpointBatchRequestIsNull = true;
            request.EndpointBatchRequest = new Amazon.Pinpoint.Model.EndpointBatchRequest();
            List<Amazon.Pinpoint.Model.EndpointBatchItem> requestEndpointBatchRequest_endpointBatchRequest_Item = null;
            if (cmdletContext.EndpointBatchRequest_Item != null)
            {
                requestEndpointBatchRequest_endpointBatchRequest_Item = cmdletContext.EndpointBatchRequest_Item;
            }
            if (requestEndpointBatchRequest_endpointBatchRequest_Item != null)
            {
                request.EndpointBatchRequest.Item = requestEndpointBatchRequest_endpointBatchRequest_Item;
                requestEndpointBatchRequestIsNull = false;
            }
             // determine if request.EndpointBatchRequest should be set to null
            if (requestEndpointBatchRequestIsNull)
            {
                request.EndpointBatchRequest = null;
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
        
        private Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateEndpointsBatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateEndpointsBatch");
            try
            {
                #if DESKTOP
                return client.UpdateEndpointsBatch(request);
                #elif CORECLR
                return client.UpdateEndpointsBatchAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public List<Amazon.Pinpoint.Model.EndpointBatchItem> EndpointBatchRequest_Item { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateEndpointsBatchResponse, UpdatePINEndpointsBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageBody;
        }
        
    }
}
