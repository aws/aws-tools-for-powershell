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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Updates an existing Amazon Kinesis Data Analytics application. Using this operation,
    /// you can update application code, input configuration, and output configuration. 
    /// 
    ///  
    /// <para>
    /// Kinesis Data Analytics updates the <code>ApplicationVersionId</code> each time you
    /// update your application. 
    /// </para><note><para>
    /// SQL is not enabled for this private beta. Using SQL parameters (such as <a>SqlApplicationConfigurationUpdate</a>)
    /// will result in an error.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "KINA2Application", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics (v2) UpdateApplication API operation.", Operation = new[] {"UpdateApplication"})]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail",
        "This cmdlet returns a ApplicationDetail object.",
        "The service call response (type Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKINA2ApplicationCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationConfigurationUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application configuration updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisAnalyticsV2.Model.ApplicationConfigurationUpdate ApplicationConfigurationUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptionUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application Amazon CloudWatch logging option updates. You can only update
        /// existing CloudWatch logging options with this action. To add a new CloudWatch logging
        /// option, use <a>AddApplicationCloudWatchLoggingOption</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CloudWatchLoggingOptionUpdates")]
        public Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOptionUpdate[] CloudWatchLoggingOptionUpdate { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The current application version ID. You can retrieve the application version ID using
        /// <a>DescribeApplication</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter RunConfigurationUpdate
        /// <summary>
        /// <para>
        /// <para>Describes updates to the application's starting parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisAnalyticsV2.Model.RunConfigurationUpdate RunConfigurationUpdate { get; set; }
        #endregion
        
        #region Parameter ServiceExecutionRoleUpdate
        /// <summary>
        /// <para>
        /// <para>Describes updates to the service execution role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceExecutionRoleUpdate { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINA2Application (UpdateApplication)"))
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
            
            context.ApplicationConfigurationUpdate = this.ApplicationConfigurationUpdate;
            context.ApplicationName = this.ApplicationName;
            if (this.CloudWatchLoggingOptionUpdate != null)
            {
                context.CloudWatchLoggingOptionUpdates = new List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOptionUpdate>(this.CloudWatchLoggingOptionUpdate);
            }
            if (ParameterWasBound("CurrentApplicationVersionId"))
                context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            context.RunConfigurationUpdate = this.RunConfigurationUpdate;
            context.ServiceExecutionRoleUpdate = this.ServiceExecutionRoleUpdate;
            
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
            var request = new Amazon.KinesisAnalyticsV2.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationConfigurationUpdate != null)
            {
                request.ApplicationConfigurationUpdate = cmdletContext.ApplicationConfigurationUpdate;
            }
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CloudWatchLoggingOptionUpdates != null)
            {
                request.CloudWatchLoggingOptionUpdates = cmdletContext.CloudWatchLoggingOptionUpdates;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            if (cmdletContext.RunConfigurationUpdate != null)
            {
                request.RunConfigurationUpdate = cmdletContext.RunConfigurationUpdate;
            }
            if (cmdletContext.ServiceExecutionRoleUpdate != null)
            {
                request.ServiceExecutionRoleUpdate = cmdletContext.ServiceExecutionRoleUpdate;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ApplicationDetail;
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
        
        private Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics (v2)", "UpdateApplication");
            try
            {
                #if DESKTOP
                return client.UpdateApplication(request);
                #elif CORECLR
                return client.UpdateApplicationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KinesisAnalyticsV2.Model.ApplicationConfigurationUpdate ApplicationConfigurationUpdate { get; set; }
            public System.String ApplicationName { get; set; }
            public List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOptionUpdate> CloudWatchLoggingOptionUpdates { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public Amazon.KinesisAnalyticsV2.Model.RunConfigurationUpdate RunConfigurationUpdate { get; set; }
            public System.String ServiceExecutionRoleUpdate { get; set; }
        }
        
    }
}
