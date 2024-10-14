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
using Amazon.MainframeModernization;
using Amazon.MainframeModernization.Model;

namespace Amazon.PowerShell.Cmdlets.AMM
{
    /// <summary>
    /// Updates the configuration details for a specific runtime environment.
    /// </summary>
    [Cmdlet("Update", "AMMEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the M2 UpdateEnvironment API operation.", Operation = new[] {"UpdateEnvironment"}, SelectReturnType = typeof(Amazon.MainframeModernization.Model.UpdateEnvironmentResponse))]
    [AWSCmdletOutput("System.String or Amazon.MainframeModernization.Model.UpdateEnvironmentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MainframeModernization.Model.UpdateEnvironmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAMMEnvironmentCmdlet : AmazonMainframeModernizationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyDuringMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Indicates whether to update the runtime environment during the maintenance window.
        /// The default is false. Currently, Amazon Web Services Mainframe Modernization accepts
        /// the <c>engineVersion</c> parameter only if <c>applyDuringMaintenanceWindow</c> is
        /// true. If any parameter other than <c>engineVersion</c> is provided in <c>UpdateEnvironmentRequest</c>,
        /// it will fail if <c>applyDuringMaintenanceWindow</c> is set to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyDuringMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter DesiredCapacity
        /// <summary>
        /// <para>
        /// <para>The desired capacity for the runtime environment to update. The minimum possible value
        /// is 0 and the maximum is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DesiredCapacity { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version of the runtime engine for the runtime environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the runtime environment that you want to update.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter ForceUpdate
        /// <summary>
        /// <para>
        /// <para>Forces the updates on the environment. This option is needed if the applications in
        /// the environment are not stopped or if there are ongoing application-related activities
        /// in the environment.</para><para>If you use this option, be aware that it could lead to data corruption in the applications,
        /// and that you might need to perform repair and recovery procedures for the applications.</para><para>This option is not needed if the attribute being updated is <c>preferredMaintenanceWindow</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceUpdate { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type for the runtime environment to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Configures the maintenance window that you want for the runtime environment. The maintenance
        /// window must have the format <c>ddd:hh24:mi-ddd:hh24:mi</c> and must be less than 24
        /// hours. The following two examples are valid maintenance windows: <c>sun:23:45-mon:00:15</c>
        /// or <c>sat:01:00-sat:03:00</c>. </para><para>If you do not provide a value, a random system-generated value will be assigned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MainframeModernization.Model.UpdateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.MainframeModernization.Model.UpdateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnvironmentId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EnvironmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMMEnvironment (UpdateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MainframeModernization.Model.UpdateEnvironmentResponse, UpdateAMMEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EnvironmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyDuringMaintenanceWindow = this.ApplyDuringMaintenanceWindow;
            context.DesiredCapacity = this.DesiredCapacity;
            context.EngineVersion = this.EngineVersion;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForceUpdate = this.ForceUpdate;
            context.InstanceType = this.InstanceType;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            
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
            var request = new Amazon.MainframeModernization.Model.UpdateEnvironmentRequest();
            
            if (cmdletContext.ApplyDuringMaintenanceWindow != null)
            {
                request.ApplyDuringMaintenanceWindow = cmdletContext.ApplyDuringMaintenanceWindow.Value;
            }
            if (cmdletContext.DesiredCapacity != null)
            {
                request.DesiredCapacity = cmdletContext.DesiredCapacity.Value;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.ForceUpdate != null)
            {
                request.ForceUpdate = cmdletContext.ForceUpdate.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
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
        
        private Amazon.MainframeModernization.Model.UpdateEnvironmentResponse CallAWSServiceOperation(IAmazonMainframeModernization client, Amazon.MainframeModernization.Model.UpdateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "M2", "UpdateEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateEnvironment(request);
                #elif CORECLR
                return client.UpdateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyDuringMaintenanceWindow { get; set; }
            public System.Int32? DesiredCapacity { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Boolean? ForceUpdate { get; set; }
            public System.String InstanceType { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Func<Amazon.MainframeModernization.Model.UpdateEnvironmentResponse, UpdateAMMEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentId;
        }
        
    }
}
