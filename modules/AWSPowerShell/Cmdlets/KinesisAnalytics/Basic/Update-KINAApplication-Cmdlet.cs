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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// <note><para>
    /// This documentation is for version 1 of the Amazon Kinesis Data Analytics API, which
    /// only supports SQL applications. Version 2 of the API supports SQL and Java applications.
    /// For more information about version 2, see <a href="/kinesisanalytics/latest/apiv2/Welcome.html">Amazon
    /// Kinesis Data Analytics API V2 Documentation</a>.
    /// </para></note><para>
    /// Updates an existing Amazon Kinesis Analytics application. Using this API, you can
    /// update application code, input configuration, and output configuration. 
    /// </para><para>
    /// Note that Amazon Kinesis Analytics updates the <c>CurrentApplicationVersionId</c>
    /// each time you update your application. 
    /// </para><para>
    /// This operation requires permission for the <c>kinesisanalytics:UpdateApplication</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINAApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.KinesisAnalytics.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisAnalytics.Model.UpdateApplicationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisAnalytics.Model.UpdateApplicationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKINAApplicationCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationUpdate_ApplicationCodeUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application code updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationUpdate_ApplicationCodeUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Kinesis Analytics application to update.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_CloudWatchLoggingOptionUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application CloudWatch logging option updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationUpdate_CloudWatchLoggingOptionUpdates")]
        public Amazon.KinesisAnalytics.Model.CloudWatchLoggingOptionUpdate[] ApplicationUpdate_CloudWatchLoggingOptionUpdate { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The current application version ID. You can use the <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/API_DescribeApplication.html">DescribeApplication</a>
        /// operation to get this value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_InputUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application input configuration updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationUpdate_InputUpdates")]
        public Amazon.KinesisAnalytics.Model.InputUpdate[] ApplicationUpdate_InputUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_OutputUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application output configuration updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationUpdate_OutputUpdates")]
        public Amazon.KinesisAnalytics.Model.OutputUpdate[] ApplicationUpdate_OutputUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationUpdate_ReferenceDataSourceUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application reference data source updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationUpdate_ReferenceDataSourceUpdates")]
        public Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate[] ApplicationUpdate_ReferenceDataSourceUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalytics.Model.UpdateApplicationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINAApplication (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalytics.Model.UpdateApplicationResponse, UpdateKINAApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApplicationUpdate_ApplicationCodeUpdate = this.ApplicationUpdate_ApplicationCodeUpdate;
            if (this.ApplicationUpdate_CloudWatchLoggingOptionUpdate != null)
            {
                context.ApplicationUpdate_CloudWatchLoggingOptionUpdate = new List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOptionUpdate>(this.ApplicationUpdate_CloudWatchLoggingOptionUpdate);
            }
            if (this.ApplicationUpdate_InputUpdate != null)
            {
                context.ApplicationUpdate_InputUpdate = new List<Amazon.KinesisAnalytics.Model.InputUpdate>(this.ApplicationUpdate_InputUpdate);
            }
            if (this.ApplicationUpdate_OutputUpdate != null)
            {
                context.ApplicationUpdate_OutputUpdate = new List<Amazon.KinesisAnalytics.Model.OutputUpdate>(this.ApplicationUpdate_OutputUpdate);
            }
            if (this.ApplicationUpdate_ReferenceDataSourceUpdate != null)
            {
                context.ApplicationUpdate_ReferenceDataSourceUpdate = new List<Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate>(this.ApplicationUpdate_ReferenceDataSourceUpdate);
            }
            context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            #if MODULAR
            if (this.CurrentApplicationVersionId == null && ParameterWasBound(nameof(this.CurrentApplicationVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentApplicationVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalytics.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate ApplicationUpdate
            var requestApplicationUpdateIsNull = true;
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
            if (cmdletContext.ApplicationUpdate_CloudWatchLoggingOptionUpdate != null)
            {
                requestApplicationUpdate_applicationUpdate_CloudWatchLoggingOptionUpdate = cmdletContext.ApplicationUpdate_CloudWatchLoggingOptionUpdate;
            }
            if (requestApplicationUpdate_applicationUpdate_CloudWatchLoggingOptionUpdate != null)
            {
                request.ApplicationUpdate.CloudWatchLoggingOptionUpdates = requestApplicationUpdate_applicationUpdate_CloudWatchLoggingOptionUpdate;
                requestApplicationUpdateIsNull = false;
            }
            List<Amazon.KinesisAnalytics.Model.InputUpdate> requestApplicationUpdate_applicationUpdate_InputUpdate = null;
            if (cmdletContext.ApplicationUpdate_InputUpdate != null)
            {
                requestApplicationUpdate_applicationUpdate_InputUpdate = cmdletContext.ApplicationUpdate_InputUpdate;
            }
            if (requestApplicationUpdate_applicationUpdate_InputUpdate != null)
            {
                request.ApplicationUpdate.InputUpdates = requestApplicationUpdate_applicationUpdate_InputUpdate;
                requestApplicationUpdateIsNull = false;
            }
            List<Amazon.KinesisAnalytics.Model.OutputUpdate> requestApplicationUpdate_applicationUpdate_OutputUpdate = null;
            if (cmdletContext.ApplicationUpdate_OutputUpdate != null)
            {
                requestApplicationUpdate_applicationUpdate_OutputUpdate = cmdletContext.ApplicationUpdate_OutputUpdate;
            }
            if (requestApplicationUpdate_applicationUpdate_OutputUpdate != null)
            {
                request.ApplicationUpdate.OutputUpdates = requestApplicationUpdate_applicationUpdate_OutputUpdate;
                requestApplicationUpdateIsNull = false;
            }
            List<Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate> requestApplicationUpdate_applicationUpdate_ReferenceDataSourceUpdate = null;
            if (cmdletContext.ApplicationUpdate_ReferenceDataSourceUpdate != null)
            {
                requestApplicationUpdate_applicationUpdate_ReferenceDataSourceUpdate = cmdletContext.ApplicationUpdate_ReferenceDataSourceUpdate;
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
            public List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOptionUpdate> ApplicationUpdate_CloudWatchLoggingOptionUpdate { get; set; }
            public List<Amazon.KinesisAnalytics.Model.InputUpdate> ApplicationUpdate_InputUpdate { get; set; }
            public List<Amazon.KinesisAnalytics.Model.OutputUpdate> ApplicationUpdate_OutputUpdate { get; set; }
            public List<Amazon.KinesisAnalytics.Model.ReferenceDataSourceUpdate> ApplicationUpdate_ReferenceDataSourceUpdate { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public System.Func<Amazon.KinesisAnalytics.Model.UpdateApplicationResponse, UpdateKINAApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
