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
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Creates a recurring schedule for usage reports to deliver to the specified S3 location
    /// with a specified daily or weekly interval.
    /// </summary>
    [Cmdlet("New", "ALXBBusinessReportSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Alexa For Business CreateBusinessReportSchedule API operation.", Operation = new[] {"CreateBusinessReportSchedule"}, SelectReturnType = typeof(Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse))]
    [AWSCmdletOutput("System.String or Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewALXBBusinessReportScheduleCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The client request token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the generated report (individual CSV files or zipped files of individual
        /// files).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.BusinessReportFormat")]
        public Amazon.AlexaForBusiness.BusinessReportFormat Format { get; set; }
        #endregion
        
        #region Parameter ContentRange_Interval
        /// <summary>
        /// <para>
        /// <para>The interval of the content range.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.BusinessReportInterval")]
        public Amazon.AlexaForBusiness.BusinessReportInterval ContentRange_Interval { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>The S3 bucket name of the output reports. If this isn't specified, the report can
        /// be retrieved from a download link by calling ListBusinessReportSchedule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 key where the report is delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter ScheduleName
        /// <summary>
        /// <para>
        /// <para>The name identifier of the schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ScheduleName { get; set; }
        #endregion
        
        #region Parameter Recurrence_StartDate
        /// <summary>
        /// <para>
        /// <para>The start date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Recurrence_StartDate { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the business report schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AlexaForBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScheduleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse).
        /// Specifying the name of a property of type Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScheduleArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScheduleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScheduleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScheduleName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ALXBBusinessReportSchedule (CreateBusinessReportSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse, NewALXBBusinessReportScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScheduleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ContentRange_Interval = this.ContentRange_Interval;
            #if MODULAR
            if (this.ContentRange_Interval == null && ParameterWasBound(nameof(this.ContentRange_Interval)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentRange_Interval which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Recurrence_StartDate = this.Recurrence_StartDate;
            context.S3BucketName = this.S3BucketName;
            context.S3KeyPrefix = this.S3KeyPrefix;
            context.ScheduleName = this.ScheduleName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AlexaForBusiness.Model.Tag>(this.Tag);
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
            var request = new Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate ContentRange
            var requestContentRangeIsNull = true;
            request.ContentRange = new Amazon.AlexaForBusiness.Model.BusinessReportContentRange();
            Amazon.AlexaForBusiness.BusinessReportInterval requestContentRange_contentRange_Interval = null;
            if (cmdletContext.ContentRange_Interval != null)
            {
                requestContentRange_contentRange_Interval = cmdletContext.ContentRange_Interval;
            }
            if (requestContentRange_contentRange_Interval != null)
            {
                request.ContentRange.Interval = requestContentRange_contentRange_Interval;
                requestContentRangeIsNull = false;
            }
             // determine if request.ContentRange should be set to null
            if (requestContentRangeIsNull)
            {
                request.ContentRange = null;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            
             // populate Recurrence
            var requestRecurrenceIsNull = true;
            request.Recurrence = new Amazon.AlexaForBusiness.Model.BusinessReportRecurrence();
            System.String requestRecurrence_recurrence_StartDate = null;
            if (cmdletContext.Recurrence_StartDate != null)
            {
                requestRecurrence_recurrence_StartDate = cmdletContext.Recurrence_StartDate;
            }
            if (requestRecurrence_recurrence_StartDate != null)
            {
                request.Recurrence.StartDate = requestRecurrence_recurrence_StartDate;
                requestRecurrenceIsNull = false;
            }
             // determine if request.Recurrence should be set to null
            if (requestRecurrenceIsNull)
            {
                request.Recurrence = null;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.S3KeyPrefix != null)
            {
                request.S3KeyPrefix = cmdletContext.S3KeyPrefix;
            }
            if (cmdletContext.ScheduleName != null)
            {
                request.ScheduleName = cmdletContext.ScheduleName;
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
        
        private Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "CreateBusinessReportSchedule");
            try
            {
                #if DESKTOP
                return client.CreateBusinessReportSchedule(request);
                #elif CORECLR
                return client.CreateBusinessReportScheduleAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Amazon.AlexaForBusiness.BusinessReportInterval ContentRange_Interval { get; set; }
            public Amazon.AlexaForBusiness.BusinessReportFormat Format { get; set; }
            public System.String Recurrence_StartDate { get; set; }
            public System.String S3BucketName { get; set; }
            public System.String S3KeyPrefix { get; set; }
            public System.String ScheduleName { get; set; }
            public List<Amazon.AlexaForBusiness.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.AlexaForBusiness.Model.CreateBusinessReportScheduleResponse, NewALXBBusinessReportScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScheduleArn;
        }
        
    }
}
