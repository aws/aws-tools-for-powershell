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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// This request can be sent after CreateRestoreTestingPlan request returns successfully.
    /// This is the second part of creating a resource testing plan, and it must be completed
    /// sequentially.
    /// 
    ///  
    /// <para>
    /// This consists of <c>RestoreTestingSelectionName</c>, <c>ProtectedResourceType</c>,
    /// and one of the following:
    /// </para><ul><li><para><c>ProtectedResourceArns</c></para></li><li><para><c>ProtectedResourceConditions</c></para></li></ul><para>
    /// Each protected resource type can have one single value.
    /// </para><para>
    /// A restore testing selection can include a wildcard value ("*") for <c>ProtectedResourceArns</c>
    /// along with <c>ProtectedResourceConditions</c>. Alternatively, you can include up to
    /// 30 specific protected resource ARNs in <c>ProtectedResourceArns</c>.
    /// </para><para>
    /// Cannot select by both protected resource types AND specific ARNs. Request will fail
    /// if both are included.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BAKRestoreTestingSelection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateRestoreTestingSelectionResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateRestoreTestingSelection API operation.", Operation = new[] {"CreateRestoreTestingSelection"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateRestoreTestingSelectionResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateRestoreTestingSelectionResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateRestoreTestingSelectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBAKRestoreTestingSelectionCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>This is an optional unique string that identifies the request and allows failed requests
        /// to be retried without the risk of running the operation twice. If used, this parameter
        /// must contain 1 to 50 alphanumeric or '-_.' characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelection_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Backup uses to create the target
        /// resource; for example: <c>arn:aws:iam::123456789012:role/S3Access</c>. </para>
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
        public System.String RestoreTestingSelection_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelection_ProtectedResourceArn
        /// <summary>
        /// <para>
        /// <para>Each protected resource can be filtered by its specific ARNs, such as <c>ProtectedResourceArns:
        /// ["arn:aws:...", "arn:aws:..."]</c> or by a wildcard: <c>ProtectedResourceArns: ["*"]</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingSelection_ProtectedResourceArns")]
        public System.String[] RestoreTestingSelection_ProtectedResourceArn { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelection_ProtectedResourceType
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services resource included in a restore testing selection;
        /// for example, an Amazon EBS volume or an Amazon RDS database.</para><para>Supported resource types accepted include:</para><ul><li><para><c>Aurora</c> for Amazon Aurora</para></li><li><para><c>DocumentDB</c> for Amazon DocumentDB (with MongoDB compatibility)</para></li><li><para><c>DynamoDB</c> for Amazon DynamoDB</para></li><li><para><c>EBS</c> for Amazon Elastic Block Store</para></li><li><para><c>EC2</c> for Amazon Elastic Compute Cloud</para></li><li><para><c>EFS</c> for Amazon Elastic File System</para></li><li><para><c>FSx</c> for Amazon FSx</para></li><li><para><c>Neptune</c> for Amazon Neptune</para></li><li><para><c>RDS</c> for Amazon Relational Database Service</para></li><li><para><c>S3</c> for Amazon S3</para></li></ul>
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
        public System.String RestoreTestingSelection_ProtectedResourceType { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelection_RestoreMetadataOverride
        /// <summary>
        /// <para>
        /// <para>You can override certain restore metadata keys by including the parameter <c>RestoreMetadataOverrides</c>
        /// in the body of <c>RestoreTestingSelection</c>. Key values are not case sensitive.</para><para>See the complete list of <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/restore-testing-inferred-metadata.html">restore
        /// testing inferred metadata</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingSelection_RestoreMetadataOverrides")]
        public System.Collections.Hashtable RestoreTestingSelection_RestoreMetadataOverride { get; set; }
        #endregion
        
        #region Parameter RestoreTestingPlanName
        /// <summary>
        /// <para>
        /// <para>Input the restore testing plan name that was returned from the related CreateRestoreTestingPlan
        /// request.</para>
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
        public System.String RestoreTestingPlanName { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelection_RestoreTestingSelectionName
        /// <summary>
        /// <para>
        /// <para>This is the unique name of the restore testing selection that belongs to the related
        /// restore testing plan.</para>
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
        public System.String RestoreTestingSelection_RestoreTestingSelectionName { get; set; }
        #endregion
        
        #region Parameter ProtectedResourceConditions_StringEqual
        /// <summary>
        /// <para>
        /// <para>Filters the values of your tagged resources for only those resources that you tagged
        /// with the same value. Also called "exact matching."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingSelection_ProtectedResourceConditions_StringEquals")]
        public Amazon.Backup.Model.KeyValue[] ProtectedResourceConditions_StringEqual { get; set; }
        #endregion
        
        #region Parameter ProtectedResourceConditions_StringNotEqual
        /// <summary>
        /// <para>
        /// <para>Filters the values of your tagged resources for only those resources that you tagged
        /// that do not have the same value. Also called "negated matching."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingSelection_ProtectedResourceConditions_StringNotEquals")]
        public Amazon.Backup.Model.KeyValue[] ProtectedResourceConditions_StringNotEqual { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelection_ValidationWindowHour
        /// <summary>
        /// <para>
        /// <para>This is amount of hours (1 to 168) available to run a validation script on the data.
        /// The data will be deleted upon the completion of the validation script or the end of
        /// the specified retention period, whichever comes first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingSelection_ValidationWindowHours")]
        public System.Int32? RestoreTestingSelection_ValidationWindowHour { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateRestoreTestingSelectionResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateRestoreTestingSelectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RestoreTestingPlanName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RestoreTestingPlanName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RestoreTestingPlanName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RestoreTestingPlanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKRestoreTestingSelection (CreateRestoreTestingSelection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateRestoreTestingSelectionResponse, NewBAKRestoreTestingSelectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RestoreTestingPlanName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CreatorRequestId = this.CreatorRequestId;
            context.RestoreTestingPlanName = this.RestoreTestingPlanName;
            #if MODULAR
            if (this.RestoreTestingPlanName == null && ParameterWasBound(nameof(this.RestoreTestingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RestoreTestingSelection_IamRoleArn = this.RestoreTestingSelection_IamRoleArn;
            #if MODULAR
            if (this.RestoreTestingSelection_IamRoleArn == null && ParameterWasBound(nameof(this.RestoreTestingSelection_IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingSelection_IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RestoreTestingSelection_ProtectedResourceArn != null)
            {
                context.RestoreTestingSelection_ProtectedResourceArn = new List<System.String>(this.RestoreTestingSelection_ProtectedResourceArn);
            }
            if (this.ProtectedResourceConditions_StringEqual != null)
            {
                context.ProtectedResourceConditions_StringEqual = new List<Amazon.Backup.Model.KeyValue>(this.ProtectedResourceConditions_StringEqual);
            }
            if (this.ProtectedResourceConditions_StringNotEqual != null)
            {
                context.ProtectedResourceConditions_StringNotEqual = new List<Amazon.Backup.Model.KeyValue>(this.ProtectedResourceConditions_StringNotEqual);
            }
            context.RestoreTestingSelection_ProtectedResourceType = this.RestoreTestingSelection_ProtectedResourceType;
            #if MODULAR
            if (this.RestoreTestingSelection_ProtectedResourceType == null && ParameterWasBound(nameof(this.RestoreTestingSelection_ProtectedResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingSelection_ProtectedResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RestoreTestingSelection_RestoreMetadataOverride != null)
            {
                context.RestoreTestingSelection_RestoreMetadataOverride = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RestoreTestingSelection_RestoreMetadataOverride.Keys)
                {
                    context.RestoreTestingSelection_RestoreMetadataOverride.Add((String)hashKey, (System.String)(this.RestoreTestingSelection_RestoreMetadataOverride[hashKey]));
                }
            }
            context.RestoreTestingSelection_RestoreTestingSelectionName = this.RestoreTestingSelection_RestoreTestingSelectionName;
            #if MODULAR
            if (this.RestoreTestingSelection_RestoreTestingSelectionName == null && ParameterWasBound(nameof(this.RestoreTestingSelection_RestoreTestingSelectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingSelection_RestoreTestingSelectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RestoreTestingSelection_ValidationWindowHour = this.RestoreTestingSelection_ValidationWindowHour;
            
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
            var request = new Amazon.Backup.Model.CreateRestoreTestingSelectionRequest();
            
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.RestoreTestingPlanName != null)
            {
                request.RestoreTestingPlanName = cmdletContext.RestoreTestingPlanName;
            }
            
             // populate RestoreTestingSelection
            var requestRestoreTestingSelectionIsNull = true;
            request.RestoreTestingSelection = new Amazon.Backup.Model.RestoreTestingSelectionForCreate();
            System.String requestRestoreTestingSelection_restoreTestingSelection_IamRoleArn = null;
            if (cmdletContext.RestoreTestingSelection_IamRoleArn != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_IamRoleArn = cmdletContext.RestoreTestingSelection_IamRoleArn;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_IamRoleArn != null)
            {
                request.RestoreTestingSelection.IamRoleArn = requestRestoreTestingSelection_restoreTestingSelection_IamRoleArn;
                requestRestoreTestingSelectionIsNull = false;
            }
            List<System.String> requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceArn = null;
            if (cmdletContext.RestoreTestingSelection_ProtectedResourceArn != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceArn = cmdletContext.RestoreTestingSelection_ProtectedResourceArn;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceArn != null)
            {
                request.RestoreTestingSelection.ProtectedResourceArns = requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceArn;
                requestRestoreTestingSelectionIsNull = false;
            }
            System.String requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceType = null;
            if (cmdletContext.RestoreTestingSelection_ProtectedResourceType != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceType = cmdletContext.RestoreTestingSelection_ProtectedResourceType;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceType != null)
            {
                request.RestoreTestingSelection.ProtectedResourceType = requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceType;
                requestRestoreTestingSelectionIsNull = false;
            }
            Dictionary<System.String, System.String> requestRestoreTestingSelection_restoreTestingSelection_RestoreMetadataOverride = null;
            if (cmdletContext.RestoreTestingSelection_RestoreMetadataOverride != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_RestoreMetadataOverride = cmdletContext.RestoreTestingSelection_RestoreMetadataOverride;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_RestoreMetadataOverride != null)
            {
                request.RestoreTestingSelection.RestoreMetadataOverrides = requestRestoreTestingSelection_restoreTestingSelection_RestoreMetadataOverride;
                requestRestoreTestingSelectionIsNull = false;
            }
            System.String requestRestoreTestingSelection_restoreTestingSelection_RestoreTestingSelectionName = null;
            if (cmdletContext.RestoreTestingSelection_RestoreTestingSelectionName != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_RestoreTestingSelectionName = cmdletContext.RestoreTestingSelection_RestoreTestingSelectionName;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_RestoreTestingSelectionName != null)
            {
                request.RestoreTestingSelection.RestoreTestingSelectionName = requestRestoreTestingSelection_restoreTestingSelection_RestoreTestingSelectionName;
                requestRestoreTestingSelectionIsNull = false;
            }
            System.Int32? requestRestoreTestingSelection_restoreTestingSelection_ValidationWindowHour = null;
            if (cmdletContext.RestoreTestingSelection_ValidationWindowHour != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ValidationWindowHour = cmdletContext.RestoreTestingSelection_ValidationWindowHour.Value;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_ValidationWindowHour != null)
            {
                request.RestoreTestingSelection.ValidationWindowHours = requestRestoreTestingSelection_restoreTestingSelection_ValidationWindowHour.Value;
                requestRestoreTestingSelectionIsNull = false;
            }
            Amazon.Backup.Model.ProtectedResourceConditions requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions = null;
            
             // populate ProtectedResourceConditions
            var requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditionsIsNull = true;
            requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions = new Amazon.Backup.Model.ProtectedResourceConditions();
            List<Amazon.Backup.Model.KeyValue> requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringEqual = null;
            if (cmdletContext.ProtectedResourceConditions_StringEqual != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringEqual = cmdletContext.ProtectedResourceConditions_StringEqual;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringEqual != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions.StringEquals = requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringEqual;
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditionsIsNull = false;
            }
            List<Amazon.Backup.Model.KeyValue> requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringNotEqual = null;
            if (cmdletContext.ProtectedResourceConditions_StringNotEqual != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringNotEqual = cmdletContext.ProtectedResourceConditions_StringNotEqual;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringNotEqual != null)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions.StringNotEquals = requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions_protectedResourceConditions_StringNotEqual;
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditionsIsNull = false;
            }
             // determine if requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions should be set to null
            if (requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditionsIsNull)
            {
                requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions = null;
            }
            if (requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions != null)
            {
                request.RestoreTestingSelection.ProtectedResourceConditions = requestRestoreTestingSelection_restoreTestingSelection_ProtectedResourceConditions;
                requestRestoreTestingSelectionIsNull = false;
            }
             // determine if request.RestoreTestingSelection should be set to null
            if (requestRestoreTestingSelectionIsNull)
            {
                request.RestoreTestingSelection = null;
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
        
        private Amazon.Backup.Model.CreateRestoreTestingSelectionResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateRestoreTestingSelectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateRestoreTestingSelection");
            try
            {
                #if DESKTOP
                return client.CreateRestoreTestingSelection(request);
                #elif CORECLR
                return client.CreateRestoreTestingSelectionAsync(request).GetAwaiter().GetResult();
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
            public System.String CreatorRequestId { get; set; }
            public System.String RestoreTestingPlanName { get; set; }
            public System.String RestoreTestingSelection_IamRoleArn { get; set; }
            public List<System.String> RestoreTestingSelection_ProtectedResourceArn { get; set; }
            public List<Amazon.Backup.Model.KeyValue> ProtectedResourceConditions_StringEqual { get; set; }
            public List<Amazon.Backup.Model.KeyValue> ProtectedResourceConditions_StringNotEqual { get; set; }
            public System.String RestoreTestingSelection_ProtectedResourceType { get; set; }
            public Dictionary<System.String, System.String> RestoreTestingSelection_RestoreMetadataOverride { get; set; }
            public System.String RestoreTestingSelection_RestoreTestingSelectionName { get; set; }
            public System.Int32? RestoreTestingSelection_ValidationWindowHour { get; set; }
            public System.Func<Amazon.Backup.Model.CreateRestoreTestingSelectionResponse, NewBAKRestoreTestingSelectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
