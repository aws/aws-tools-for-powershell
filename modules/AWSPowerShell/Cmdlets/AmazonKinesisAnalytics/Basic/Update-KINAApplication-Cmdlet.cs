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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// Updates an existing Amazon Kinesis Analytics application. Using this API, you can
    /// update application code, input configuration, and output configuration. 
    /// 
    ///  
    /// <para>
    /// Note that Amazon Kinesis Analytics updates the <code>CurrentApplicationVersionId</code>
    /// each time you update your application. 
    /// </para><para>
    /// This operation requires permission for the <code>kinesisanalytics:UpdateApplication</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINAApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics UpdateApplication API operation.", Operation = new[] {"UpdateApplication"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ApplicationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KinesisAnalytics.Model.UpdateApplicationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKINAApplicationCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationUpdate_ApplicationCodeUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application code updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplicationUpdate_ApplicationCodeUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Kinesis Analytics application to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_CloudWatchLoggingOptionUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application CloudWatch logging option updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApplicationUpdate_CloudWatchLoggingOptionUpdates")]
        public Amazon.KinesisAnalytics.Model.CloudWatchLoggingOptionUpdate[] ApplicationUpdate_CloudWatchLoggingOptionUpdate { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The current application version ID. You can use the <a>DescribeApplication</a> operation
        /// to get this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_InputUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application input configuration updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApplicationUpdate_InputUpdates")]
        public Amazon.KinesisAnalytics.Model.InputUpdate[] ApplicationUpdate_InputUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_OutputUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application output configuration updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApplicationUpdate_OutputUpdates")]
        public Amazon.KinesisAnalytics.Model.OutputUpdate[] ApplicationUpdate_OutputUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_ReferenceDataSourceUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application reference data source updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApplicationUpdate_ReferenceDataSourceUpdates")]
        public Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate[] ApplicationUpdate_ReferenceDataSourceUpdate { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ApplicationName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINAApplication (UpdateApplication)"))
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
            
            context.ApplicationName = this.ApplicationName;
            context.ApplicationUpdate_ApplicationCodeUpdate = this.ApplicationUpdate_ApplicationCodeUpdate;
            if (this.ApplicationUpdate_CloudWatchLoggingOptionUpdate != null)
            {
                context.ApplicationUpdate_CloudWatchLoggingOptionUpdates = new List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOptionUpdate>(this.ApplicationUpdate_CloudWatchLoggingOptionUpdate);
            }
            if (this.ApplicationUpdate_InputUpdate != null)
            {
                context.ApplicationUpdate_InputUpdates = new List<Amazon.KinesisAnalytics.Model.InputUpdate>(this.ApplicationUpdate_InputUpdate);
            }
            if (this.ApplicationUpdate_OutputUpdate != null)
            {
                context.ApplicationUpdate_OutputUpdates = new List<Amazon.KinesisAnalytics.Model.OutputUpdate>(this.ApplicationUpdate_OutputUpdate);
            }
            if (this.ApplicationUpdate_ReferenceDataSourceUpdate != null)
            {
                context.ApplicationUpdate_ReferenceDataSourceUpdates = new List<Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate>(this.ApplicationUpdate_ReferenceDataSourceUpdate);
            }
            if (ParameterWasBound("CurrentApplicationVersionId"))
                context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            
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
            var request = new Amazon.KinesisAnalytics.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate ApplicationUpdate
            bool requestApplicationUpdateIsNull = true;
            request.ApplicationUpdate = new Amazon.KinesisAnalytics.Model.ApplicationUpdate();
            System.String requestApplicationUpdate_applicationUpdate_ApplicationCodeUpdate = null;
            if (cmdletContext.ApplicationUpdate_ApplicationCodeUpdate != null)
            {
                requestApplicationUpdate_applicationUpdate_ApplicationCodeUpdate = cmdletContext.ApplicationUpdate_ApplicationCodeUpdate;
            }
            if (requestApplicationUpdate_applicationUpdate_ApplicationCodeUpdate != null)
            {
                request.ApplicationUpdate.ApplicationCodeUpdate = requestApplicationUpdate_applicationUpdate_ApplicationCodeUpdate;
                requestApplicationUpdateIsNull = false;
            }
            List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOptionUpdate> requestApplicationUpdate_applicationUpdate_CloudWatchLoggingOptionUpdate = null;
            if (cmdletContext.ApplicationUpdate_CloudWatchLoggingOptionUpdates != null)
            {
                requestApplicationUpdate_applicationUpdate_CloudWatchLoggingOptionUpdate = cmdletContext.ApplicationUpdate_CloudWatchLoggingOptionUpdates;
            }
            if (requestApplicationUpdate_applicationUpdate_CloudWatchLoggingOptionUpdate != null)
            {
                request.ApplicationUpdate.CloudWatchLoggingOptionUpdates = requestApplicationUpdate_applicationUpdate_CloudWatchLoggingOptionUpdate;
                requestApplicationUpdateIsNull = false;
            }
            List<Amazon.KinesisAnalytics.Model.InputUpdate> requestApplicationUpdate_applicationUpdate_InputUpdate = null;
            if (cmdletContext.ApplicationUpdate_InputUpdates != null)
            {
                requestApplicationUpdate_applicationUpdate_InputUpdate = cmdletContext.ApplicationUpdate_InputUpdates;
            }
            if (requestApplicationUpdate_applicationUpdate_InputUpdate != null)
            {
                request.ApplicationUpdate.InputUpdates = requestApplicationUpdate_applicationUpdate_InputUpdate;
                requestApplicationUpdateIsNull = false;
            }
            List<Amazon.KinesisAnalytics.Model.OutputUpdate> requestApplicationUpdate_applicationUpdate_OutputUpdate = null;
            if (cmdletContext.ApplicationUpdate_OutputUpdates != null)
            {
                requestApplicationUpdate_applicationUpdate_OutputUpdate = cmdletContext.ApplicationUpdate_OutputUpdates;
            }
            if (requestApplicationUpdate_applicationUpdate_OutputUpdate != null)
            {
                request.ApplicationUpdate.OutputUpdates = requestApplicationUpdate_applicationUpdate_OutputUpdate;
                requestApplicationUpdateIsNull = false;
            }
            List<Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate> requestApplicationUpdate_applicationUpdate_ReferenceDataSourceUpdate = null;
            if (cmdletContext.ApplicationUpdate_ReferenceDataSourceUpdates != null)
            {
                requestApplicationUpdate_applicationUpdate_ReferenceDataSourceUpdate = cmdletContext.ApplicationUpdate_ReferenceDataSourceUpdates;
            }
            if (requestApplicationUpdate_applicationUpdate_ReferenceDataSourceUpdate != null)
            {
                request.ApplicationUpdate.ReferenceDataSourceUpdates = requestApplicationUpdate_applicationUpdate_ReferenceDataSourceUpdate;
                requestApplicationUpdateIsNull = false;
            }
             // determine if request.ApplicationUpdate should be set to null
            if (requestApplicationUpdateIsNull)
            {
                request.ApplicationUpdate = null;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ApplicationName;
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
        
        private Amazon.KinesisAnalytics.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "UpdateApplication");
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
            public System.String ApplicationName { get; set; }
            public System.String ApplicationUpdate_ApplicationCodeUpdate { get; set; }
            public List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOptionUpdate> ApplicationUpdate_CloudWatchLoggingOptionUpdates { get; set; }
            public List<Amazon.KinesisAnalytics.Model.InputUpdate> ApplicationUpdate_InputUpdates { get; set; }
            public List<Amazon.KinesisAnalytics.Model.OutputUpdate> ApplicationUpdate_OutputUpdates { get; set; }
            public List<Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate> ApplicationUpdate_ReferenceDataSourceUpdates { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
        }
        
    }
}
