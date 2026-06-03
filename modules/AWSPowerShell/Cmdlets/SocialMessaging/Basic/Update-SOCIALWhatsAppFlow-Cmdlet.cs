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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Updates the metadata of a WhatsApp Flow, such as its name or categories. This does
    /// not update the Flow JSON definition. Use <a href="https://docs.aws.amazon.com/social-messaging/latest/APIReference/API_UpdateWhatsAppFlowAssets.html">UpdateWhatsAppFlowAssets</a>
    /// to update the Flow JSON.
    /// </summary>
    [Cmdlet("Update", "SOCIALWhatsAppFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS End User Messaging Social UpdateWhatsAppFlow API operation.", Operation = new[] {"UpdateWhatsAppFlow"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.UpdateWhatsAppFlowResponse))]
    [AWSCmdletOutput("None or Amazon.SocialMessaging.Model.UpdateWhatsAppFlowResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SocialMessaging.Model.UpdateWhatsAppFlowResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSOCIALWhatsAppFlowCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>The updated categories for the Flow.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Categories")]
        public System.String[] Category { get; set; }
        #endregion
        
        #region Parameter FlowId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Flow to update.</para>
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
        public System.String FlowId { get; set; }
        #endregion
        
        #region Parameter FlowName
        /// <summary>
        /// <para>
        /// <para>The updated name for the Flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowName { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the WhatsApp Business Account associated with this Flow.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.UpdateWhatsAppFlowResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.FlowId),
                nameof(this.Id)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SOCIALWhatsAppFlow (UpdateWhatsAppFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.UpdateWhatsAppFlowResponse, UpdateSOCIALWhatsAppFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Category != null)
            {
                context.Category = new List<System.String>(this.Category);
            }
            context.FlowId = this.FlowId;
            #if MODULAR
            if (this.FlowId == null && ParameterWasBound(nameof(this.FlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlowName = this.FlowName;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SocialMessaging.Model.UpdateWhatsAppFlowRequest();
            
            if (cmdletContext.Category != null)
            {
                request.Categories = cmdletContext.Category;
            }
            if (cmdletContext.FlowId != null)
            {
                request.FlowId = cmdletContext.FlowId;
            }
            if (cmdletContext.FlowName != null)
            {
                request.FlowName = cmdletContext.FlowName;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.SocialMessaging.Model.UpdateWhatsAppFlowResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.UpdateWhatsAppFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "UpdateWhatsAppFlow");
            try
            {
                return client.UpdateWhatsAppFlowAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Category { get; set; }
            public System.String FlowId { get; set; }
            public System.String FlowName { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.UpdateWhatsAppFlowResponse, UpdateSOCIALWhatsAppFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
