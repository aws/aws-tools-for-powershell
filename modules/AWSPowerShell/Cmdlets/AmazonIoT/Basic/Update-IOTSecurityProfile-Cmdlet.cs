/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS IoT UpdateSecurityProfile API operation.", Operation = new[] {"UpdateSecurityProfile"})]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateSecurityProfileResponse",
        "This cmdlet returns a Amazon.IoT.Model.UpdateSecurityProfileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTSecurityProfileCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalMetricsToRetain
        /// <summary>
        /// <para>
        /// <para>A list of metrics whose data is retained (stored). By default, data is retained for
        /// any metric used in the profile's <code>behaviors</code> but it is also retained for
        /// any metric specified here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] AdditionalMetricsToRetain { get; set; }
        #endregion
        
        #region Parameter AlertTarget
        /// <summary>
        /// <para>
        /// <para>Where the alerts are sent. (Alerts are always sent to the console.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AlertTargets")]
        public System.Collections.Hashtable AlertTarget { get; set; }
        #endregion
        
        #region Parameter Behavior
        /// <summary>
        /// <para>
        /// <para>Specifies the behaviors that, when violated by a device (thing), cause an alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Behaviors")]
        public Amazon.IoT.Model.Behavior[] Behavior { get; set; }
        #endregion
        
        #region Parameter DeleteAdditionalMetricsToRetain
        /// <summary>
        /// <para>
        /// <para>If true, delete all <code>additionalMetricsToRetain</code> defined for this security
        /// profile. If any <code>additionalMetricsToRetain</code> are defined in the current
        /// invocation an exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeleteAdditionalMetricsToRetain { get; set; }
        #endregion
        
        #region Parameter DeleteAlertTarget
        /// <summary>
        /// <para>
        /// <para>If true, delete all <code>alertTargets</code> defined for this security profile. If
        /// any <code>alertTargets</code> are defined in the current invocation an exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DeleteAlertTargets")]
        public System.Boolean DeleteAlertTarget { get; set; }
        #endregion
        
        #region Parameter DeleteBehavior
        /// <summary>
        /// <para>
        /// <para>If true, delete all <code>behaviors</code> defined for this security profile. If any
        /// <code>behaviors</code> are defined in the current invocation an exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DeleteBehaviors")]
        public System.Boolean DeleteBehavior { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the security profile. A new version is generated whenever
        /// the security profile is updated. If you specify a value that is different than the
        /// actual version, a <code>VersionConflictException</code> is thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter SecurityProfileDescription
        /// <summary>
        /// <para>
        /// <para>A description of the security profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SecurityProfileDescription { get; set; }
        #endregion
        
        #region Parameter SecurityProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the security profile you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecurityProfileName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SecurityProfileName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSecurityProfile (UpdateSecurityProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AdditionalMetricsToRetain != null)
            {
                context.AdditionalMetricsToRetain = new List<System.String>(this.AdditionalMetricsToRetain);
            }
            if (this.AlertTarget != null)
            {
                context.AlertTargets = new Dictionary<System.String, Amazon.IoT.Model.AlertTarget>(StringComparer.Ordinal);
                foreach (var hashKey in this.AlertTarget.Keys)
                {
                    context.AlertTargets.Add((String)hashKey, (AlertTarget)(this.AlertTarget[hashKey]));
                }
            }
            if (this.Behavior != null)
            {
                context.Behaviors = new List<Amazon.IoT.Model.Behavior>(this.Behavior);
            }
            if (ParameterWasBound("DeleteAdditionalMetricsToRetain"))
                context.DeleteAdditionalMetricsToRetain = this.DeleteAdditionalMetricsToRetain;
            if (ParameterWasBound("DeleteAlertTarget"))
                context.DeleteAlertTargets = this.DeleteAlertTarget;
            if (ParameterWasBound("DeleteBehavior"))
                context.DeleteBehaviors = this.DeleteBehavior;
            if (ParameterWasBound("ExpectedVersion"))
                context.ExpectedVersion = this.ExpectedVersion;
            context.SecurityProfileDescription = this.SecurityProfileDescription;
            context.SecurityProfileName = this.SecurityProfileName;
            
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
            
            if (cmdletContext.AdditionalMetricsToRetain != null)
            {
                request.AdditionalMetricsToRetain = cmdletContext.AdditionalMetricsToRetain;
            }
            if (cmdletContext.AlertTargets != null)
            {
                request.AlertTargets = cmdletContext.AlertTargets;
            }
            if (cmdletContext.Behaviors != null)
            {
                request.Behaviors = cmdletContext.Behaviors;
            }
            if (cmdletContext.DeleteAdditionalMetricsToRetain != null)
            {
                request.DeleteAdditionalMetricsToRetain = cmdletContext.DeleteAdditionalMetricsToRetain.Value;
            }
            if (cmdletContext.DeleteAlertTargets != null)
            {
                request.DeleteAlertTargets = cmdletContext.DeleteAlertTargets.Value;
            }
            if (cmdletContext.DeleteBehaviors != null)
            {
                request.DeleteBehaviors = cmdletContext.DeleteBehaviors.Value;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateSecurityProfileAsync(request);
                return task.Result;
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
            public List<System.String> AdditionalMetricsToRetain { get; set; }
            public Dictionary<System.String, Amazon.IoT.Model.AlertTarget> AlertTargets { get; set; }
            public List<Amazon.IoT.Model.Behavior> Behaviors { get; set; }
            public System.Boolean? DeleteAdditionalMetricsToRetain { get; set; }
            public System.Boolean? DeleteAlertTargets { get; set; }
            public System.Boolean? DeleteBehaviors { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
            public System.String SecurityProfileDescription { get; set; }
            public System.String SecurityProfileName { get; set; }
        }
        
    }
}
