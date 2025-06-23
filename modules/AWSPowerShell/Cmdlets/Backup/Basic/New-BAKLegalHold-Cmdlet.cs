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
using System.Threading;
using Amazon.Backup;
using Amazon.Backup.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Creates a legal hold on a recovery point (backup). A legal hold is a restraint on
    /// altering or deleting a backup until an authorized user cancels the legal hold. Any
    /// actions to delete or disassociate a recovery point will fail with an error if one
    /// or more active legal holds are on the recovery point.
    /// </summary>
    [Cmdlet("New", "BAKLegalHold", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateLegalHoldResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateLegalHold API operation.", Operation = new[] {"CreateLegalHold"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateLegalHoldResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateLegalHoldResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateLegalHoldResponse object containing multiple properties."
    )]
    public partial class NewBAKLegalHoldCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the legal hold.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DateRange_FromDate
        /// <summary>
        /// <para>
        /// <para>This value is the beginning date, inclusive.</para><para>The date and time are in Unix format and Coordinated Universal Time (UTC), and it
        /// is accurate to milliseconds (milliseconds are optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecoveryPointSelection_DateRange_FromDate")]
        public System.DateTime? DateRange_FromDate { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>This is a user-chosen string used to distinguish between otherwise identical calls.
        /// Retrying a successful request with the same idempotency token results in a success
        /// message with no action taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter RecoveryPointSelection_ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>These are the resources included in the resource selection (including type of resources
        /// and vaults).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecoveryPointSelection_ResourceIdentifiers")]
        public System.String[] RecoveryPointSelection_ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional tags to include. A tag is a key-value pair you can use to manage, filter,
        /// and search for your resources. Allowed characters include UTF-8 letters, numbers,
        /// spaces, and the following characters: + - = . _ : /. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title of the legal hold.</para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter DateRange_ToDate
        /// <summary>
        /// <para>
        /// <para>This value is the end date, inclusive.</para><para>The date and time are in Unix format and Coordinated Universal Time (UTC), and it
        /// is accurate to milliseconds (milliseconds are optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecoveryPointSelection_DateRange_ToDate")]
        public System.DateTime? DateRange_ToDate { get; set; }
        #endregion
        
        #region Parameter RecoveryPointSelection_VaultName
        /// <summary>
        /// <para>
        /// <para>These are the names of the vaults in which the selected recovery points are contained.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecoveryPointSelection_VaultNames")]
        public System.String[] RecoveryPointSelection_VaultName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateLegalHoldResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateLegalHoldResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Title), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKLegalHold (CreateLegalHold)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateLegalHoldResponse, NewBAKLegalHoldCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.DateRange_FromDate = this.DateRange_FromDate;
            context.DateRange_ToDate = this.DateRange_ToDate;
            if (this.RecoveryPointSelection_ResourceIdentifier != null)
            {
                context.RecoveryPointSelection_ResourceIdentifier = new List<System.String>(this.RecoveryPointSelection_ResourceIdentifier);
            }
            if (this.RecoveryPointSelection_VaultName != null)
            {
                context.RecoveryPointSelection_VaultName = new List<System.String>(this.RecoveryPointSelection_VaultName);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.CreateLegalHoldRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            
             // populate RecoveryPointSelection
            var requestRecoveryPointSelectionIsNull = true;
            request.RecoveryPointSelection = new Amazon.Backup.Model.RecoveryPointSelection();
            List<System.String> requestRecoveryPointSelection_recoveryPointSelection_ResourceIdentifier = null;
            if (cmdletContext.RecoveryPointSelection_ResourceIdentifier != null)
            {
                requestRecoveryPointSelection_recoveryPointSelection_ResourceIdentifier = cmdletContext.RecoveryPointSelection_ResourceIdentifier;
            }
            if (requestRecoveryPointSelection_recoveryPointSelection_ResourceIdentifier != null)
            {
                request.RecoveryPointSelection.ResourceIdentifiers = requestRecoveryPointSelection_recoveryPointSelection_ResourceIdentifier;
                requestRecoveryPointSelectionIsNull = false;
            }
            List<System.String> requestRecoveryPointSelection_recoveryPointSelection_VaultName = null;
            if (cmdletContext.RecoveryPointSelection_VaultName != null)
            {
                requestRecoveryPointSelection_recoveryPointSelection_VaultName = cmdletContext.RecoveryPointSelection_VaultName;
            }
            if (requestRecoveryPointSelection_recoveryPointSelection_VaultName != null)
            {
                request.RecoveryPointSelection.VaultNames = requestRecoveryPointSelection_recoveryPointSelection_VaultName;
                requestRecoveryPointSelectionIsNull = false;
            }
            Amazon.Backup.Model.DateRange requestRecoveryPointSelection_recoveryPointSelection_DateRange = null;
            
             // populate DateRange
            var requestRecoveryPointSelection_recoveryPointSelection_DateRangeIsNull = true;
            requestRecoveryPointSelection_recoveryPointSelection_DateRange = new Amazon.Backup.Model.DateRange();
            System.DateTime? requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_FromDate = null;
            if (cmdletContext.DateRange_FromDate != null)
            {
                requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_FromDate = cmdletContext.DateRange_FromDate.Value;
            }
            if (requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_FromDate != null)
            {
                requestRecoveryPointSelection_recoveryPointSelection_DateRange.FromDate = requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_FromDate.Value;
                requestRecoveryPointSelection_recoveryPointSelection_DateRangeIsNull = false;
            }
            System.DateTime? requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_ToDate = null;
            if (cmdletContext.DateRange_ToDate != null)
            {
                requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_ToDate = cmdletContext.DateRange_ToDate.Value;
            }
            if (requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_ToDate != null)
            {
                requestRecoveryPointSelection_recoveryPointSelection_DateRange.ToDate = requestRecoveryPointSelection_recoveryPointSelection_DateRange_dateRange_ToDate.Value;
                requestRecoveryPointSelection_recoveryPointSelection_DateRangeIsNull = false;
            }
             // determine if requestRecoveryPointSelection_recoveryPointSelection_DateRange should be set to null
            if (requestRecoveryPointSelection_recoveryPointSelection_DateRangeIsNull)
            {
                requestRecoveryPointSelection_recoveryPointSelection_DateRange = null;
            }
            if (requestRecoveryPointSelection_recoveryPointSelection_DateRange != null)
            {
                request.RecoveryPointSelection.DateRange = requestRecoveryPointSelection_recoveryPointSelection_DateRange;
                requestRecoveryPointSelectionIsNull = false;
            }
             // determine if request.RecoveryPointSelection should be set to null
            if (requestRecoveryPointSelectionIsNull)
            {
                request.RecoveryPointSelection = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.Backup.Model.CreateLegalHoldResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateLegalHoldRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateLegalHold");
            try
            {
                return client.CreateLegalHoldAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.DateTime? DateRange_FromDate { get; set; }
            public System.DateTime? DateRange_ToDate { get; set; }
            public List<System.String> RecoveryPointSelection_ResourceIdentifier { get; set; }
            public List<System.String> RecoveryPointSelection_VaultName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.Backup.Model.CreateLegalHoldResponse, NewBAKLegalHoldCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
