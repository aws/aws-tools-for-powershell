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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Disassociates a set of queues from a routing profile.
    /// 
    ///  
    /// <para>
    /// Up to 10 queue references can be disassociated in a single API call. More than 10
    /// queue references results in a single call results in an InvalidParameterException.
    /// </para>
    /// </summary>
    [Cmdlet("Disconnect", "CONNRoutingProfileQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service DisassociateRoutingProfileQueues API operation.", Operation = new[] {"DisassociateRoutingProfileQueues"}, SelectReturnType = typeof(Amazon.Connect.Model.DisassociateRoutingProfileQueuesResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.DisassociateRoutingProfileQueuesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.DisassociateRoutingProfileQueuesResponse) be returned by specifying '-Select *'."
    )]
    public partial class DisconnectCONNRoutingProfileQueueCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ManualAssignmentQueueReference
        /// <summary>
        /// <para>
        /// <para>The manual assignment queues to disassociate with this routing profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManualAssignmentQueueReferences")]
        public Amazon.Connect.Model.RoutingProfileQueueReference[] ManualAssignmentQueueReference { get; set; }
        #endregion
        
        #region Parameter QueueReference
        /// <summary>
        /// <para>
        /// <para>The queues to disassociate from this routing profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueueReferences")]
        public Amazon.Connect.Model.RoutingProfileQueueReference[] QueueReference { get; set; }
        #endregion
        
        #region Parameter RoutingProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier of the routing profile.</para>
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
        public System.String RoutingProfileId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.DisassociateRoutingProfileQueuesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disconnect-CONNRoutingProfileQueue (DisassociateRoutingProfileQueues)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.DisassociateRoutingProfileQueuesResponse, DisconnectCONNRoutingProfileQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ManualAssignmentQueueReference != null)
            {
                context.ManualAssignmentQueueReference = new List<Amazon.Connect.Model.RoutingProfileQueueReference>(this.ManualAssignmentQueueReference);
            }
            if (this.QueueReference != null)
            {
                context.QueueReference = new List<Amazon.Connect.Model.RoutingProfileQueueReference>(this.QueueReference);
            }
            context.RoutingProfileId = this.RoutingProfileId;
            #if MODULAR
            if (this.RoutingProfileId == null && ParameterWasBound(nameof(this.RoutingProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.DisassociateRoutingProfileQueuesRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.ManualAssignmentQueueReference != null)
            {
                request.ManualAssignmentQueueReferences = cmdletContext.ManualAssignmentQueueReference;
            }
            if (cmdletContext.QueueReference != null)
            {
                request.QueueReferences = cmdletContext.QueueReference;
            }
            if (cmdletContext.RoutingProfileId != null)
            {
                request.RoutingProfileId = cmdletContext.RoutingProfileId;
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
        
        private Amazon.Connect.Model.DisassociateRoutingProfileQueuesResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.DisassociateRoutingProfileQueuesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "DisassociateRoutingProfileQueues");
            try
            {
                #if DESKTOP
                return client.DisassociateRoutingProfileQueues(request);
                #elif CORECLR
                return client.DisassociateRoutingProfileQueuesAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public List<Amazon.Connect.Model.RoutingProfileQueueReference> ManualAssignmentQueueReference { get; set; }
            public List<Amazon.Connect.Model.RoutingProfileQueueReference> QueueReference { get; set; }
            public System.String RoutingProfileId { get; set; }
            public System.Func<Amazon.Connect.Model.DisassociateRoutingProfileQueuesResponse, DisconnectCONNRoutingProfileQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
