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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Removes one or more custom attributes, of the same attribute type, from the application.
    /// Existing endpoints still have the attributes but Amazon Pinpoint will stop capturing
    /// new or changed values for these attributes.
    /// </summary>
    [Cmdlet("Remove", "PINAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Pinpoint.Model.AttributesResource")]
    [AWSCmdlet("Calls the Amazon Pinpoint RemoveAttributes API operation.", Operation = new[] {"RemoveAttributes"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.RemoveAttributesResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.AttributesResource or Amazon.Pinpoint.Model.RemoveAttributesResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.AttributesResource object.",
        "The service call response (type Amazon.Pinpoint.Model.RemoveAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemovePINAttributeCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter AttributeType
        /// <summary>
        /// <para>
        /// <para>The type of attribute or attributes to remove. Valid values are:</para><ul><li><para>endpoint-custom-attributes - Custom attributes that describe endpoints, such as the
        /// date when an associated user opted in or out of receiving communications from you
        /// through a specific type of channel.</para></li><li><para>endpoint-metric-attributes - Custom metrics that your app reports to Amazon Pinpoint
        /// for endpoints, such as the number of app sessions or the number of items left in a
        /// cart.</para></li><li><para>endpoint-user-attributes - Custom attributes that describe users, such as first name,
        /// last name, and age.</para></li></ul>
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
        public System.String AttributeType { get; set; }
        #endregion
        
        #region Parameter UpdateAttributesRequest_Blacklist
        /// <summary>
        /// <para>
        /// <para>An array of the attributes to remove from all the endpoints that are associated with
        /// the application. The array can specify the complete, exact name of each attribute
        /// to remove or it can specify a glob pattern that an attribute name must match in order
        /// for the attribute to be removed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] UpdateAttributesRequest_Blacklist { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AttributesResource'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.RemoveAttributesResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.RemoveAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AttributesResource";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PINAttribute (RemoveAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.RemoveAttributesResponse, RemovePINAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttributeType = this.AttributeType;
            #if MODULAR
            if (this.AttributeType == null && ParameterWasBound(nameof(this.AttributeType)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UpdateAttributesRequest_Blacklist != null)
            {
                context.UpdateAttributesRequest_Blacklist = new List<System.String>(this.UpdateAttributesRequest_Blacklist);
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
            var request = new Amazon.Pinpoint.Model.RemoveAttributesRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AttributeType != null)
            {
                request.AttributeType = cmdletContext.AttributeType;
            }
            
             // populate UpdateAttributesRequest
            request.UpdateAttributesRequest = new Amazon.Pinpoint.Model.UpdateAttributesRequest();
            List<System.String> requestUpdateAttributesRequest_updateAttributesRequest_Blacklist = null;
            if (cmdletContext.UpdateAttributesRequest_Blacklist != null)
            {
                requestUpdateAttributesRequest_updateAttributesRequest_Blacklist = cmdletContext.UpdateAttributesRequest_Blacklist;
            }
            if (requestUpdateAttributesRequest_updateAttributesRequest_Blacklist != null)
            {
                request.UpdateAttributesRequest.Blacklist = requestUpdateAttributesRequest_updateAttributesRequest_Blacklist;
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
        
        private Amazon.Pinpoint.Model.RemoveAttributesResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.RemoveAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "RemoveAttributes");
            try
            {
                return client.RemoveAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttributeType { get; set; }
            public List<System.String> UpdateAttributesRequest_Blacklist { get; set; }
            public System.Func<Amazon.Pinpoint.Model.RemoveAttributesResponse, RemovePINAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AttributesResource;
        }
        
    }
}
