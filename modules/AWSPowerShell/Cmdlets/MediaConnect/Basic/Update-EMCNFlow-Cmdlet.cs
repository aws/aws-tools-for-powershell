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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates flow
    /// </summary>
    [Cmdlet("Update", "EMCNFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Flow")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlow API operation.", Operation = new[] {"UpdateFlow"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateFlowResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Flow or Amazon.MediaConnect.Model.UpdateFlowResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Flow object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEMCNFlowCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that you want to update.
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
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter SourceFailoverConfig_RecoveryWindow
        /// <summary>
        /// <para>
        /// Recovery window time to look for dash-7
        /// packets
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SourceFailoverConfig_RecoveryWindow { get; set; }
        #endregion
        
        #region Parameter SourceFailoverConfig_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.State")]
        public Amazon.MediaConnect.State SourceFailoverConfig_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Flow'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateFlowResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateFlowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Flow";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlowArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlowArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlowArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlow (UpdateFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowResponse, UpdateEMCNFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlowArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceFailoverConfig_RecoveryWindow = this.SourceFailoverConfig_RecoveryWindow;
            context.SourceFailoverConfig_State = this.SourceFailoverConfig_State;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowRequest();
            
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            
             // populate SourceFailoverConfig
            var requestSourceFailoverConfigIsNull = true;
            request.SourceFailoverConfig = new Amazon.MediaConnect.Model.UpdateFailoverConfig();
            System.Int32? requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow = null;
            if (cmdletContext.SourceFailoverConfig_RecoveryWindow != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow = cmdletContext.SourceFailoverConfig_RecoveryWindow.Value;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow != null)
            {
                request.SourceFailoverConfig.RecoveryWindow = requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow.Value;
                requestSourceFailoverConfigIsNull = false;
            }
            Amazon.MediaConnect.State requestSourceFailoverConfig_sourceFailoverConfig_State = null;
            if (cmdletContext.SourceFailoverConfig_State != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_State = cmdletContext.SourceFailoverConfig_State;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_State != null)
            {
                request.SourceFailoverConfig.State = requestSourceFailoverConfig_sourceFailoverConfig_State;
                requestSourceFailoverConfigIsNull = false;
            }
             // determine if request.SourceFailoverConfig should be set to null
            if (requestSourceFailoverConfigIsNull)
            {
                request.SourceFailoverConfig = null;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlow");
            try
            {
                #if DESKTOP
                return client.UpdateFlow(request);
                #elif CORECLR
                return client.UpdateFlowAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowArn { get; set; }
            public System.Int32? SourceFailoverConfig_RecoveryWindow { get; set; }
            public Amazon.MediaConnect.State SourceFailoverConfig_State { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateFlowResponse, UpdateEMCNFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Flow;
        }
        
    }
}
