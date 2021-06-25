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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Updates an association. You can update the association name and version, the document
    /// version, schedule, parameters, and Amazon Simple Storage Service (Amazon S3) output.
    /// 
    /// 
    ///  
    /// <para>
    /// In order to call this API operation, your Identity and Access Management (IAM) user
    /// account, group, or role must be configured with permission to call the <a>DescribeAssociation</a>
    /// API operation. If you don't have permission to call <code>DescribeAssociation</code>,
    /// then you receive the following error: <code>An error occurred (AccessDeniedException)
    /// when calling the UpdateAssociation operation: User: &lt;user_arn&gt; isn't authorized
    /// to perform: ssm:DescribeAssociation on resource: &lt;resource_arn&gt;</code></para><important><para>
    /// When you update an association, the association immediately runs against the specified
    /// targets.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "SSMAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdateAssociation API operation.", Operation = new[] {"UpdateAssociation"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription or Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSMAssociationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyOnlyAtCronInterval
        /// <summary>
        /// <para>
        /// <para>By default, when you update an association, the system runs it immediately after it
        /// is updated and then according to the schedule you specified. Specify this option if
        /// you don't want an association to run immediately after you update it. This parameter
        /// isn't supported for rate expressions.</para><para>Also, if you specified this option when you created the association, you can reset
        /// it. To do so, specify the <code>no-apply-only-at-cron-interval</code> parameter when
        /// you update the association from the command line. This parameter forces the association
        /// to run immediately after updating it and according to the interval specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyOnlyAtCronInterval { get; set; }
        #endregion
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the association you want to update. </para>
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
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter AssociationName
        /// <summary>
        /// <para>
        /// <para>The name of the association that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationName { get; set; }
        #endregion
        
        #region Parameter AssociationVersion
        /// <summary>
        /// <para>
        /// <para>This parameter is provided for concurrency control purposes. You must specify the
        /// latest association version in the service. If you want to ensure that this request
        /// succeeds, either specify <code>$LATEST</code>, or omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationVersion { get; set; }
        #endregion
        
        #region Parameter AutomationTargetParameterName
        /// <summary>
        /// <para>
        /// <para>Specify the target for the association. This target is required for associations that
        /// use an Automation runbook and target resources by using rate controls. Automation
        /// is a capability of Amazon Web Services Systems Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutomationTargetParameterName { get; set; }
        #endregion
        
        #region Parameter CalendarName
        /// <summary>
        /// <para>
        /// <para>The names or Amazon Resource Names (ARNs) of the Change Calendar type documents you
        /// want to gate your associations under. The associations only run when that change calendar
        /// is open. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-change-calendar">Amazon
        /// Web Services Systems Manager Change Calendar</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CalendarNames")]
        public System.String[] CalendarName { get; set; }
        #endregion
        
        #region Parameter ComplianceSeverity
        /// <summary>
        /// <para>
        /// <para>The severity level to assign to the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.AssociationComplianceSeverity")]
        public Amazon.SimpleSystemsManagement.AssociationComplianceSeverity ComplianceSeverity { get; set; }
        #endregion
        
        #region Parameter DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The document version you want update for the association. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of targets allowed to run the association at the same time. You
        /// can specify a number, for example 10, or a percentage of the target set, for example
        /// 10%. The default value is 100%, which means all targets run the association at the
        /// same time.</para><para>If a new instance starts and attempts to run an association while Systems Manager
        /// is running <code>MaxConcurrency</code> associations, the association is allowed to
        /// run. During the next association interval, the new instance will process its association
        /// within the limit specified for <code>MaxConcurrency</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxError
        /// <summary>
        /// <para>
        /// <para>The number of errors that are allowed before the system stops sending requests to
        /// run the association on additional targets. You can specify either an absolute number
        /// of errors, for example 10, or a percentage of the target set, for example 10%. If
        /// you specify 3, for example, the system stops sending requests when the fourth error
        /// is received. If you specify 0, then the system stops sending requests after the first
        /// error is returned. If you run an association on 50 instances and set <code>MaxError</code>
        /// to 10%, then the system stops sending the request when the sixth error is received.</para><para>Executions that are already running an association when <code>MaxErrors</code> is
        /// reached are allowed to complete, but some of these executions may fail as well. If
        /// you need to ensure that there won't be more than max-errors failed executions, set
        /// <code>MaxConcurrency</code> to 1 so that executions proceed one at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the SSM Command document or Automation runbook that contains the configuration
        /// information for the instance.</para><para>You can specify Amazon Web Services-predefined documents, documents you created, or
        /// a document that is shared with you from another account.</para><para>For Systems Manager document (SSM document) that are shared with you from other Amazon
        /// Web Services accounts, you must specify the complete SSM document ARN, in the following
        /// format:</para><para><code>arn:aws:ssm:<i>region</i>:<i>account-id</i>:document/<i>document-name</i></code></para><para>For example:</para><para><code>arn:aws:ssm:us-east-2:12345678912:document/My-Shared-Document</code></para><para>For Amazon Web Services-predefined documents and SSM documents you created in your
        /// account, you only need to specify the document name. For example, <code>AWS-ApplyPatchBaseline</code>
        /// or <code>My-Document</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3Location_OutputS3BucketName")]
        public System.String S3Location_OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 bucket subfolder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3Location_OutputS3KeyPrefix")]
        public System.String S3Location_OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3Location_OutputS3Region")]
        public System.String S3Location_OutputS3Region { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters you want to update for the association. If you create a parameter using
        /// Parameter Store, a capability of Amazon Web Services Systems Manager, you can reference
        /// the parameter using <code>{{ssm:parameter-name}}</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The cron expression used to schedule the association that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter SyncCompliance
        /// <summary>
        /// <para>
        /// <para>The mode for generating association compliance. You can specify <code>AUTO</code>
        /// or <code>MANUAL</code>. In <code>AUTO</code> mode, the system uses the status of the
        /// association execution to determine the compliance status. If the association execution
        /// runs successfully, then the association is <code>COMPLIANT</code>. If the association
        /// execution doesn't run successfully, the association is <code>NON-COMPLIANT</code>.</para><para>In <code>MANUAL</code> mode, you must specify the <code>AssociationId</code> as a
        /// parameter for the <a>PutComplianceItems</a> API operation. In this case, compliance
        /// data isn't managed by State Manager, a capability of Amazon Web Services Systems Manager.
        /// It is managed by your direct call to the <a>PutComplianceItems</a> API operation.</para><para>By default, all associations use <code>AUTO</code> mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.AssociationSyncCompliance")]
        public Amazon.SimpleSystemsManagement.AssociationSyncCompliance SyncCompliance { get; set; }
        #endregion
        
        #region Parameter TargetLocation
        /// <summary>
        /// <para>
        /// <para>A location is a combination of Amazon Web Services Regions and Amazon Web Services
        /// accounts where you want to run the association. Use this action to update an association
        /// in multiple Regions and multiple accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetLocations")]
        public Amazon.SimpleSystemsManagement.Model.TargetLocation[] TargetLocation { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets of the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssociationDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssociationDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssociationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssociationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssociationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMAssociation (UpdateAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse, UpdateSSMAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssociationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyOnlyAtCronInterval = this.ApplyOnlyAtCronInterval;
            context.AssociationId = this.AssociationId;
            #if MODULAR
            if (this.AssociationId == null && ParameterWasBound(nameof(this.AssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssociationName = this.AssociationName;
            context.AssociationVersion = this.AssociationVersion;
            context.AutomationTargetParameterName = this.AutomationTargetParameterName;
            if (this.CalendarName != null)
            {
                context.CalendarName = new List<System.String>(this.CalendarName);
            }
            context.ComplianceSeverity = this.ComplianceSeverity;
            context.DocumentVersion = this.DocumentVersion;
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxError = this.MaxError;
            context.Name = this.Name;
            context.S3Location_OutputS3BucketName = this.S3Location_OutputS3BucketName;
            context.S3Location_OutputS3KeyPrefix = this.S3Location_OutputS3KeyPrefix;
            context.S3Location_OutputS3Region = this.S3Location_OutputS3Region;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Parameter.Add((String)hashKey, valueSet);
                }
            }
            context.ScheduleExpression = this.ScheduleExpression;
            context.SyncCompliance = this.SyncCompliance;
            if (this.TargetLocation != null)
            {
                context.TargetLocation = new List<Amazon.SimpleSystemsManagement.Model.TargetLocation>(this.TargetLocation);
            }
            if (this.Target != null)
            {
                context.Target = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateAssociationRequest();
            
            if (cmdletContext.ApplyOnlyAtCronInterval != null)
            {
                request.ApplyOnlyAtCronInterval = cmdletContext.ApplyOnlyAtCronInterval.Value;
            }
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.AssociationName != null)
            {
                request.AssociationName = cmdletContext.AssociationName;
            }
            if (cmdletContext.AssociationVersion != null)
            {
                request.AssociationVersion = cmdletContext.AssociationVersion;
            }
            if (cmdletContext.AutomationTargetParameterName != null)
            {
                request.AutomationTargetParameterName = cmdletContext.AutomationTargetParameterName;
            }
            if (cmdletContext.CalendarName != null)
            {
                request.CalendarNames = cmdletContext.CalendarName;
            }
            if (cmdletContext.ComplianceSeverity != null)
            {
                request.ComplianceSeverity = cmdletContext.ComplianceSeverity;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency;
            }
            if (cmdletContext.MaxError != null)
            {
                request.MaxErrors = cmdletContext.MaxError;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputLocation
            var requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.SimpleSystemsManagement.Model.InstanceAssociationOutputLocation();
            Amazon.SimpleSystemsManagement.Model.S3OutputLocation requestOutputLocation_outputLocation_S3Location = null;
            
             // populate S3Location
            var requestOutputLocation_outputLocation_S3LocationIsNull = true;
            requestOutputLocation_outputLocation_S3Location = new Amazon.SimpleSystemsManagement.Model.S3OutputLocation();
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName = null;
            if (cmdletContext.S3Location_OutputS3BucketName != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName = cmdletContext.S3Location_OutputS3BucketName;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3BucketName = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix = null;
            if (cmdletContext.S3Location_OutputS3KeyPrefix != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix = cmdletContext.S3Location_OutputS3KeyPrefix;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3KeyPrefix = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region = null;
            if (cmdletContext.S3Location_OutputS3Region != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region = cmdletContext.S3Location_OutputS3Region;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3Region = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
             // determine if requestOutputLocation_outputLocation_S3Location should be set to null
            if (requestOutputLocation_outputLocation_S3LocationIsNull)
            {
                requestOutputLocation_outputLocation_S3Location = null;
            }
            if (requestOutputLocation_outputLocation_S3Location != null)
            {
                request.OutputLocation.S3Location = requestOutputLocation_outputLocation_S3Location;
                requestOutputLocationIsNull = false;
            }
             // determine if request.OutputLocation should be set to null
            if (requestOutputLocationIsNull)
            {
                request.OutputLocation = null;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ScheduleExpression != null)
            {
                request.ScheduleExpression = cmdletContext.ScheduleExpression;
            }
            if (cmdletContext.SyncCompliance != null)
            {
                request.SyncCompliance = cmdletContext.SyncCompliance;
            }
            if (cmdletContext.TargetLocation != null)
            {
                request.TargetLocations = cmdletContext.TargetLocation;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdateAssociation");
            try
            {
                #if DESKTOP
                return client.UpdateAssociation(request);
                #elif CORECLR
                return client.UpdateAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyOnlyAtCronInterval { get; set; }
            public System.String AssociationId { get; set; }
            public System.String AssociationName { get; set; }
            public System.String AssociationVersion { get; set; }
            public System.String AutomationTargetParameterName { get; set; }
            public List<System.String> CalendarName { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationComplianceSeverity ComplianceSeverity { get; set; }
            public System.String DocumentVersion { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxError { get; set; }
            public System.String Name { get; set; }
            public System.String S3Location_OutputS3BucketName { get; set; }
            public System.String S3Location_OutputS3KeyPrefix { get; set; }
            public System.String S3Location_OutputS3Region { get; set; }
            public Dictionary<System.String, List<System.String>> Parameter { get; set; }
            public System.String ScheduleExpression { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationSyncCompliance SyncCompliance { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.TargetLocation> TargetLocation { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Target { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.UpdateAssociationResponse, UpdateSSMAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssociationDescription;
        }
        
    }
}
