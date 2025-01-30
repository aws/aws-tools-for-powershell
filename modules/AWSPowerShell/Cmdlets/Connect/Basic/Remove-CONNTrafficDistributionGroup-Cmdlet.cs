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
    /// Deletes a traffic distribution group. This API can be called only in the Region where
    /// the traffic distribution group is created.
    /// 
    ///  
    /// <para>
    /// For more information about deleting traffic distribution groups, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/delete-traffic-distribution-groups.html">Delete
    /// traffic distribution groups</a> in the <i>Amazon Connect Administrator Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CONNTrafficDistributionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service DeleteTrafficDistributionGroup API operation.", Operation = new[] {"DeleteTrafficDistributionGroup"}, SelectReturnType = typeof(Amazon.Connect.Model.DeleteTrafficDistributionGroupResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.DeleteTrafficDistributionGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.DeleteTrafficDistributionGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCONNTrafficDistributionGroupCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TrafficDistributionGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the traffic distribution group. This can be the ID or the ARN of
        /// the traffic distribution group.</para>
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
        public System.String TrafficDistributionGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.DeleteTrafficDistributionGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrafficDistributionGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrafficDistributionGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrafficDistributionGroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficDistributionGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CONNTrafficDistributionGroup (DeleteTrafficDistributionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.DeleteTrafficDistributionGroupResponse, RemoveCONNTrafficDistributionGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrafficDistributionGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TrafficDistributionGroupId = this.TrafficDistributionGroupId;
            #if MODULAR
            if (this.TrafficDistributionGroupId == null && ParameterWasBound(nameof(this.TrafficDistributionGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficDistributionGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.DeleteTrafficDistributionGroupRequest();
            
            if (cmdletContext.TrafficDistributionGroupId != null)
            {
                request.TrafficDistributionGroupId = cmdletContext.TrafficDistributionGroupId;
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
        
        private Amazon.Connect.Model.DeleteTrafficDistributionGroupResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.DeleteTrafficDistributionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "DeleteTrafficDistributionGroup");
            try
            {
                #if DESKTOP
                return client.DeleteTrafficDistributionGroup(request);
                #elif CORECLR
                return client.DeleteTrafficDistributionGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String TrafficDistributionGroupId { get; set; }
            public System.Func<Amazon.Connect.Model.DeleteTrafficDistributionGroupResponse, RemoveCONNTrafficDistributionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
