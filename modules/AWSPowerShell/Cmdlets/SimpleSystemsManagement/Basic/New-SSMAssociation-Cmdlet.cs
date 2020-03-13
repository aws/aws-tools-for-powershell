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
    /// Associates the specified Systems Manager document with the specified instances or
    /// targets.
    /// 
    ///  
    /// <para>
    /// When you associate a document with one or more instances, SSM Agent running on the
    /// instance processes the document and configures the instance as specified. If you associate
    /// a document with an instance that already has an associated document, the system returns
    /// the <code>AssociationAlreadyExists</code> exception.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSMAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateAssociation API operation.", Operation = new[] {"CreateAssociation"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription or Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMAssociationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyOnlyAtCronInterval
        /// <summary>
        /// <para>
        /// <para>By default, when you create a new associations, the system runs it immediately after
        /// it is created and then according to the schedule you specified. Specify this option
        /// if you don't want an association to run immediately after you create it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyOnlyAtCronInterval { get; set; }
        #endregion
        
        #region Parameter AssociationName
        /// <summary>
        /// <para>
        /// <para>Specify a descriptive name for the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationName { get; set; }
        #endregion
        
        #region Parameter AutomationTargetParameterName
        /// <summary>
        /// <para>
        /// <para>Specify the target for the association. This target is required for associations that
        /// use an Automation document and target resources by using rate controls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutomationTargetParameterName { get; set; }
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
        /// <para>The document version you want to associate with the target(s). Can be a specific version
        /// or the default version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance ID.</para><note><para><code>InstanceId</code> has been deprecated. To specify an instance ID for an association,
        /// use the <code>Targets</code> parameter. Requests that include the parameter <code>InstanceID</code>
        /// with SSM documents that use schema version 2.0 or later will fail. In addition, if
        /// you use the parameter <code>InstanceId</code>, you cannot use the parameters <code>AssociationName</code>,
        /// <code>DocumentVersion</code>, <code>MaxErrors</code>, <code>MaxConcurrency</code>,
        /// <code>OutputLocation</code>, or <code>ScheduleExpression</code>. To use these parameters,
        /// you must use the <code>Targets</code> parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of targets allowed to run the association at the same time. You
        /// can specify a number, for example 10, or a percentage of the target set, for example
        /// 10%. The default value is 100%, which means all targets run the association at the
        /// same time.</para><para>If a new instance starts and attempts to run an association while Systems Manager
        /// is running MaxConcurrency associations, the association is allowed to run. During
        /// the next association interval, the new instance will process its association within
        /// the limit specified for MaxConcurrency.</para>
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
        /// error is returned. If you run an association on 50 instances and set MaxError to 10%,
        /// then the system stops sending the request when the sixth error is received.</para><para>Executions that are already running an association when MaxErrors is reached are allowed
        /// to complete, but some of these executions may fail as well. If you need to ensure
        /// that there won't be more than max-errors failed executions, set MaxConcurrency to
        /// 1 so that executions proceed one at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the SSM document that contains the configuration information for the instance.
        /// You can specify Command or Automation documents.</para><para>You can specify AWS-predefined documents, documents you created, or a document that
        /// is shared with you from another account.</para><para>For SSM documents that are shared with you from other AWS accounts, you must specify
        /// the complete SSM document ARN, in the following format:</para><para><code>arn:<i>partition</i>:ssm:<i>region</i>:<i>account-id</i>:document/<i>document-name</i></code></para><para>For example:</para><para><code>arn:aws:ssm:us-east-2:12345678912:document/My-Shared-Document</code></para><para>For AWS-predefined documents and SSM documents you created in your account, you only
        /// need to specify the document name. For example, <code>AWS-ApplyPatchBaseline</code>
        /// or <code>My-Document</code>.</para>
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
        /// <para>(Deprecated) You can no longer specify this parameter. The system ignores it. Instead,
        /// Systems Manager automatically determines the Region of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3Location_OutputS3Region")]
        public System.String S3Location_OutputS3Region { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the runtime configuration of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A cron expression when the association will be applied to the target(s).</para>
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
        /// parameter for the <a>PutComplianceItems</a> API action. In this case, compliance data
        /// is not managed by State Manager. It is managed by your direct call to the <a>PutComplianceItems</a>
        /// API action.</para><para>By default, all associations use <code>AUTO</code> mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.AssociationSyncCompliance")]
        public Amazon.SimpleSystemsManagement.AssociationSyncCompliance SyncCompliance { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets for the association. You can target instances by using tags, AWS Resource
        /// Groups, all instances in an AWS account, or individual instance IDs. For more information
        /// about choosing targets for an association, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-state-manager-targets-and-rate-controls.html">Using
        /// targets and rate controls with State Manager associations</a> in the <i>AWS Systems
        /// Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssociationDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssociationDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMAssociation (CreateAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse, NewSSMAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyOnlyAtCronInterval = this.ApplyOnlyAtCronInterval;
            context.AssociationName = this.AssociationName;
            context.AutomationTargetParameterName = this.AutomationTargetParameterName;
            context.ComplianceSeverity = this.ComplianceSeverity;
            context.DocumentVersion = this.DocumentVersion;
            context.InstanceId = this.InstanceId;
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxError = this.MaxError;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateAssociationRequest();
            
            if (cmdletContext.ApplyOnlyAtCronInterval != null)
            {
                request.ApplyOnlyAtCronInterval = cmdletContext.ApplyOnlyAtCronInterval.Value;
            }
            if (cmdletContext.AssociationName != null)
            {
                request.AssociationName = cmdletContext.AssociationName;
            }
            if (cmdletContext.AutomationTargetParameterName != null)
            {
                request.AutomationTargetParameterName = cmdletContext.AutomationTargetParameterName;
            }
            if (cmdletContext.ComplianceSeverity != null)
            {
                request.ComplianceSeverity = cmdletContext.ComplianceSeverity;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateAssociation");
            try
            {
                #if DESKTOP
                return client.CreateAssociation(request);
                #elif CORECLR
                return client.CreateAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationName { get; set; }
            public System.String AutomationTargetParameterName { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationComplianceSeverity ComplianceSeverity { get; set; }
            public System.String DocumentVersion { get; set; }
            public System.String InstanceId { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxError { get; set; }
            public System.String Name { get; set; }
            public System.String S3Location_OutputS3BucketName { get; set; }
            public System.String S3Location_OutputS3KeyPrefix { get; set; }
            public System.String S3Location_OutputS3Region { get; set; }
            public Dictionary<System.String, List<System.String>> Parameter { get; set; }
            public System.String ScheduleExpression { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationSyncCompliance SyncCompliance { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Target { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse, NewSSMAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssociationDescription;
        }
        
    }
}
