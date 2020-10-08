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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a Device Defender security profile.
    /// </summary>
    [Cmdlet("Update", "IOTSecurityProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateSecurityProfileResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateSecurityProfile API operation.", Operation = new[] {"UpdateSecurityProfile"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateSecurityProfileResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateSecurityProfileResponse",
        "This cmdlet returns an Amazon.IoT.Model.UpdateSecurityProfileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTSecurityProfileCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalMetricsToRetainV2
        /// <summary>
        /// <para>
        /// <para>A list of metrics whose data is retained (stored). By default, data is retained for
        /// any metric used in the profile's behaviors, but it is also retained for any metric
        /// specified here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.MetricToRetain[] AdditionalMetricsToRetainV2 { get; set; }
        #endregion
        
        #region Parameter AlertTarget
        /// <summary>
        /// <para>
        /// <para>Where the alerts are sent. (Alerts are always sent to the console.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlertTargets")]
        public System.Collections.Hashtable AlertTarget { get; set; }
        #endregion
        
        #region Parameter Behavior
        /// <summary>
        /// <para>
        /// <para>Specifies the behaviors that, when violated by a device (thing), cause an alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Behaviors")]
        public Amazon.IoT.Model.Behavior[] Behavior { get; set; }
        #endregion
        
        #region Parameter DeleteAdditionalMetricsToRetain
        /// <summary>
        /// <para>
        /// <para>If true, delete all <code>additionalMetricsToRetain</code> defined for this security
        /// profile. If any <code>additionalMetricsToRetain</code> are defined in the current
        /// invocation, an exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteAdditionalMetricsToRetain { get; set; }
        #endregion
        
        #region Parameter DeleteAlertTarget
        /// <summary>
        /// <para>
        /// <para>If true, delete all <code>alertTargets</code> defined for this security profile. If
        /// any <code>alertTargets</code> are defined in the current invocation, an exception
        /// occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteAlertTargets")]
        public System.Boolean? DeleteAlertTarget { get; set; }
        #endregion
        
        #region Parameter DeleteBehavior
        /// <summary>
        /// <para>
        /// <para>If true, delete all <code>behaviors</code> defined for this security profile. If any
        /// <code>behaviors</code> are defined in the current invocation, an exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteBehaviors")]
        public System.Boolean? DeleteBehavior { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the security profile. A new version is generated whenever
        /// the security profile is updated. If you specify a value that is different from the
        /// actual version, a <code>VersionConflictException</code> is thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter SecurityProfileDescription
        /// <summary>
        /// <para>
        /// <para>A description of the security profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityProfileDescription { get; set; }
        #endregion
        
        #region Parameter SecurityProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the security profile you want to update.</para>
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
        public System.String SecurityProfileName { get; set; }
        #endregion
        
        #region Parameter AdditionalMetricsToRetain
        /// <summary>
        /// <para>
        /// <para><i>Please use <a>UpdateSecurityProfileRequest$additionalMetricsToRetainV2</a> instead.</i></para><para>A list of metrics whose data is retained (stored). By default, data is retained for
        /// any metric used in the profile's <code>behaviors</code>, but it is also retained for
        /// any metric specified here.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use additionalMetricsToRetainV2.")]
        public System.String[] AdditionalMetricsToRetain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateSecurityProfileResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateSecurityProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SecurityProfileName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SecurityProfileName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SecurityProfileName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecurityProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSecurityProfile (UpdateSecurityProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateSecurityProfileResponse, UpdateIOTSecurityProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SecurityProfileName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalMetricsToRetain != null)
            {
                context.AdditionalMetricsToRetain = new List<System.String>(this.AdditionalMetricsToRetain);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalMetricsToRetainV2 != null)
            {
                context.AdditionalMetricsToRetainV2 = new List<Amazon.IoT.Model.MetricToRetain>(this.AdditionalMetricsToRetainV2);
            }
            if (this.AlertTarget != null)
            {
                context.AlertTarget = new Dictionary<System.String, Amazon.IoT.Model.AlertTarget>(StringComparer.Ordinal);
                foreach (var hashKey in this.AlertTarget.Keys)
                {
                    context.AlertTarget.Add((String)hashKey, (AlertTarget)(this.AlertTarget[hashKey]));
                }
            }
            if (this.Behavior != null)
            {
                context.Behavior = new List<Amazon.IoT.Model.Behavior>(this.Behavior);
            }
            context.DeleteAdditionalMetricsToRetain = this.DeleteAdditionalMetricsToRetain;
            context.DeleteAlertTarget = this.DeleteAlertTarget;
            context.DeleteBehavior = this.DeleteBehavior;
            context.ExpectedVersion = this.ExpectedVersion;
            context.SecurityProfileDescription = this.SecurityProfileDescription;
            context.SecurityProfileName = this.SecurityProfileName;
            #if MODULAR
            if (this.SecurityProfileName == null && ParameterWasBound(nameof(this.SecurityProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.UpdateSecurityProfileRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AdditionalMetricsToRetain != null)
            {
                request.AdditionalMetricsToRetain = cmdletContext.AdditionalMetricsToRetain;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AdditionalMetricsToRetainV2 != null)
            {
                request.AdditionalMetricsToRetainV2 = cmdletContext.AdditionalMetricsToRetainV2;
            }
            if (cmdletContext.AlertTarget != null)
            {
                request.AlertTargets = cmdletContext.AlertTarget;
            }
            if (cmdletContext.Behavior != null)
            {
                request.Behaviors = cmdletContext.Behavior;
            }
            if (cmdletContext.DeleteAdditionalMetricsToRetain != null)
            {
                request.DeleteAdditionalMetricsToRetain = cmdletContext.DeleteAdditionalMetricsToRetain.Value;
            }
            if (cmdletContext.DeleteAlertTarget != null)
            {
                request.DeleteAlertTargets = cmdletContext.DeleteAlertTarget.Value;
            }
            if (cmdletContext.DeleteBehavior != null)
            {
                request.DeleteBehaviors = cmdletContext.DeleteBehavior.Value;
            }
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            if (cmdletContext.SecurityProfileDescription != null)
            {
                request.SecurityProfileDescription = cmdletContext.SecurityProfileDescription;
            }
            if (cmdletContext.SecurityProfileName != null)
            {
                request.SecurityProfileName = cmdletContext.SecurityProfileName;
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
        
        private Amazon.IoT.Model.UpdateSecurityProfileResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateSecurityProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateSecurityProfile");
            try
            {
                #if DESKTOP
                return client.UpdateSecurityProfile(request);
                #elif CORECLR
                return client.UpdateSecurityProfileAsync(request).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public List<System.String> AdditionalMetricsToRetain { get; set; }
            public List<Amazon.IoT.Model.MetricToRetain> AdditionalMetricsToRetainV2 { get; set; }
            public Dictionary<System.String, Amazon.IoT.Model.AlertTarget> AlertTarget { get; set; }
            public List<Amazon.IoT.Model.Behavior> Behavior { get; set; }
            public System.Boolean? DeleteAdditionalMetricsToRetain { get; set; }
            public System.Boolean? DeleteAlertTarget { get; set; }
            public System.Boolean? DeleteBehavior { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
            public System.String SecurityProfileDescription { get; set; }
            public System.String SecurityProfileName { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateSecurityProfileResponse, UpdateIOTSecurityProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
