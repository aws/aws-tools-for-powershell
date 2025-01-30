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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Allows the user to set the SourceServer.LifeCycle.state property for specific Source
    /// Server IDs to one of the following: READY_FOR_TEST or READY_FOR_CUTOVER. This command
    /// only works if the Source Server is already launchable (dataReplicationInfo.lagDuration
    /// is not null.)
    /// </summary>
    [Cmdlet("Set", "MGNServerLifeCycleState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse")]
    [AWSCmdlet("Calls the Application Migration Service ChangeServerLifeCycleState API operation.", Operation = new[] {"ChangeServerLifeCycleState"}, SelectReturnType = typeof(Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse",
        "This cmdlet returns an Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse object containing multiple properties."
    )]
    public partial class SetMGNServerLifeCycleStateCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>The request to change the source server migration account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter SourceServerID
        /// <summary>
        /// <para>
        /// <para>The request to change the source server migration lifecycle state by source server
        /// ID.</para>
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
        public System.String SourceServerID { get; set; }
        #endregion
        
        #region Parameter LifeCycle_State
        /// <summary>
        /// <para>
        /// <para>The request to change the source server migration lifecycle state.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Mgn.ChangeServerLifeCycleStateSourceServerLifecycleState")]
        public Amazon.Mgn.ChangeServerLifeCycleStateSourceServerLifecycleState LifeCycle_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceServerID parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceServerID' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceServerID' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceServerID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-MGNServerLifeCycleState (ChangeServerLifeCycleState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse, SetMGNServerLifeCycleStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceServerID;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountID = this.AccountID;
            context.LifeCycle_State = this.LifeCycle_State;
            #if MODULAR
            if (this.LifeCycle_State == null && ParameterWasBound(nameof(this.LifeCycle_State)))
            {
                WriteWarning("You are passing $null as a value for parameter LifeCycle_State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceServerID = this.SourceServerID;
            #if MODULAR
            if (this.SourceServerID == null && ParameterWasBound(nameof(this.SourceServerID)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Mgn.Model.ChangeServerLifeCycleStateRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            
             // populate LifeCycle
            var requestLifeCycleIsNull = true;
            request.LifeCycle = new Amazon.Mgn.Model.ChangeServerLifeCycleStateSourceServerLifecycle();
            Amazon.Mgn.ChangeServerLifeCycleStateSourceServerLifecycleState requestLifeCycle_lifeCycle_State = null;
            if (cmdletContext.LifeCycle_State != null)
            {
                requestLifeCycle_lifeCycle_State = cmdletContext.LifeCycle_State;
            }
            if (requestLifeCycle_lifeCycle_State != null)
            {
                request.LifeCycle.State = requestLifeCycle_lifeCycle_State;
                requestLifeCycleIsNull = false;
            }
             // determine if request.LifeCycle should be set to null
            if (requestLifeCycleIsNull)
            {
                request.LifeCycle = null;
            }
            if (cmdletContext.SourceServerID != null)
            {
                request.SourceServerID = cmdletContext.SourceServerID;
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
        
        private Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.ChangeServerLifeCycleStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "ChangeServerLifeCycleState");
            try
            {
                #if DESKTOP
                return client.ChangeServerLifeCycleState(request);
                #elif CORECLR
                return client.ChangeServerLifeCycleStateAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public Amazon.Mgn.ChangeServerLifeCycleStateSourceServerLifecycleState LifeCycle_State { get; set; }
            public System.String SourceServerID { get; set; }
            public System.Func<Amazon.Mgn.Model.ChangeServerLifeCycleStateResponse, SetMGNServerLifeCycleStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
