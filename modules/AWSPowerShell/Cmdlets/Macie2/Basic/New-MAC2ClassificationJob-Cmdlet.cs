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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Creates and defines the settings for a classification job.
    /// </summary>
    [Cmdlet("New", "MAC2ClassificationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie2.Model.CreateClassificationJobResponse")]
    [AWSCmdlet("Calls the Amazon Macie 2 CreateClassificationJob API operation.", Operation = new[] {"CreateClassificationJob"}, SelectReturnType = typeof(Amazon.Macie2.Model.CreateClassificationJobResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.CreateClassificationJobResponse",
        "This cmdlet returns an Amazon.Macie2.Model.CreateClassificationJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMAC2ClassificationJobCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        #region Parameter Excludes_And
        /// <summary>
        /// <para>
        /// <para>An array of conditions, one for each condition that determines which objects to include
        /// or exclude from the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3JobDefinition_Scoping_Excludes_And")]
        public Amazon.Macie2.Model.JobScopeTerm[] Excludes_And { get; set; }
        #endregion
        
        #region Parameter Includes_And
        /// <summary>
        /// <para>
        /// <para>An array of conditions, one for each condition that determines which objects to include
        /// or exclude from the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3JobDefinition_Scoping_Includes_And")]
        public Amazon.Macie2.Model.JobScopeTerm[] Includes_And { get; set; }
        #endregion
        
        #region Parameter S3JobDefinition_BucketDefinition
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each AWS account that owns buckets to analyze. Each object
        /// specifies the account ID for an account and one or more buckets to analyze for the
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3JobDefinition_BucketDefinitions")]
        public Amazon.Macie2.Model.S3BucketDefinitionForJob[] S3JobDefinition_BucketDefinition { get; set; }
        #endregion
        
        #region Parameter CustomDataIdentifierId
        /// <summary>
        /// <para>
        /// <para>The custom data identifiers to use for data analysis and classification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomDataIdentifierIds")]
        public System.String[] CustomDataIdentifierId { get; set; }
        #endregion
        
        #region Parameter ScheduleFrequency_DailySchedule
        /// <summary>
        /// <para>
        /// <para>Specifies a daily recurrence pattern for running the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Macie2.Model.DailySchedule ScheduleFrequency_DailySchedule { get; set; }
        #endregion
        
        #region Parameter MonthlySchedule_DayOfMonth
        /// <summary>
        /// <para>
        /// <para>The numeric day of the month when Amazon Macie runs the job. This value can be an
        /// integer from 1 through 31.</para><para>If this value exceeds the number of days in a certain month, Macie runs the job on
        /// the last day of that month. For example, if this value is 31 and a month has only
        /// 30 days, Macie runs the job on day 30 of that month.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleFrequency_MonthlySchedule_DayOfMonth")]
        public System.Int32? MonthlySchedule_DayOfMonth { get; set; }
        #endregion
        
        #region Parameter WeeklySchedule_DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The day of the week when Amazon Macie runs the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleFrequency_WeeklySchedule_DayOfWeek")]
        [AWSConstantClassSource("Amazon.Macie2.DayOfWeek")]
        public Amazon.Macie2.DayOfWeek WeeklySchedule_DayOfWeek { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the job. The description can contain as many as 200 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InitialRun
        /// <summary>
        /// <para>
        /// <para>Specifies whether to analyze all existing, eligible objects immediately after the
        /// job is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InitialRun { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>The schedule for running the job. Valid values are:</para><ul><li><para>ONE_TIME - Run the job only once. If you specify this value, don't specify a value
        /// for the scheduleFrequency property.</para></li><li><para>SCHEDULED - Run the job on a daily, weekly, or monthly basis. If you specify this
        /// value, use the scheduleFrequency property to define the recurrence pattern for the
        /// job.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Macie2.JobType")]
        public Amazon.Macie2.JobType JobType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A custom name for the job. The name can contain as many as 500 characters.</para>
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
        
        #region Parameter SamplingPercentage
        /// <summary>
        /// <para>
        /// <para>The sampling depth, as a percentage, to apply when processing objects. This value
        /// determines the percentage of eligible objects that the job analyzes. If this value
        /// is less than 100, Amazon Macie selects the objects to analyze at random, up to the
        /// specified percentage, and analyzes all the data in those objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SamplingPercentage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs that specifies the tags to associate with the job.</para><para>A job can have a maximum of 50 tags. Each tag consists of a tag key and an associated
        /// tag value. The maximum length of a tag key is 128 characters. The maximum length of
        /// a tag value is 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.CreateClassificationJobResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.CreateClassificationJobResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MAC2ClassificationJob (CreateClassificationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.CreateClassificationJobResponse, NewMAC2ClassificationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CustomDataIdentifierId != null)
            {
                context.CustomDataIdentifierId = new List<System.String>(this.CustomDataIdentifierId);
            }
            context.Description = this.Description;
            context.InitialRun = this.InitialRun;
            context.JobType = this.JobType;
            #if MODULAR
            if (this.JobType == null && ParameterWasBound(nameof(this.JobType)))
            {
                WriteWarning("You are passing $null as a value for parameter JobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.S3JobDefinition_BucketDefinition != null)
            {
                context.S3JobDefinition_BucketDefinition = new List<Amazon.Macie2.Model.S3BucketDefinitionForJob>(this.S3JobDefinition_BucketDefinition);
            }
            if (this.Excludes_And != null)
            {
                context.Excludes_And = new List<Amazon.Macie2.Model.JobScopeTerm>(this.Excludes_And);
            }
            if (this.Includes_And != null)
            {
                context.Includes_And = new List<Amazon.Macie2.Model.JobScopeTerm>(this.Includes_And);
            }
            context.SamplingPercentage = this.SamplingPercentage;
            context.ScheduleFrequency_DailySchedule = this.ScheduleFrequency_DailySchedule;
            context.MonthlySchedule_DayOfMonth = this.MonthlySchedule_DayOfMonth;
            context.WeeklySchedule_DayOfWeek = this.WeeklySchedule_DayOfWeek;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.Macie2.Model.CreateClassificationJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomDataIdentifierId != null)
            {
                request.CustomDataIdentifierIds = cmdletContext.CustomDataIdentifierId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InitialRun != null)
            {
                request.InitialRun = cmdletContext.InitialRun.Value;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate S3JobDefinition
            var requestS3JobDefinitionIsNull = true;
            request.S3JobDefinition = new Amazon.Macie2.Model.S3JobDefinition();
            List<Amazon.Macie2.Model.S3BucketDefinitionForJob> requestS3JobDefinition_s3JobDefinition_BucketDefinition = null;
            if (cmdletContext.S3JobDefinition_BucketDefinition != null)
            {
                requestS3JobDefinition_s3JobDefinition_BucketDefinition = cmdletContext.S3JobDefinition_BucketDefinition;
            }
            if (requestS3JobDefinition_s3JobDefinition_BucketDefinition != null)
            {
                request.S3JobDefinition.BucketDefinitions = requestS3JobDefinition_s3JobDefinition_BucketDefinition;
                requestS3JobDefinitionIsNull = false;
            }
            Amazon.Macie2.Model.Scoping requestS3JobDefinition_s3JobDefinition_Scoping = null;
            
             // populate Scoping
            var requestS3JobDefinition_s3JobDefinition_ScopingIsNull = true;
            requestS3JobDefinition_s3JobDefinition_Scoping = new Amazon.Macie2.Model.Scoping();
            Amazon.Macie2.Model.JobScopingBlock requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes = null;
            
             // populate Excludes
            var requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_ExcludesIsNull = true;
            requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes = new Amazon.Macie2.Model.JobScopingBlock();
            List<Amazon.Macie2.Model.JobScopeTerm> requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes_excludes_And = null;
            if (cmdletContext.Excludes_And != null)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes_excludes_And = cmdletContext.Excludes_And;
            }
            if (requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes_excludes_And != null)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes.And = requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes_excludes_And;
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_ExcludesIsNull = false;
            }
             // determine if requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes should be set to null
            if (requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_ExcludesIsNull)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes = null;
            }
            if (requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes != null)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping.Excludes = requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Excludes;
                requestS3JobDefinition_s3JobDefinition_ScopingIsNull = false;
            }
            Amazon.Macie2.Model.JobScopingBlock requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes = null;
            
             // populate Includes
            var requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_IncludesIsNull = true;
            requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes = new Amazon.Macie2.Model.JobScopingBlock();
            List<Amazon.Macie2.Model.JobScopeTerm> requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes_includes_And = null;
            if (cmdletContext.Includes_And != null)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes_includes_And = cmdletContext.Includes_And;
            }
            if (requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes_includes_And != null)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes.And = requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes_includes_And;
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_IncludesIsNull = false;
            }
             // determine if requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes should be set to null
            if (requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_IncludesIsNull)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes = null;
            }
            if (requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes != null)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping.Includes = requestS3JobDefinition_s3JobDefinition_Scoping_s3JobDefinition_Scoping_Includes;
                requestS3JobDefinition_s3JobDefinition_ScopingIsNull = false;
            }
             // determine if requestS3JobDefinition_s3JobDefinition_Scoping should be set to null
            if (requestS3JobDefinition_s3JobDefinition_ScopingIsNull)
            {
                requestS3JobDefinition_s3JobDefinition_Scoping = null;
            }
            if (requestS3JobDefinition_s3JobDefinition_Scoping != null)
            {
                request.S3JobDefinition.Scoping = requestS3JobDefinition_s3JobDefinition_Scoping;
                requestS3JobDefinitionIsNull = false;
            }
             // determine if request.S3JobDefinition should be set to null
            if (requestS3JobDefinitionIsNull)
            {
                request.S3JobDefinition = null;
            }
            if (cmdletContext.SamplingPercentage != null)
            {
                request.SamplingPercentage = cmdletContext.SamplingPercentage.Value;
            }
            
             // populate ScheduleFrequency
            var requestScheduleFrequencyIsNull = true;
            request.ScheduleFrequency = new Amazon.Macie2.Model.JobScheduleFrequency();
            Amazon.Macie2.Model.DailySchedule requestScheduleFrequency_scheduleFrequency_DailySchedule = null;
            if (cmdletContext.ScheduleFrequency_DailySchedule != null)
            {
                requestScheduleFrequency_scheduleFrequency_DailySchedule = cmdletContext.ScheduleFrequency_DailySchedule;
            }
            if (requestScheduleFrequency_scheduleFrequency_DailySchedule != null)
            {
                request.ScheduleFrequency.DailySchedule = requestScheduleFrequency_scheduleFrequency_DailySchedule;
                requestScheduleFrequencyIsNull = false;
            }
            Amazon.Macie2.Model.MonthlySchedule requestScheduleFrequency_scheduleFrequency_MonthlySchedule = null;
            
             // populate MonthlySchedule
            var requestScheduleFrequency_scheduleFrequency_MonthlyScheduleIsNull = true;
            requestScheduleFrequency_scheduleFrequency_MonthlySchedule = new Amazon.Macie2.Model.MonthlySchedule();
            System.Int32? requestScheduleFrequency_scheduleFrequency_MonthlySchedule_monthlySchedule_DayOfMonth = null;
            if (cmdletContext.MonthlySchedule_DayOfMonth != null)
            {
                requestScheduleFrequency_scheduleFrequency_MonthlySchedule_monthlySchedule_DayOfMonth = cmdletContext.MonthlySchedule_DayOfMonth.Value;
            }
            if (requestScheduleFrequency_scheduleFrequency_MonthlySchedule_monthlySchedule_DayOfMonth != null)
            {
                requestScheduleFrequency_scheduleFrequency_MonthlySchedule.DayOfMonth = requestScheduleFrequency_scheduleFrequency_MonthlySchedule_monthlySchedule_DayOfMonth.Value;
                requestScheduleFrequency_scheduleFrequency_MonthlyScheduleIsNull = false;
            }
             // determine if requestScheduleFrequency_scheduleFrequency_MonthlySchedule should be set to null
            if (requestScheduleFrequency_scheduleFrequency_MonthlyScheduleIsNull)
            {
                requestScheduleFrequency_scheduleFrequency_MonthlySchedule = null;
            }
            if (requestScheduleFrequency_scheduleFrequency_MonthlySchedule != null)
            {
                request.ScheduleFrequency.MonthlySchedule = requestScheduleFrequency_scheduleFrequency_MonthlySchedule;
                requestScheduleFrequencyIsNull = false;
            }
            Amazon.Macie2.Model.WeeklySchedule requestScheduleFrequency_scheduleFrequency_WeeklySchedule = null;
            
             // populate WeeklySchedule
            var requestScheduleFrequency_scheduleFrequency_WeeklyScheduleIsNull = true;
            requestScheduleFrequency_scheduleFrequency_WeeklySchedule = new Amazon.Macie2.Model.WeeklySchedule();
            Amazon.Macie2.DayOfWeek requestScheduleFrequency_scheduleFrequency_WeeklySchedule_weeklySchedule_DayOfWeek = null;
            if (cmdletContext.WeeklySchedule_DayOfWeek != null)
            {
                requestScheduleFrequency_scheduleFrequency_WeeklySchedule_weeklySchedule_DayOfWeek = cmdletContext.WeeklySchedule_DayOfWeek;
            }
            if (requestScheduleFrequency_scheduleFrequency_WeeklySchedule_weeklySchedule_DayOfWeek != null)
            {
                requestScheduleFrequency_scheduleFrequency_WeeklySchedule.DayOfWeek = requestScheduleFrequency_scheduleFrequency_WeeklySchedule_weeklySchedule_DayOfWeek;
                requestScheduleFrequency_scheduleFrequency_WeeklyScheduleIsNull = false;
            }
             // determine if requestScheduleFrequency_scheduleFrequency_WeeklySchedule should be set to null
            if (requestScheduleFrequency_scheduleFrequency_WeeklyScheduleIsNull)
            {
                requestScheduleFrequency_scheduleFrequency_WeeklySchedule = null;
            }
            if (requestScheduleFrequency_scheduleFrequency_WeeklySchedule != null)
            {
                request.ScheduleFrequency.WeeklySchedule = requestScheduleFrequency_scheduleFrequency_WeeklySchedule;
                requestScheduleFrequencyIsNull = false;
            }
             // determine if request.ScheduleFrequency should be set to null
            if (requestScheduleFrequencyIsNull)
            {
                request.ScheduleFrequency = null;
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
        
        private Amazon.Macie2.Model.CreateClassificationJobResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.CreateClassificationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "CreateClassificationJob");
            try
            {
                #if DESKTOP
                return client.CreateClassificationJob(request);
                #elif CORECLR
                return client.CreateClassificationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> CustomDataIdentifierId { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? InitialRun { get; set; }
            public Amazon.Macie2.JobType JobType { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Macie2.Model.S3BucketDefinitionForJob> S3JobDefinition_BucketDefinition { get; set; }
            public List<Amazon.Macie2.Model.JobScopeTerm> Excludes_And { get; set; }
            public List<Amazon.Macie2.Model.JobScopeTerm> Includes_And { get; set; }
            public System.Int32? SamplingPercentage { get; set; }
            public Amazon.Macie2.Model.DailySchedule ScheduleFrequency_DailySchedule { get; set; }
            public System.Int32? MonthlySchedule_DayOfMonth { get; set; }
            public Amazon.Macie2.DayOfWeek WeeklySchedule_DayOfWeek { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Macie2.Model.CreateClassificationJobResponse, NewMAC2ClassificationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
