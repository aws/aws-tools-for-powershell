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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Updates a launch of a given feature. 
    /// 
    ///  
    /// <para>
    /// Don't use this operation to update the tags of an existing launch. Instead, use <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_TagResource.html">TagResource</a>.
    /// 
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Update", "CWEVDLaunch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Launch")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently UpdateLaunch API operation.", Operation = new[] {"UpdateLaunch"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Launch or Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Launch object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("AWS CloudWatch Evidently has been deprecated since 11/17/2025.")]
    public partial class UpdateCWEVDLaunchCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>An array of structures that contains the feature and variations that are to be used
        /// for the launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Groups")]
        public Amazon.CloudWatchEvidently.Model.LaunchGroupConfig[] Group { get; set; }
        #endregion
        
        #region Parameter Launch
        /// <summary>
        /// <para>
        /// <para>The name of the launch that is to be updated.</para>
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
        public System.String Launch { get; set; }
        #endregion
        
        #region Parameter MetricMonitor
        /// <summary>
        /// <para>
        /// <para>An array of structures that define the metrics that will be used to monitor the launch
        /// performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricMonitors")]
        public Amazon.CloudWatchEvidently.Model.MetricMonitorConfig[] MetricMonitor { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that contains the launch that you want to update.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter RandomizationSalt
        /// <summary>
        /// <para>
        /// <para>When Evidently assigns a particular user session to a launch, it must use a randomization
        /// ID to determine which variation the user session is served. This randomization ID
        /// is a combination of the entity ID and <c>randomizationSalt</c>. If you omit <c>randomizationSalt</c>,
        /// Evidently uses the launch name as the <c>randomizationSalt</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RandomizationSalt { get; set; }
        #endregion
        
        #region Parameter ScheduledSplitsConfig_Step
        /// <summary>
        /// <para>
        /// <para>An array of structures that define the traffic allocation percentages among the feature
        /// variations during each step of the launch. This also defines the start time of each
        /// step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduledSplitsConfig_Steps")]
        public Amazon.CloudWatchEvidently.Model.ScheduledSplitConfig[] ScheduledSplitsConfig_Step { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Launch'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Launch";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Launch), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWEVDLaunch (UpdateLaunch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse, UpdateCWEVDLaunchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.Group != null)
            {
                context.Group = new List<Amazon.CloudWatchEvidently.Model.LaunchGroupConfig>(this.Group);
            }
            context.Launch = this.Launch;
            #if MODULAR
            if (this.Launch == null && ParameterWasBound(nameof(this.Launch)))
            {
                WriteWarning("You are passing $null as a value for parameter Launch which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetricMonitor != null)
            {
                context.MetricMonitor = new List<Amazon.CloudWatchEvidently.Model.MetricMonitorConfig>(this.MetricMonitor);
            }
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RandomizationSalt = this.RandomizationSalt;
            if (this.ScheduledSplitsConfig_Step != null)
            {
                context.ScheduledSplitsConfig_Step = new List<Amazon.CloudWatchEvidently.Model.ScheduledSplitConfig>(this.ScheduledSplitsConfig_Step);
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
            var request = new Amazon.CloudWatchEvidently.Model.UpdateLaunchRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Group != null)
            {
                request.Groups = cmdletContext.Group;
            }
            if (cmdletContext.Launch != null)
            {
                request.Launch = cmdletContext.Launch;
            }
            if (cmdletContext.MetricMonitor != null)
            {
                request.MetricMonitors = cmdletContext.MetricMonitor;
            }
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
            }
            if (cmdletContext.RandomizationSalt != null)
            {
                request.RandomizationSalt = cmdletContext.RandomizationSalt;
            }
            
             // populate ScheduledSplitsConfig
            var requestScheduledSplitsConfigIsNull = true;
            request.ScheduledSplitsConfig = new Amazon.CloudWatchEvidently.Model.ScheduledSplitsLaunchConfig();
            List<Amazon.CloudWatchEvidently.Model.ScheduledSplitConfig> requestScheduledSplitsConfig_scheduledSplitsConfig_Step = null;
            if (cmdletContext.ScheduledSplitsConfig_Step != null)
            {
                requestScheduledSplitsConfig_scheduledSplitsConfig_Step = cmdletContext.ScheduledSplitsConfig_Step;
            }
            if (requestScheduledSplitsConfig_scheduledSplitsConfig_Step != null)
            {
                request.ScheduledSplitsConfig.Steps = requestScheduledSplitsConfig_scheduledSplitsConfig_Step;
                requestScheduledSplitsConfigIsNull = false;
            }
             // determine if request.ScheduledSplitsConfig should be set to null
            if (requestScheduledSplitsConfigIsNull)
            {
                request.ScheduledSplitsConfig = null;
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
        
        private Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.UpdateLaunchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "UpdateLaunch");
            try
            {
                #if DESKTOP
                return client.UpdateLaunch(request);
                #elif CORECLR
                return client.UpdateLaunchAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.LaunchGroupConfig> Group { get; set; }
            public System.String Launch { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.MetricMonitorConfig> MetricMonitor { get; set; }
            public System.String Project { get; set; }
            public System.String RandomizationSalt { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.ScheduledSplitConfig> ScheduledSplitsConfig_Step { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.UpdateLaunchResponse, UpdateCWEVDLaunchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Launch;
        }
        
    }
}
