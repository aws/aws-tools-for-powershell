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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Creates a <i>launch</i> of a given feature. Before you create a launch, you must create
    /// the feature to use for the launch.
    /// 
    ///  
    /// <para>
    /// You can use a launch to safely validate new features by serving them to a specified
    /// percentage of your users while you roll out the feature. You can monitor the performance
    /// of the new feature to help you decide when to ramp up traffic to more users. This
    /// helps you reduce risk and identify unintended consequences before you fully launch
    /// the feature.
    /// </para><para>
    /// Don't use this operation to update an existing launch. Instead, use <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_UpdateLaunch.html">UpdateLaunch</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWEVDLaunch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Launch")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently CreateLaunch API operation.", Operation = new[] {"CreateLaunch"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.CreateLaunchResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Launch or Amazon.CloudWatchEvidently.Model.CreateLaunchResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Launch object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.CreateLaunchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWEVDLaunchCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Groups")]
        public Amazon.CloudWatchEvidently.Model.LaunchGroupConfig[] Group { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the new launch.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that you want to create the launch in.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags (key-value pairs) to the launch.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>Tags don't have any semantic meaning to Amazon Web Services and are interpreted strictly
        /// as strings of characters.</para><para>You can associate as many as 50 tags with a launch.</para><para>For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Launch'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.CreateLaunchResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.CreateLaunchResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWEVDLaunch (CreateLaunch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.CreateLaunchResponse, NewCWEVDLaunchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.Group != null)
            {
                context.Group = new List<Amazon.CloudWatchEvidently.Model.LaunchGroupConfig>(this.Group);
            }
            #if MODULAR
            if (this.Group == null && ParameterWasBound(nameof(this.Group)))
            {
                WriteWarning("You are passing $null as a value for parameter Group which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetricMonitor != null)
            {
                context.MetricMonitor = new List<Amazon.CloudWatchEvidently.Model.MetricMonitorConfig>(this.MetricMonitor);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CloudWatchEvidently.Model.CreateLaunchRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Group != null)
            {
                request.Groups = cmdletContext.Group;
            }
            if (cmdletContext.MetricMonitor != null)
            {
                request.MetricMonitors = cmdletContext.MetricMonitor;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CloudWatchEvidently.Model.CreateLaunchResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.CreateLaunchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "CreateLaunch");
            try
            {
                #if DESKTOP
                return client.CreateLaunch(request);
                #elif CORECLR
                return client.CreateLaunchAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatchEvidently.Model.MetricMonitorConfig> MetricMonitor { get; set; }
            public System.String Name { get; set; }
            public System.String Project { get; set; }
            public System.String RandomizationSalt { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.ScheduledSplitConfig> ScheduledSplitsConfig_Step { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.CreateLaunchResponse, NewCWEVDLaunchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Launch;
        }
        
    }
}
