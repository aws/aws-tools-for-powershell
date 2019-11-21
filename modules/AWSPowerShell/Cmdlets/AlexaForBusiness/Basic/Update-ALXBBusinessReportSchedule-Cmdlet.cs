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
    /// Updates the configuration of the report delivery schedule with the specified schedule
    /// ARN.
    /// </summary>
    [Cmdlet("Update", "ALXBBusinessReportSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Alexa For Business UpdateBusinessReportSchedule API operation.", Operation = new[] {"UpdateBusinessReportSchedule"}, SelectReturnType = typeof(Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleResponse))]
    [AWSCmdletOutput("None or Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateALXBBusinessReportScheduleCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the generated report (individual CSV files or zipped files of individual
        /// files).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.BusinessReportFormat")]
        public Amazon.AlexaForBusiness.BusinessReportFormat Format { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>The S3 location of the output reports.</para>
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
        
        #region Parameter ScheduleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the business report schedule.</para>
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
        public System.String ScheduleArn { get; set; }
        #endregion
        
        #region Parameter ScheduleName
        /// <summary>
        /// <para>
        /// <para>The name identifier of the schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScheduleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScheduleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScheduleArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ALXBBusinessReportSchedule (UpdateBusinessReportSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleResponse, UpdateALXBBusinessReportScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScheduleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Format = this.Format;
            context.Recurrence_StartDate = this.Recurrence_StartDate;
            context.S3BucketName = this.S3BucketName;
            context.S3KeyPrefix = this.S3KeyPrefix;
            context.ScheduleArn = this.ScheduleArn;
            #if MODULAR
            if (this.ScheduleArn == null && ParameterWasBound(nameof(this.ScheduleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleName = this.ScheduleName;
            
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
            var request = new Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleRequest();
            
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
            if (cmdletContext.ScheduleArn != null)
            {
                request.ScheduleArn = cmdletContext.ScheduleArn;
            }
            if (cmdletContext.ScheduleName != null)
            {
                request.ScheduleName = cmdletContext.ScheduleName;
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
        
        private Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "UpdateBusinessReportSchedule");
            try
            {
                #if DESKTOP
                return client.UpdateBusinessReportSchedule(request);
                #elif CORECLR
                return client.UpdateBusinessReportScheduleAsync(request).GetAwaiter().GetResult();
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
            public Amazon.AlexaForBusiness.BusinessReportFormat Format { get; set; }
            public System.String Recurrence_StartDate { get; set; }
            public System.String S3BucketName { get; set; }
            public System.String S3KeyPrefix { get; set; }
            public System.String ScheduleArn { get; set; }
            public System.String ScheduleName { get; set; }
            public System.Func<Amazon.AlexaForBusiness.Model.UpdateBusinessReportScheduleResponse, UpdateALXBBusinessReportScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
