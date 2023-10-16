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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Updates a LaunchConfiguration by Source Server ID.
    /// </summary>
    [Cmdlet("Update", "EDRSLaunchConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Drs.Model.UpdateLaunchConfigurationResponse")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service UpdateLaunchConfiguration API operation.", Operation = new[] {"UpdateLaunchConfiguration"}, SelectReturnType = typeof(Amazon.Drs.Model.UpdateLaunchConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.UpdateLaunchConfigurationResponse",
        "This cmdlet returns an Amazon.Drs.Model.UpdateLaunchConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEDRSLaunchConfigurationCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CopyPrivateIp
        /// <summary>
        /// <para>
        /// <para>Whether we should copy the Private IP of the Source Server to the Recovery Instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyPrivateIp { get; set; }
        #endregion
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>Whether we want to copy the tags of the Source Server to the EC2 machine of the Recovery
        /// Instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter LaunchDisposition
        /// <summary>
        /// <para>
        /// <para>The state of the Recovery Instance in EC2 after the recovery operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Drs.LaunchDisposition")]
        public Amazon.Drs.LaunchDisposition LaunchDisposition { get; set; }
        #endregion
        
        #region Parameter LaunchIntoInstanceProperties_LaunchIntoEC2InstanceID
        /// <summary>
        /// <para>
        /// <para>Optionally holds EC2 instance ID of an instance to launch into, instead of launching
        /// a new instance during drill, recovery or failback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchIntoInstanceProperties_LaunchIntoEC2InstanceID { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Licensing_OsByol
        /// <summary>
        /// <para>
        /// <para>Whether to enable "Bring your own license" or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Licensing_OsByol { get; set; }
        #endregion
        
        #region Parameter PostLaunchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether we want to enable post-launch actions for the Source Server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PostLaunchEnabled { get; set; }
        #endregion
        
        #region Parameter SourceServerID
        /// <summary>
        /// <para>
        /// <para>The ID of the Source Server that we want to retrieve a Launch Configuration for.</para>
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
        
        #region Parameter TargetInstanceTypeRightSizingMethod
        /// <summary>
        /// <para>
        /// <para>Whether Elastic Disaster Recovery should try to automatically choose the instance
        /// type that best matches the OS, CPU, and RAM of your Source Server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Drs.TargetInstanceTypeRightSizingMethod")]
        public Amazon.Drs.TargetInstanceTypeRightSizingMethod TargetInstanceTypeRightSizingMethod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.UpdateLaunchConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.UpdateLaunchConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EDRSLaunchConfiguration (UpdateLaunchConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.UpdateLaunchConfigurationResponse, UpdateEDRSLaunchConfigurationCmdlet>(Select) ??
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
            context.CopyPrivateIp = this.CopyPrivateIp;
            context.CopyTag = this.CopyTag;
            context.LaunchDisposition = this.LaunchDisposition;
            context.LaunchIntoInstanceProperties_LaunchIntoEC2InstanceID = this.LaunchIntoInstanceProperties_LaunchIntoEC2InstanceID;
            context.Licensing_OsByol = this.Licensing_OsByol;
            context.Name = this.Name;
            context.PostLaunchEnabled = this.PostLaunchEnabled;
            context.SourceServerID = this.SourceServerID;
            #if MODULAR
            if (this.SourceServerID == null && ParameterWasBound(nameof(this.SourceServerID)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetInstanceTypeRightSizingMethod = this.TargetInstanceTypeRightSizingMethod;
            
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
            var request = new Amazon.Drs.Model.UpdateLaunchConfigurationRequest();
            
            if (cmdletContext.CopyPrivateIp != null)
            {
                request.CopyPrivateIp = cmdletContext.CopyPrivateIp.Value;
            }
            if (cmdletContext.CopyTag != null)
            {
                request.CopyTags = cmdletContext.CopyTag.Value;
            }
            if (cmdletContext.LaunchDisposition != null)
            {
                request.LaunchDisposition = cmdletContext.LaunchDisposition;
            }
            
             // populate LaunchIntoInstanceProperties
            var requestLaunchIntoInstancePropertiesIsNull = true;
            request.LaunchIntoInstanceProperties = new Amazon.Drs.Model.LaunchIntoInstanceProperties();
            System.String requestLaunchIntoInstanceProperties_launchIntoInstanceProperties_LaunchIntoEC2InstanceID = null;
            if (cmdletContext.LaunchIntoInstanceProperties_LaunchIntoEC2InstanceID != null)
            {
                requestLaunchIntoInstanceProperties_launchIntoInstanceProperties_LaunchIntoEC2InstanceID = cmdletContext.LaunchIntoInstanceProperties_LaunchIntoEC2InstanceID;
            }
            if (requestLaunchIntoInstanceProperties_launchIntoInstanceProperties_LaunchIntoEC2InstanceID != null)
            {
                request.LaunchIntoInstanceProperties.LaunchIntoEC2InstanceID = requestLaunchIntoInstanceProperties_launchIntoInstanceProperties_LaunchIntoEC2InstanceID;
                requestLaunchIntoInstancePropertiesIsNull = false;
            }
             // determine if request.LaunchIntoInstanceProperties should be set to null
            if (requestLaunchIntoInstancePropertiesIsNull)
            {
                request.LaunchIntoInstanceProperties = null;
            }
            
             // populate Licensing
            var requestLicensingIsNull = true;
            request.Licensing = new Amazon.Drs.Model.Licensing();
            System.Boolean? requestLicensing_licensing_OsByol = null;
            if (cmdletContext.Licensing_OsByol != null)
            {
                requestLicensing_licensing_OsByol = cmdletContext.Licensing_OsByol.Value;
            }
            if (requestLicensing_licensing_OsByol != null)
            {
                request.Licensing.OsByol = requestLicensing_licensing_OsByol.Value;
                requestLicensingIsNull = false;
            }
             // determine if request.Licensing should be set to null
            if (requestLicensingIsNull)
            {
                request.Licensing = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PostLaunchEnabled != null)
            {
                request.PostLaunchEnabled = cmdletContext.PostLaunchEnabled.Value;
            }
            if (cmdletContext.SourceServerID != null)
            {
                request.SourceServerID = cmdletContext.SourceServerID;
            }
            if (cmdletContext.TargetInstanceTypeRightSizingMethod != null)
            {
                request.TargetInstanceTypeRightSizingMethod = cmdletContext.TargetInstanceTypeRightSizingMethod;
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
        
        private Amazon.Drs.Model.UpdateLaunchConfigurationResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.UpdateLaunchConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "UpdateLaunchConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateLaunchConfiguration(request);
                #elif CORECLR
                return client.UpdateLaunchConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CopyPrivateIp { get; set; }
            public System.Boolean? CopyTag { get; set; }
            public Amazon.Drs.LaunchDisposition LaunchDisposition { get; set; }
            public System.String LaunchIntoInstanceProperties_LaunchIntoEC2InstanceID { get; set; }
            public System.Boolean? Licensing_OsByol { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? PostLaunchEnabled { get; set; }
            public System.String SourceServerID { get; set; }
            public Amazon.Drs.TargetInstanceTypeRightSizingMethod TargetInstanceTypeRightSizingMethod { get; set; }
            public System.Func<Amazon.Drs.Model.UpdateLaunchConfigurationResponse, UpdateEDRSLaunchConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
