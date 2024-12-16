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
    /// Updates the specified restore testing selection.
    /// 
    ///  
    /// <para>
    /// Most elements except the <c>RestoreTestingSelectionName</c> can be updated with this
    /// request.
    /// </para><para>
    /// You can use either protected resource ARNs or conditions, but not both.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "BAKRestoreTestingSelection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse")]
    [AWSCmdlet("Calls the AWS Backup UpdateRestoreTestingSelection API operation.", Operation = new[] {"UpdateRestoreTestingSelection"}, SelectReturnType = typeof(Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse",
        "This cmdlet returns an Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse object containing multiple properties."
    )]
    public partial class UpdateBAKRestoreTestingSelectionCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RestoreTestingSelection_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Backup uses to create the target
        /// resource; for example: <c>arn:aws:iam::123456789012:role/S3Access</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestoreTestingSelection_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelection_ProtectedResourceArn
        /// <summary>
        /// <para>
        /// <para>You can include a list of specific ARNs, such as <c>ProtectedResourceArns: ["arn:aws:...",
        /// "arn:aws:..."]</c> or you can include a wildcard: <c>ProtectedResourceArns: ["*"]</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingSelection_ProtectedResourceArns")]
        public System.String[] RestoreTestingSelection_ProtectedResourceArn { get; set; }
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
        /// <para>The restore testing plan name is required to update the indicated testing plan.</para>
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
        public System.String RestoreTestingPlanName { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelectionName
        /// <summary>
        /// <para>
        /// <para>The required restore testing selection name of the restore testing selection you wish
        /// to update.</para>
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
        public System.String RestoreTestingSelectionName { get; set; }
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
        /// <para>This value represents the time, in hours, data is retained after a restore test so
        /// that optional validation can be completed.</para><para>Accepted value is an integer between 0 and 168 (the hourly equivalent of seven days).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingSelection_ValidationWindowHours")]
        public System.Int32? RestoreTestingSelection_ValidationWindowHour { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RestoreTestingSelectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKRestoreTestingSelection (UpdateRestoreTestingSelection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse, UpdateBAKRestoreTestingSelectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RestoreTestingPlanName = this.RestoreTestingPlanName;
            #if MODULAR
            if (this.RestoreTestingPlanName == null && ParameterWasBound(nameof(this.RestoreTestingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RestoreTestingSelection_IamRoleArn = this.RestoreTestingSelection_IamRoleArn;
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
            if (this.RestoreTestingSelection_RestoreMetadataOverride != null)
            {
                context.RestoreTestingSelection_RestoreMetadataOverride = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RestoreTestingSelection_RestoreMetadataOverride.Keys)
                {
                    context.RestoreTestingSelection_RestoreMetadataOverride.Add((String)hashKey, (System.String)(this.RestoreTestingSelection_RestoreMetadataOverride[hashKey]));
                }
            }
            context.RestoreTestingSelection_ValidationWindowHour = this.RestoreTestingSelection_ValidationWindowHour;
            context.RestoreTestingSelectionName = this.RestoreTestingSelectionName;
            #if MODULAR
            if (this.RestoreTestingSelectionName == null && ParameterWasBound(nameof(this.RestoreTestingSelectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingSelectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.UpdateRestoreTestingSelectionRequest();
            
            if (cmdletContext.RestoreTestingPlanName != null)
            {
                request.RestoreTestingPlanName = cmdletContext.RestoreTestingPlanName;
            }
            
             // populate RestoreTestingSelection
            var requestRestoreTestingSelectionIsNull = true;
            request.RestoreTestingSelection = new Amazon.Backup.Model.RestoreTestingSelectionForUpdate();
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
            if (cmdletContext.RestoreTestingSelectionName != null)
            {
                request.RestoreTestingSelectionName = cmdletContext.RestoreTestingSelectionName;
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
        
        private Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateRestoreTestingSelectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "UpdateRestoreTestingSelection");
            try
            {
                #if DESKTOP
                return client.UpdateRestoreTestingSelection(request);
                #elif CORECLR
                return client.UpdateRestoreTestingSelectionAsync(request).GetAwaiter().GetResult();
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
            public System.String RestoreTestingPlanName { get; set; }
            public System.String RestoreTestingSelection_IamRoleArn { get; set; }
            public List<System.String> RestoreTestingSelection_ProtectedResourceArn { get; set; }
            public List<Amazon.Backup.Model.KeyValue> ProtectedResourceConditions_StringEqual { get; set; }
            public List<Amazon.Backup.Model.KeyValue> ProtectedResourceConditions_StringNotEqual { get; set; }
            public Dictionary<System.String, System.String> RestoreTestingSelection_RestoreMetadataOverride { get; set; }
            public System.Int32? RestoreTestingSelection_ValidationWindowHour { get; set; }
            public System.String RestoreTestingSelectionName { get; set; }
            public System.Func<Amazon.Backup.Model.UpdateRestoreTestingSelectionResponse, UpdateBAKRestoreTestingSelectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
