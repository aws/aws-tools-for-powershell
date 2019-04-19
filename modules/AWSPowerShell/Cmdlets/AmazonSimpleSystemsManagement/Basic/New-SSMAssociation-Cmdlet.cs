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
    /// When you associate a document with one or more instances using instance IDs or tags,
    /// SSM Agent running on the instance processes the document and configures the instance
    /// as specified.
    /// </para><para>
    /// If you associate a document with an instance that already has an associated document,
    /// the system returns the AssociationAlreadyExists exception.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSMAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateAssociation API operation.", Operation = new[] {"CreateAssociation"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription",
        "This cmdlet returns a AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMAssociationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter AssociationName
        /// <summary>
        /// <para>
        /// <para>Specify a descriptive name for the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssociationName { get; set; }
        #endregion
        
        #region Parameter AutomationTargetParameterName
        /// <summary>
        /// <para>
        /// <para>Specify the target for the association. This target is required for associations that
        /// use an Automation document and target resources by using rate controls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AutomationTargetParameterName { get; set; }
        #endregion
        
        #region Parameter ComplianceSeverity
        /// <summary>
        /// <para>
        /// <para>The severity level to assign to the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance ID.</para>
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3Location_OutputS3BucketName")]
        public System.String S3Location_OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket subfolder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3Location_OutputS3KeyPrefix")]
        public System.String S3Location_OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3Location_OutputS3Region
        /// <summary>
        /// <para>
        /// <para>(Deprecated) You can no longer specify this parameter. The system ignores it. Instead,
        /// Systems Manager automatically determines the Amazon S3 bucket region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3Location_OutputS3Region")]
        public System.String S3Location_OutputS3Region { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the runtime configuration of the document. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A cron expression when the association will be applied to the target(s).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets (either instances or tags) for the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMAssociation (CreateAssociation)"))
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
            
            context.AssociationName = this.AssociationName;
            context.AutomationTargetParameterName = this.AutomationTargetParameterName;
            context.ComplianceSeverity = this.ComplianceSeverity;
            context.DocumentVersion = this.DocumentVersion;
            context.InstanceId = this.InstanceId;
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxErrors = this.MaxError;
            context.Name = this.Name;
            context.OutputLocation_S3Location_OutputS3BucketName = this.S3Location_OutputS3BucketName;
            context.OutputLocation_S3Location_OutputS3KeyPrefix = this.S3Location_OutputS3KeyPrefix;
            context.OutputLocation_S3Location_OutputS3Region = this.S3Location_OutputS3Region;
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameters.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Parameters.Add((String)hashKey, valueSet);
                }
            }
            context.ScheduleExpression = this.ScheduleExpression;
            if (this.Target != null)
            {
                context.Targets = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
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
            if (cmdletContext.MaxErrors != null)
            {
                request.MaxErrors = cmdletContext.MaxErrors;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputLocation
            bool requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.SimpleSystemsManagement.Model.InstanceAssociationOutputLocation();
            Amazon.SimpleSystemsManagement.Model.S3OutputLocation requestOutputLocation_outputLocation_S3Location = null;
            
             // populate S3Location
            bool requestOutputLocation_outputLocation_S3LocationIsNull = true;
            requestOutputLocation_outputLocation_S3Location = new Amazon.SimpleSystemsManagement.Model.S3OutputLocation();
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName = null;
            if (cmdletContext.OutputLocation_S3Location_OutputS3BucketName != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName = cmdletContext.OutputLocation_S3Location_OutputS3BucketName;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3BucketName = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3BucketName;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix = null;
            if (cmdletContext.OutputLocation_S3Location_OutputS3KeyPrefix != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix = cmdletContext.OutputLocation_S3Location_OutputS3KeyPrefix;
            }
            if (requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix != null)
            {
                requestOutputLocation_outputLocation_S3Location.OutputS3KeyPrefix = requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3KeyPrefix;
                requestOutputLocation_outputLocation_S3LocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region = null;
            if (cmdletContext.OutputLocation_S3Location_OutputS3Region != null)
            {
                requestOutputLocation_outputLocation_S3Location_s3Location_OutputS3Region = cmdletContext.OutputLocation_S3Location_OutputS3Region;
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
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.ScheduleExpression != null)
            {
                request.ScheduleExpression = cmdletContext.ScheduleExpression;
            }
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AssociationDescription;
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
            public System.String AssociationName { get; set; }
            public System.String AutomationTargetParameterName { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationComplianceSeverity ComplianceSeverity { get; set; }
            public System.String DocumentVersion { get; set; }
            public System.String InstanceId { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxErrors { get; set; }
            public System.String Name { get; set; }
            public System.String OutputLocation_S3Location_OutputS3BucketName { get; set; }
            public System.String OutputLocation_S3Location_OutputS3KeyPrefix { get; set; }
            public System.String OutputLocation_S3Location_OutputS3Region { get; set; }
            public Dictionary<System.String, List<System.String>> Parameters { get; set; }
            public System.String ScheduleExpression { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Targets { get; set; }
        }
        
    }
}
